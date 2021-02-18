using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace MAHA_Dyno
{
    public partial class DynoForm : Form
    {
        private IUARTService _uartService;
        private MAHADynoService _dynoService;
        private MAHADynoStatus _currentStatus;
        private DynoTestValues _currentValues;
        private bool _getTestValuesOnly = false;
        private bool _sendNextControlWord = false;
        private char _nextControlWord = ' ';
        private bool _writeNextVariable = false;
        private int _nextWriteVariable = -1;
        private string _nextWriteVariableValue = "";
        private bool _readNextVariable = false;
        private int _nextReadVariable = -1;
        private string _nextReadVariableValue = "";
        private Task _updaterTask;

        public DynoForm()
        {
            InitializeComponent();
        }

        private delegate void UpdateTestValuesDelegate(DynoTestValues values);
        public void UpdateTestValues(DynoTestValues values)
        {
            if (InvokeRequired)
            {
                var d = new UpdateTestValuesDelegate(UpdateTestValues);
                Invoke(d, new object[] { values });
            }
            else
            {
                _currentValues = values;
                if (_currentValues != null)
                {
                    circularProgressBarSpeed.SubscriptText = ((int)_currentValues.Speed).ToString();
                    circularProgressBarTorque.SubscriptText = ((int)_currentValues.Torque).ToString();
                    circularProgressBarPower.SubscriptText = ((int)_currentValues.Power).ToString();
                    circularProgressBarSpeed.Value = (int)Math.Min(Math.Max(circularProgressBarSpeed.Minimum, _currentValues.Speed), circularProgressBarSpeed.Maximum);
                    circularProgressBarTorque.Value = (int)Math.Min(Math.Max(circularProgressBarTorque.Minimum, _currentValues.Torque), circularProgressBarTorque.Maximum);
                    circularProgressBarPower.Value = (int)Math.Min(Math.Max(circularProgressBarPower.Minimum, _currentValues.Power), circularProgressBarPower.Maximum);
                    this.Refresh();
                }
                else
                {
                    circularProgressBarSpeed.SubscriptText = "N/A";
                    circularProgressBarTorque.SubscriptText = "N/A";
                    circularProgressBarPower.SubscriptText = "N/A";
                    circularProgressBarSpeed.Value = circularProgressBarSpeed.Minimum;
                    circularProgressBarTorque.Value = circularProgressBarTorque.Minimum;
                    circularProgressBarPower.Value = circularProgressBarPower.Minimum;
                }
            }
        }

        private delegate void UpdateStatusDelegate(MAHADynoStatus status);
        public void UpdateStatus(MAHADynoStatus status)
        {
            if (InvokeRequired)
            {
                var d = new UpdateStatusDelegate(UpdateStatus);
                Invoke(d, new object[] { status });
            }
            else
            {
                _currentStatus = status;
                if (_currentStatus != null)
                {
                    if (_currentStatus.LiftBeamUp)
                    {
                        buttonLiftBeam.Text = "Down";
                        labelLiftBeam.Text = "Lift Beam: Up";
                    }
                    if (_currentStatus.LiftBeamDown)
                    {
                        buttonLiftBeam.Text = "Up";
                        labelLiftBeam.Text = "Lift Beam: Down";
                    }
                    if (_currentStatus.DrivingMotorRunning)
                    {
                        buttonDriveMotor.Text = "Off";
                        labelDriveMotor.Text = "Drive Motor: On";
                    }
                    else
                    {
                        buttonDriveMotor.Text = "On";
                        labelDriveMotor.Text = "Drive Motor: Off";
                    }
                }

                if (_currentValues != null && _currentStatus != null)
                {
                    buttonStartLog.Enabled = true;
                    buttonSpeedRegulator.Enabled = true;
                    textBoxVariable.Enabled = true;
                    numericUpDownVariable.Enabled = true;
                    buttonVariableWrite.Enabled = true;
                    if (_currentValues.Speed > 1)
                    {
                        buttonLiftBeam.Enabled = false;
                        if (buttonLiftBeam.Text != "Down" || buttonDriveMotor.Text != "On")
                            buttonDriveMotor.Enabled = true;
                        else
                            buttonDriveMotor.Enabled = false;
                    }
                    else
                    {
                        buttonLiftBeam.Enabled = true;
                        if (buttonLiftBeam.Text != "Down")
                            buttonDriveMotor.Enabled = true;
                        else
                            buttonDriveMotor.Enabled = false;
                    }
                }
                else
                {
                    buttonStartLog.Enabled = false;
                    buttonSpeedRegulator.Enabled = false;
                    buttonLiftBeam.Enabled = false;
                    buttonDriveMotor.Enabled = false;
                    buttonSpeedRegulator.Text = "Hold";
                    buttonLiftBeam.Text = "Down";
                    labelLiftBeam.Text = "Lift Beam: N/A";
                    buttonDriveMotor.Text = "On";
                    labelDriveMotor.Text = "Drive Motor: N/A";
                    textBoxVariable.BackColor = Color.White;
                    textBoxVariable.Text = "";
                    textBoxVariable.Enabled = false;
                    numericUpDownVariable.Enabled = false;
                    numericUpDownVariable.Value = 0;
                    buttonVariableWrite.Enabled = false;
                }
            }
        }

        private void adjustMaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (sender as ToolStripItem);
            if (item != null)
            {
                ContextMenuStrip owner = item.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    CircularProgressBar.CircularProgressBar progressBar = owner.SourceControl as CircularProgressBar.CircularProgressBar;
                    if (progressBar != null)
                    {
                        var newMax = Microsoft.VisualBasic.Interaction.InputBox("Set Max", "Set Max", "" + progressBar.Maximum);
                        int newMaxInt;

                        if (int.TryParse(newMax, out newMaxInt))
                        {
                            progressBar.Maximum = newMaxInt;
                            if(progressBar.Text == "Speed")
                            {
                                numericUpDownSpeedRegulator.Maximum = newMaxInt;
                            }
                        }
                    }
                }
            }
        }

        private void buttonLiftBeam_Click(object sender, EventArgs e)
        {
            if(buttonLiftBeam.Text == "Down")
            {
                //send command to put lift beam down
                SendControlWord('6');
            }
            else
            {
                //send command to put lift beam up
                SendControlWord('5');
            }
        }

        private void buttonDriveMotor_Click(object sender, EventArgs e)
        {
            if (buttonDriveMotor.Text == "On")
            {
                //send command to turn drive motor on
                SendControlWord('J');
            }
            else
            {
                //send command to turn drive motor off
                SendControlWord('K');
            }
        }

        private void buttonSpeedRegulator_Click(object sender, EventArgs e)
        {
            if (buttonSpeedRegulator.Text == "Hold")
            {
                //update speed regulator variable
                WriteVariable(200, string.Format("{0:000.0}", numericUpDownSpeedRegulator.Value));
                //send command to hold speed
                SendControlWord('1');
            }
            else
            {
                //send command to stop holding speed
                SendControlWord('0');
            }
        }

        private void numericUpDownSpeedRegulator_ValueChanged(object sender, EventArgs e)
        {
            if (buttonSpeedRegulator.Text != "Hold")
            {
                //we are holding so
                //update speed regulator variable
                WriteVariable(200, string.Format("{0:000.0}", numericUpDownSpeedRegulator.Value));
            }
        }

        private void comboBoxSerialPort_Click(object sender, EventArgs e)
        {
            comboBoxSerialPort.Items.Clear();
            List<string> ports = new List<string>(SerialPort.GetPortNames());
            ports.Add("debug");
            comboBoxSerialPort.Items.AddRange(ports.ToArray());
        }

        private void comboBoxSerialPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string comPort = comboBoxSerialPort.SelectedItem.ToString();
            if (!string.IsNullOrWhiteSpace(comPort))
            {
                _uartService = new COMPortService(comPort, 9600);
                _dynoService = new MAHADynoService(_uartService);
            }
            else
            {
                _uartService = null;
                _dynoService = null;
                UpdateTestValues(null);
                UpdateStatus(null);
            }
        }

        private void SendControlWord(char c)
        {
            _nextControlWord = c;
            _sendNextControlWord = true;

            //int cnt = 0;
            //while (_sendNextControlWord && cnt < 50)
            //{
            //    Thread.Sleep(10);
            //    cnt++;
            //}
            //
            //if (_sendNextControlWord)
            //{
            //    _sendNextControlWord = false;
            //    _nextControlWord = ' ';
            //    return false;
            //}
            //return true;
        }

        private bool WriteVariable(int variable, string value)
        {
            _nextWriteVariable = variable;
            _nextWriteVariableValue = value;
            _writeNextVariable = true;

            int cnt = 0;
            while (_writeNextVariable && cnt < 50)
            {
                Thread.Sleep(10);
                cnt++;
            }
            

            if(_writeNextVariable)
            {
                _writeNextVariable = false;
                _nextWriteVariableValue = "";
                _nextWriteVariable = -1;
                return false;
            }
            return true;
        }

        private string ReadVariable(int variable)
        {
            _nextReadVariable = variable;
            _nextReadVariableValue = "";
            _readNextVariable = true;

            int cnt = 0;
            while (_readNextVariable && cnt < 50)
            {
                Thread.Sleep(10);
                cnt++;
            }

            if (_readNextVariable)
            {
                _readNextVariable = false;
                _nextReadVariableValue = "";
                _nextReadVariable = -1;
                return null;
            }
            return _nextReadVariableValue;
        }

        public void UpdaterThread()
        {
            while (true)
            {
                DateTime before = DateTime.Now;
                if (_uartService != null && _dynoService != null)
                {
                    if (textBoxVariable.BackColor == Color.White && textBoxVariable.Text == "" && textBoxVariable.Enabled == true && numericUpDownVariable.Value == 0)
                    {
                        Invoke((MethodInvoker) delegate() { _variableValue = textBoxVariable.Text = _dynoService.ReadVariable((int)numericUpDownVariable.Value); });
                    }
                    if (_writeNextVariable)
                    {
                        _dynoService.WriteVariable(_nextWriteVariable, _nextWriteVariableValue);
                        _nextWriteVariableValue = "";
                        _nextWriteVariable = -1;
                        _writeNextVariable = false;
                    }
                    if (_sendNextControlWord)
                    {
                        if(_dynoService.SendControlWord(_nextControlWord))
                            Invoke((MethodInvoker)delegate () { richTextBoxLog.Text = "Sent Control Word: " + _nextControlWord + "\n" + richTextBoxLog.Text;  });
                        else
                            Invoke((MethodInvoker)delegate () { richTextBoxLog.Text = "Failed to Send Control Word: " + _nextControlWord + "\n" + richTextBoxLog.Text; });
                        _nextControlWord = ' ';
                        _sendNextControlWord = false;
                    }
                    if (_readNextVariable)
                    {
                        _nextReadVariableValue = _dynoService.ReadVariable(_nextReadVariable);
                        _nextReadVariable = -1;
                        _readNextVariable = false;
                    }
                    
                    UpdateTestValues(_dynoService.GetDynoTestNumbers());
                    if (!_getTestValuesOnly)
                    {
                        UpdateStatus(_dynoService.GetDynoStatus());
                    }
                }
                Thread.Sleep(Math.Max(1, (int)(before.AddMilliseconds(200) - DateTime.Now).TotalMilliseconds));
            }
        }
        int test = 0;

        private void DynoForm_Load(object sender, EventArgs e)
        {
            _updaterTask = Task.Run(new Action(UpdaterThread));
        }

        private void DynoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private string _variableValue = "";

        private void textBoxVariable_TextChanged(object sender, EventArgs e)
        {
            if (_variableValue != textBoxVariable.Text)
                textBoxVariable.BackColor = Color.Yellow;
            else
                textBoxVariable.BackColor = Color.White;
        }

        private void buttonVariableWrite_Click(object sender, EventArgs e)
        {
            WriteVariable((int)numericUpDownVariable.Value, textBoxVariable.Text);
            _variableValue = textBoxVariable.Text = ReadVariable((int)numericUpDownVariable.Value);
            textBoxVariable.BackColor = Color.White;
        }

        private void numericUpDownVariable_ValueChanged(object sender, EventArgs e)
        {
            _variableValue = textBoxVariable.Text = ReadVariable((int)numericUpDownVariable.Value);
            textBoxVariable.BackColor = Color.White;
        }

        private void chartDyno_Click(object sender, EventArgs e)
        {
            buttonStartLog.Select();
        }

        private void buttonStartLog_Click(object sender, EventArgs e)
        {

        }
    }
}
