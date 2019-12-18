using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAHA_Dyno
{
    public class MAHADynoService
    {
        private readonly int sleep = 100;
        private readonly int tryCnt = 10;
        protected IUARTService _uartService;

        public MAHADynoService(IUARTService uartService)
        {
            _uartService = uartService;
        }

        protected int Read()
        {
            int t;
            int cnt = 0;
            while ((t = _uartService.Read()) == -1)
            {
                System.Threading.Thread.Sleep(sleep);
                cnt++;
                if (cnt > tryCnt)
                    return -1;
            }
            return t;
        }

        public DynoTestValues GetDynoTestNumbers()
        {
            char[] s = new char[4];
            s[0] = (char)0xB4;
            s[1] = (char)0x11;
            s[2] = 'C';
            s[3] = (char)0x05;

            _uartService.Send(s.ToString());

            string power = "";
            string torque = "";
            string speed = "";

            for (int i = 0; i < 50; i++)
            {
                int t = Read();
                if(t == -1) goto badTestValues;
                char c = (char)t;

                if (i == 0 && c != 0x02) goto badTestValues;
                if (i == 1 && c != '2') goto badTestValues;
                if (i == 2 && c != '1') goto badTestValues;
                if (i == 3 && c != '1') goto badTestValues;
                if (i == 4 && c != '=') goto badTestValues;
                if (i > 4 && i < 11)
                {
                    power += c;
                }
                if (i == 11 && c != ' ') goto badTestValues;
                if (i == 12 && c != 'h') goto badTestValues;
                if (i == 13 && c != 'p') goto badTestValues;
                if (i == 14 && c != '\n') goto badTestValues;
                if (i == 15 && c != '2') goto badTestValues;
                if (i == 16 && c != '2') goto badTestValues;
                if (i == 17 && c != '1') goto badTestValues;
                if (i == 18 && c != '=') goto badTestValues;
                if (i > 18 && i < 26)
                {
                    torque += c;
                }
                if (i == 26 && c != ' ') goto badTestValues;
                if (i == 27 && c != 'l') goto badTestValues;
                if (i == 28 && c != 'b') goto badTestValues;
                if (i == 29 && c != 'f') goto badTestValues;
                if (i == 30 && c != '\n') goto badTestValues;
                if (i == 31 && c != '2') goto badTestValues;
                if (i == 32 && c != '0') goto badTestValues;
                if (i == 33 && c != '9') goto badTestValues;
                if (i == 34 && c != '=') goto badTestValues;
                if (i > 34 && i < 41)
                {
                    speed += c;
                }
                if (i == 41 && c != ' ') goto badTestValues;
                if (i == 42 && c != 'm') goto badTestValues;
                if (i == 43 && c != 'p') goto badTestValues;
                if (i == 44 && c != 'h') goto badTestValues;
                if (i == 45 && c != '\n') goto badTestValues;
                if (i == 46 && c != 0x17) goto badTestValues;
                if (i == 47 || i == 48)
                {
                    //todo do check checksum
                }
                if (i == 49 && c != '$') goto badTestValues;
            }

            DynoTestValues testValues = new DynoTestValues();

            testValues.Power = float.Parse(power);
            testValues.Torque = float.Parse(torque);
            testValues.Speed = float.Parse(speed);

            return testValues;

        badTestValues:
            while (Read() != -1) ;
            return null;
        }

        public MAHADynoStatus GetDynoStatus()
        {
            char[] s = new char[4];
            s[0] = (char)0xB4;
            s[1] = (char)0x11;
            s[2] = 'D';
            s[3] = (char)0x05;

            _uartService.Send(s.ToString());

            MAHADynoStatus status = new MAHADynoStatus();

            for (int i = 0; i < 21; i++)
            {
                int t = Read();
                if (t == -1) goto badStatus;
                char c = (char)t;

                if (i == 0 && c != 0x02) goto badStatus;
                if (i == 1) status.LiftBeamUp = c == '1';
                if (i == 2) status.LiftBeamDown = c == '1';
                if (i == 3) status.TorqueTooHigh = c == '1';
                if (i == 4) status.ASMSpeedTooHigh = c == '1';
                if (i == 5) status.AugmentedBrakingEnabled = c == '1';
                if (i == 6) status.PowerTooHigh = c == '1';
                if (i == 7) status.BrakeExcessTemperature = c == '1';
                if (i == 8) status.ImpulseSensorError = c == '1';
                if (i == 9) status.ShortCircuit = c == '1';
                if (i == 10) status.AutoOffsetError = c == '1';
                if (i == 11) status.RollerCovers = c == '1';
                if (i == 12) status.RestrainSystem = c == '1';
                if (i == 13) status.BearingExcessTemperature = c == '1';
                if (i == 14) status.ConverterMotorCurrentAndTemperature = c == '1';
                if (i == 15) status.Reserve = c == '1';
                if (i == 16) status.DrivingMotorRunning = c == '1';
                if (i == 17 && c != 0x17) goto badStatus;
                if (i == 18 || i == 19)
                {
                    //todo do check checksum
                }
                if (i == 20 && c != '$') goto badStatus;
            }
            
            return status;

        badStatus:
            while (Read() != -1) ;
            return null;
        }

        public string ReadVariable(int variableNumber)
        {
            string variableString = variableNumber.ToString();

            if (variableString.Length > 3)
                variableString = variableString.Substring(0, 3);
            else if (variableString.Length < 1)
                variableString = "000" + variableString;
            else if (variableString.Length < 2)
                variableString = "00" + variableString;
            else if (variableString.Length < 3)
                variableString = "0" + variableString;


            char[] s = new char[7];
            s[0] = (char)0xB4;
            s[1] = (char)0x11;
            s[2] = 'E';
            s[3] = variableString[0];
            s[4] = variableString[1];
            s[5] = variableString[2];
            s[6] = (char)0x05;

            _uartService.Send(s.ToString());

            int t;

            t = Read();
            if (t == -1 || (char)t != 0x02) goto badVariable;

            t = Read();
            if (t == -1 || (char)t != variableString[0]) goto badVariable;
            t = Read();
            if (t == -1 || (char)t != variableString[1]) goto badVariable;
            t = Read();
            if (t == -1 || (char)t != variableString[2]) goto badVariable;
            t = Read();
            if (t == -1 || (char)t != '=') goto badVariable;

            string variableValue = "";
            while(true)
            {
                t = Read();
                if(t == -1) goto badVariable;
                if ((char)t == '\n') break;

                variableValue += (char)t;
            }

            t = Read();
            if (t == -1 || (char)t != 0x17) goto badVariable;

            t = Read();
            t = Read();
            //todo check checksum

            if (t == -1 || (char)t != '$') goto badVariable;

            return variableValue;

        badVariable:
            while (Read() != -1) ;
            return null;
        }

        public bool WriteVariable(int variableNumber, string variableValue)
        {
            string variableString = variableNumber.ToString();

            if (variableString.Length > 3)
                variableString = variableString.Substring(0, 3);
            else if (variableString.Length < 1)
                variableString = "000" + variableString;
            else if (variableString.Length < 2)
                variableString = "00" + variableString;
            else if (variableString.Length < 3)
                variableString = "0" + variableString;


            char[] s = new char[9 + variableValue.Length];
            s[0] = (char)0xB4;
            s[1] = (char)0x11;
            s[2] = 'F';
            s[3] = variableString[0];
            s[4] = variableString[1];
            s[5] = variableString[2];
            s[6] = '=';

            for (int i = 0; i < variableValue.Length; i++)
                s[6 + i] = variableValue[i];

            //todo create and add checksum;
            char xor = s[1];
            for (int i = 2; i < 6 + variableValue.Length; i++)
                xor ^= s[i];

            //the only way i can see the xor taking 2 bytes is as a string
            string checksumstring = Convert.ToByte(xor).ToString("x2").ToUpper();
            s[6 + variableValue.Length] = checksumstring[0];
            s[7 + variableValue.Length] = checksumstring[1];

            s[8 + variableValue.Length] = '$';

            _uartService.Send(s.ToString());

            int t = Read();

            return (char)t == 0x06;
        }

        public bool SendControlWord(char c)
        {
            char[] s = new char[3];
            s[0] = (char)0xB4;
            s[1] = (char)0x11;
            s[2] = c;

            _uartService.Send(s.ToString());

            int t = Read();

            return (char)t == 0x06;
        }
    }
}
