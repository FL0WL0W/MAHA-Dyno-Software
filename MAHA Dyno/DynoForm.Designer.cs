namespace MAHA_Dyno
{
    partial class DynoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonSpeedRegulator = new System.Windows.Forms.Button();
            this.numericUpDownSpeedRegulator = new System.Windows.Forms.NumericUpDown();
            this.labelSpeedRegulator = new System.Windows.Forms.Label();
            this.buttonLiftBeam = new System.Windows.Forms.Button();
            this.labelLiftBeam = new System.Windows.Forms.Label();
            this.buttonDriveMotor = new System.Windows.Forms.Button();
            this.labelDriveMotor = new System.Windows.Forms.Label();
            this.circularProgressBarSpeed = new CircularProgressBar.CircularProgressBar();
            this.contextMenuStripGauge = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.adjustMaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circularProgressBarTorque = new CircularProgressBar.CircularProgressBar();
            this.circularProgressBarPower = new CircularProgressBar.CircularProgressBar();
            this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
            this.labelSerialPort = new System.Windows.Forms.Label();
            this.textBoxVariable = new System.Windows.Forms.TextBox();
            this.labelVariable = new System.Windows.Forms.Label();
            this.numericUpDownVariable = new System.Windows.Forms.NumericUpDown();
            this.buttonVariableWrite = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.chartDyno = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonStartLog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeedRegulator)).BeginInit();
            this.contextMenuStripGauge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVariable)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDyno)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSpeedRegulator
            // 
            this.buttonSpeedRegulator.Enabled = false;
            this.buttonSpeedRegulator.Location = new System.Drawing.Point(280, 172);
            this.buttonSpeedRegulator.Margin = new System.Windows.Forms.Padding(6);
            this.buttonSpeedRegulator.Name = "buttonSpeedRegulator";
            this.buttonSpeedRegulator.Size = new System.Drawing.Size(150, 44);
            this.buttonSpeedRegulator.TabIndex = 0;
            this.buttonSpeedRegulator.Text = "Hold";
            this.buttonSpeedRegulator.UseVisualStyleBackColor = true;
            this.buttonSpeedRegulator.Click += new System.EventHandler(this.buttonSpeedRegulator_Click);
            // 
            // numericUpDownSpeedRegulator
            // 
            this.numericUpDownSpeedRegulator.Location = new System.Drawing.Point(186, 180);
            this.numericUpDownSpeedRegulator.Margin = new System.Windows.Forms.Padding(6);
            this.numericUpDownSpeedRegulator.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownSpeedRegulator.Name = "numericUpDownSpeedRegulator";
            this.numericUpDownSpeedRegulator.Size = new System.Drawing.Size(82, 31);
            this.numericUpDownSpeedRegulator.TabIndex = 1;
            this.numericUpDownSpeedRegulator.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownSpeedRegulator.ValueChanged += new System.EventHandler(this.numericUpDownSpeedRegulator_ValueChanged);
            // 
            // labelSpeedRegulator
            // 
            this.labelSpeedRegulator.AutoSize = true;
            this.labelSpeedRegulator.Location = new System.Drawing.Point(15, 182);
            this.labelSpeedRegulator.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSpeedRegulator.Name = "labelSpeedRegulator";
            this.labelSpeedRegulator.Size = new System.Drawing.Size(145, 25);
            this.labelSpeedRegulator.TabIndex = 2;
            this.labelSpeedRegulator.Text = "Hold at speed";
            // 
            // buttonLiftBeam
            // 
            this.buttonLiftBeam.Enabled = false;
            this.buttonLiftBeam.Location = new System.Drawing.Point(280, 60);
            this.buttonLiftBeam.Margin = new System.Windows.Forms.Padding(6);
            this.buttonLiftBeam.Name = "buttonLiftBeam";
            this.buttonLiftBeam.Size = new System.Drawing.Size(150, 44);
            this.buttonLiftBeam.TabIndex = 0;
            this.buttonLiftBeam.Text = "Down";
            this.buttonLiftBeam.UseVisualStyleBackColor = true;
            this.buttonLiftBeam.Click += new System.EventHandler(this.buttonLiftBeam_Click);
            // 
            // labelLiftBeam
            // 
            this.labelLiftBeam.AutoSize = true;
            this.labelLiftBeam.Location = new System.Drawing.Point(15, 70);
            this.labelLiftBeam.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelLiftBeam.Name = "labelLiftBeam";
            this.labelLiftBeam.Size = new System.Drawing.Size(141, 25);
            this.labelLiftBeam.TabIndex = 2;
            this.labelLiftBeam.Text = "Lift Beam: Up";
            // 
            // buttonDriveMotor
            // 
            this.buttonDriveMotor.Enabled = false;
            this.buttonDriveMotor.Location = new System.Drawing.Point(280, 116);
            this.buttonDriveMotor.Margin = new System.Windows.Forms.Padding(6);
            this.buttonDriveMotor.Name = "buttonDriveMotor";
            this.buttonDriveMotor.Size = new System.Drawing.Size(150, 44);
            this.buttonDriveMotor.TabIndex = 0;
            this.buttonDriveMotor.Text = "On";
            this.buttonDriveMotor.UseVisualStyleBackColor = true;
            this.buttonDriveMotor.Click += new System.EventHandler(this.buttonDriveMotor_Click);
            // 
            // labelDriveMotor
            // 
            this.labelDriveMotor.AutoSize = true;
            this.labelDriveMotor.Location = new System.Drawing.Point(15, 126);
            this.labelDriveMotor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelDriveMotor.Name = "labelDriveMotor";
            this.labelDriveMotor.Size = new System.Drawing.Size(163, 25);
            this.labelDriveMotor.TabIndex = 2;
            this.labelDriveMotor.Text = "Drive Motor: Off";
            // 
            // circularProgressBarSpeed
            // 
            this.circularProgressBarSpeed.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBarSpeed.AnimationSpeed = 500;
            this.circularProgressBarSpeed.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBarSpeed.ContextMenuStrip = this.contextMenuStripGauge;
            this.circularProgressBarSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.circularProgressBarSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularProgressBarSpeed.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.circularProgressBarSpeed.InnerMargin = 2;
            this.circularProgressBarSpeed.InnerWidth = -1;
            this.circularProgressBarSpeed.Location = new System.Drawing.Point(6, 6);
            this.circularProgressBarSpeed.Margin = new System.Windows.Forms.Padding(6);
            this.circularProgressBarSpeed.MarqueeAnimationSpeed = 2000;
            this.circularProgressBarSpeed.Maximum = 200;
            this.circularProgressBarSpeed.Minimum = 1;
            this.circularProgressBarSpeed.Name = "circularProgressBarSpeed";
            this.circularProgressBarSpeed.OuterColor = System.Drawing.Color.Silver;
            this.circularProgressBarSpeed.OuterMargin = -25;
            this.circularProgressBarSpeed.OuterWidth = 26;
            this.circularProgressBarSpeed.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.circularProgressBarSpeed.ProgressWidth = 25;
            this.circularProgressBarSpeed.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.circularProgressBarSpeed.Size = new System.Drawing.Size(468, 450);
            this.circularProgressBarSpeed.StartAngle = 90;
            this.circularProgressBarSpeed.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.circularProgressBarSpeed.SubscriptMargin = new System.Windows.Forms.Padding(25, -35, 0, 0);
            this.circularProgressBarSpeed.SubscriptText = "N/A";
            this.circularProgressBarSpeed.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularProgressBarSpeed.SuperscriptMargin = new System.Windows.Forms.Padding(25, 35, 0, 0);
            this.circularProgressBarSpeed.SuperscriptText = "MPH";
            this.circularProgressBarSpeed.TabIndex = 3;
            this.circularProgressBarSpeed.Text = "Speed";
            this.circularProgressBarSpeed.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBarSpeed.Value = 1;
            // 
            // contextMenuStripGauge
            // 
            this.contextMenuStripGauge.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStripGauge.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adjustMaxToolStripMenuItem});
            this.contextMenuStripGauge.Name = "contextMenuStripGauge";
            this.contextMenuStripGauge.Size = new System.Drawing.Size(177, 40);
            // 
            // adjustMaxToolStripMenuItem
            // 
            this.adjustMaxToolStripMenuItem.Name = "adjustMaxToolStripMenuItem";
            this.adjustMaxToolStripMenuItem.Size = new System.Drawing.Size(176, 36);
            this.adjustMaxToolStripMenuItem.Text = "Set Max";
            this.adjustMaxToolStripMenuItem.Click += new System.EventHandler(this.adjustMaxToolStripMenuItem_Click);
            // 
            // circularProgressBarTorque
            // 
            this.circularProgressBarTorque.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBarTorque.AnimationSpeed = 500;
            this.circularProgressBarTorque.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBarTorque.ContextMenuStrip = this.contextMenuStripGauge;
            this.circularProgressBarTorque.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.circularProgressBarTorque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularProgressBarTorque.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.circularProgressBarTorque.InnerMargin = 2;
            this.circularProgressBarTorque.InnerWidth = -1;
            this.circularProgressBarTorque.Location = new System.Drawing.Point(486, 6);
            this.circularProgressBarTorque.Margin = new System.Windows.Forms.Padding(6);
            this.circularProgressBarTorque.MarqueeAnimationSpeed = 2000;
            this.circularProgressBarTorque.Maximum = 1000;
            this.circularProgressBarTorque.Minimum = 1;
            this.circularProgressBarTorque.Name = "circularProgressBarTorque";
            this.circularProgressBarTorque.OuterColor = System.Drawing.Color.Silver;
            this.circularProgressBarTorque.OuterMargin = -25;
            this.circularProgressBarTorque.OuterWidth = 26;
            this.circularProgressBarTorque.ProgressColor = System.Drawing.Color.Lime;
            this.circularProgressBarTorque.ProgressWidth = 25;
            this.circularProgressBarTorque.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.circularProgressBarTorque.Size = new System.Drawing.Size(468, 450);
            this.circularProgressBarTorque.StartAngle = 90;
            this.circularProgressBarTorque.SubscriptColor = System.Drawing.Color.Lime;
            this.circularProgressBarTorque.SubscriptMargin = new System.Windows.Forms.Padding(25, -35, 0, 0);
            this.circularProgressBarTorque.SubscriptText = "N/A";
            this.circularProgressBarTorque.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularProgressBarTorque.SuperscriptMargin = new System.Windows.Forms.Padding(25, 35, 0, 0);
            this.circularProgressBarTorque.SuperscriptText = "lbf";
            this.circularProgressBarTorque.TabIndex = 3;
            this.circularProgressBarTorque.Text = "Torque";
            this.circularProgressBarTorque.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBarTorque.Value = 1;
            // 
            // circularProgressBarPower
            // 
            this.circularProgressBarPower.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBarPower.AnimationSpeed = 500;
            this.circularProgressBarPower.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBarPower.ContextMenuStrip = this.contextMenuStripGauge;
            this.circularProgressBarPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.circularProgressBarPower.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularProgressBarPower.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.circularProgressBarPower.InnerMargin = 2;
            this.circularProgressBarPower.InnerWidth = -1;
            this.circularProgressBarPower.Location = new System.Drawing.Point(966, 6);
            this.circularProgressBarPower.Margin = new System.Windows.Forms.Padding(6);
            this.circularProgressBarPower.MarqueeAnimationSpeed = 2000;
            this.circularProgressBarPower.Maximum = 500;
            this.circularProgressBarPower.Minimum = 1;
            this.circularProgressBarPower.Name = "circularProgressBarPower";
            this.circularProgressBarPower.OuterColor = System.Drawing.Color.Silver;
            this.circularProgressBarPower.OuterMargin = -25;
            this.circularProgressBarPower.OuterWidth = 26;
            this.circularProgressBarPower.ProgressColor = System.Drawing.Color.Red;
            this.circularProgressBarPower.ProgressWidth = 25;
            this.circularProgressBarPower.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.circularProgressBarPower.Size = new System.Drawing.Size(468, 450);
            this.circularProgressBarPower.StartAngle = 90;
            this.circularProgressBarPower.SubscriptColor = System.Drawing.Color.Red;
            this.circularProgressBarPower.SubscriptMargin = new System.Windows.Forms.Padding(25, -35, 0, 0);
            this.circularProgressBarPower.SubscriptText = "N/A";
            this.circularProgressBarPower.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularProgressBarPower.SuperscriptMargin = new System.Windows.Forms.Padding(25, 35, 0, 0);
            this.circularProgressBarPower.SuperscriptText = "HP";
            this.circularProgressBarPower.TabIndex = 3;
            this.circularProgressBarPower.Text = "Power";
            this.circularProgressBarPower.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBarPower.Value = 1;
            // 
            // comboBoxSerialPort
            // 
            this.comboBoxSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSerialPort.FormattingEnabled = true;
            this.comboBoxSerialPort.Location = new System.Drawing.Point(192, 15);
            this.comboBoxSerialPort.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxSerialPort.Name = "comboBoxSerialPort";
            this.comboBoxSerialPort.Size = new System.Drawing.Size(238, 33);
            this.comboBoxSerialPort.TabIndex = 5;
            this.comboBoxSerialPort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSerialPort_SelectedIndexChanged);
            this.comboBoxSerialPort.Click += new System.EventHandler(this.comboBoxSerialPort_Click);
            // 
            // labelSerialPort
            // 
            this.labelSerialPort.AutoSize = true;
            this.labelSerialPort.Location = new System.Drawing.Point(15, 18);
            this.labelSerialPort.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSerialPort.Name = "labelSerialPort";
            this.labelSerialPort.Size = new System.Drawing.Size(112, 25);
            this.labelSerialPort.TabIndex = 2;
            this.labelSerialPort.Text = "Serial Port";
            // 
            // textBoxVariable
            // 
            this.textBoxVariable.BackColor = System.Drawing.Color.White;
            this.textBoxVariable.Enabled = false;
            this.textBoxVariable.Location = new System.Drawing.Point(219, 441);
            this.textBoxVariable.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxVariable.Name = "textBoxVariable";
            this.textBoxVariable.Size = new System.Drawing.Size(196, 31);
            this.textBoxVariable.TabIndex = 6;
            this.textBoxVariable.TextChanged += new System.EventHandler(this.textBoxVariable_TextChanged);
            // 
            // labelVariable
            // 
            this.labelVariable.AutoSize = true;
            this.labelVariable.Location = new System.Drawing.Point(15, 444);
            this.labelVariable.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelVariable.Name = "labelVariable";
            this.labelVariable.Size = new System.Drawing.Size(91, 25);
            this.labelVariable.TabIndex = 7;
            this.labelVariable.Text = "Variable";
            // 
            // numericUpDownVariable
            // 
            this.numericUpDownVariable.Enabled = false;
            this.numericUpDownVariable.Location = new System.Drawing.Point(125, 442);
            this.numericUpDownVariable.Margin = new System.Windows.Forms.Padding(6);
            this.numericUpDownVariable.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericUpDownVariable.Name = "numericUpDownVariable";
            this.numericUpDownVariable.Size = new System.Drawing.Size(82, 31);
            this.numericUpDownVariable.TabIndex = 1;
            this.numericUpDownVariable.ValueChanged += new System.EventHandler(this.numericUpDownVariable_ValueChanged);
            // 
            // buttonVariableWrite
            // 
            this.buttonVariableWrite.Enabled = false;
            this.buttonVariableWrite.Location = new System.Drawing.Point(427, 434);
            this.buttonVariableWrite.Margin = new System.Windows.Forms.Padding(6);
            this.buttonVariableWrite.Name = "buttonVariableWrite";
            this.buttonVariableWrite.Size = new System.Drawing.Size(150, 44);
            this.buttonVariableWrite.TabIndex = 0;
            this.buttonVariableWrite.Text = "Write";
            this.buttonVariableWrite.UseVisualStyleBackColor = true;
            this.buttonVariableWrite.Click += new System.EventHandler(this.buttonVariableWrite_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.circularProgressBarSpeed, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.circularProgressBarTorque, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.circularProgressBarPower, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(442, 15);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1440, 462);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Location = new System.Drawing.Point(12, 225);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(420, 200);
            this.richTextBoxLog.TabIndex = 9;
            this.richTextBoxLog.Text = "";
            // 
            // chartDyno
            // 
            chartArea3.Name = "ChartArea1";
            this.chartDyno.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartDyno.Legends.Add(legend3);
            this.chartDyno.Location = new System.Drawing.Point(12, 482);
            this.chartDyno.Name = "chartDyno";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartDyno.Series.Add(series3);
            this.chartDyno.Size = new System.Drawing.Size(1870, 515);
            this.chartDyno.TabIndex = 10;
            this.chartDyno.Text = "chart1";
            this.chartDyno.Click += new System.EventHandler(this.chartDyno_Click);
            this.chartDyno.Enter += new System.EventHandler(this.chartDyno_Click);
            // 
            // buttonStartLog
            // 
            this.buttonStartLog.Enabled = false;
            this.buttonStartLog.Location = new System.Drawing.Point(1726, 941);
            this.buttonStartLog.Margin = new System.Windows.Forms.Padding(6);
            this.buttonStartLog.Name = "buttonStartLog";
            this.buttonStartLog.Size = new System.Drawing.Size(150, 44);
            this.buttonStartLog.TabIndex = 11;
            this.buttonStartLog.Text = "Start";
            this.buttonStartLog.UseVisualStyleBackColor = true;
            this.buttonStartLog.Click += new System.EventHandler(this.buttonStartLog_Click);
            // 
            // DynoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1894, 1009);
            this.Controls.Add(this.buttonStartLog);
            this.Controls.Add(this.chartDyno);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.labelVariable);
            this.Controls.Add(this.textBoxVariable);
            this.Controls.Add(this.comboBoxSerialPort);
            this.Controls.Add(this.labelDriveMotor);
            this.Controls.Add(this.labelSerialPort);
            this.Controls.Add(this.labelLiftBeam);
            this.Controls.Add(this.labelSpeedRegulator);
            this.Controls.Add(this.buttonDriveMotor);
            this.Controls.Add(this.numericUpDownVariable);
            this.Controls.Add(this.numericUpDownSpeedRegulator);
            this.Controls.Add(this.buttonVariableWrite);
            this.Controls.Add(this.buttonLiftBeam);
            this.Controls.Add(this.buttonSpeedRegulator);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(1280, 100);
            this.Name = "DynoForm";
            this.Text = "MAHA Dyno";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DynoForm_FormClosing);
            this.Load += new System.EventHandler(this.DynoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeedRegulator)).EndInit();
            this.contextMenuStripGauge.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVariable)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDyno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSpeedRegulator;
        private System.Windows.Forms.NumericUpDown numericUpDownSpeedRegulator;
        private System.Windows.Forms.Label labelSpeedRegulator;
        private System.Windows.Forms.Button buttonLiftBeam;
        private System.Windows.Forms.Label labelLiftBeam;
        private System.Windows.Forms.Button buttonDriveMotor;
        private System.Windows.Forms.Label labelDriveMotor;
        private CircularProgressBar.CircularProgressBar circularProgressBarSpeed;
        private CircularProgressBar.CircularProgressBar circularProgressBarTorque;
        private CircularProgressBar.CircularProgressBar circularProgressBarPower;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGauge;
        private System.Windows.Forms.ToolStripMenuItem adjustMaxToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxSerialPort;
        private System.Windows.Forms.Label labelSerialPort;
        private System.Windows.Forms.TextBox textBoxVariable;
        private System.Windows.Forms.Label labelVariable;
        private System.Windows.Forms.NumericUpDown numericUpDownVariable;
        private System.Windows.Forms.Button buttonVariableWrite;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDyno;
        private System.Windows.Forms.Button buttonStartLog;
    }
}

