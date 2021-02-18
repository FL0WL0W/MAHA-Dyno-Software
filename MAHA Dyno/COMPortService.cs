using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;

namespace MAHA_Dyno
{
    public class COMPortService : IUARTService, IDisposable
    {
        protected string _portName;
        protected SerialPort _port;
        protected byte[] buffer = new byte[256];
        protected int readPos = 0;
        protected int writePos = 0;

        public COMPortService(string port, int baudRate)
        {
            _portName = port;
            if (port != "debug")
            {
                _port = new SerialPort(port, baudRate, Parity.None, 8, StopBits.One);
                _port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                _port.Open();
            }
        }

        private void port_DataReceived(object sender,
          SerialDataReceivedEventArgs e)
        {
            int val;
            while((val = _port.ReadByte()) != -1)
            {
                buffer[writePos] = (byte)val;
                writePos = (writePos + 1) % 256;
            }
        }

        public void Send(char[] arr)
        {
            if (_portName == "debug")
            {
                if (arr[2] == 'C')
                {
                    Array.Copy(new byte[51] { 0x2, 0x32, 0x31, 0x31, 0x3D, 0x20, 0x20, 0x20, 0x31, 0x2E, 0x30, 0x20, 0x48, 0x70, 0xD, 0x32, 0x33, 0x31, 0x3D, 0x20, 0x20, 0x20, 0x20, 0x32, 0x2E, 0x30, 0x20, 0x6C, 0x62, 0x66, 0xD, 0x32, 0x30, 0x39, 0x3D, 0x20, 0x20, 0x20, 0x30, 0x2E, 0x31, 0x30, 0x20, 0x6D, 0x70, 0x68, 0xD, 0x17, 0x30, 0x37, 0x24 }, buffer, 51);
                    writePos = 51;
                    readPos = 0;
                }
                if (arr[2] == 'D')
                {
                    Array.Copy(new byte[21] { 0x2, 0x30, 0x31, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, 0x30, 0x30, 0x17, 0x31, 0x35, 0x24 }, buffer, 21);
                    writePos = 51;
                    readPos = 0;
                }
                return;
            }

            if (!_port.IsOpen)
            {
                _port.Open();
            }
            if (!_port.IsOpen)
            {
                return;
            }

            _port.Write(arr.Select(x => (byte)x).ToArray(), 0, arr.Length);
        }

        public string ReadLine()
        {
            if(_portName != "debug" && !_port.IsOpen)
            {
                _port.Open();
            }

            if (writePos == readPos)
                return null;
            return "";
        }

        public int Read()
        {
            if (_portName != "debug" && !_port.IsOpen)
            {
                _port.Open();
            }
            var ret = -1;
            if (writePos != readPos)
            {
                ret = buffer[readPos];
                readPos = (readPos + 1) % 256;
            }
            return ret;
        }

        public void Dispose()
        {
            if(_port != null)
                _port.Close();
        }




    }
}
