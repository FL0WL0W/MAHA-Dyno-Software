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
        protected SerialPort _port;
        protected Stream _stream;
        private StreamWriter _streamWriter;
        private StreamReader _streamReader;

        public COMPortService(string port, int baudRate)
        {
            _port = new SerialPort(port, baudRate, Parity.None, 8, StopBits.One);
            _port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            _port.Open();
            _stream = new MemoryStream();
            _streamWriter = new StreamWriter(_stream);
            _streamReader = new StreamReader(_stream);
        }

        private void port_DataReceived(object sender,
          SerialDataReceivedEventArgs e)
        {
            var val = _port.ReadExisting();
            _streamWriter.Write(val);
        }
        public void Send(string val)
        {
            if (!_port.IsOpen)
            {
                _port.Open();
            }
            if (!_port.IsOpen)
            {
                return;
            }

            _port.Write(val);
        }

        public string ReadLine()
        {
            if (!_port.IsOpen)
            {
                _port.Open();
            }
            
            return _streamReader.ReadLine();
        }

        public int Read()
        {
            if (!_port.IsOpen)
            {
                _port.Open();
            }
            
            return _streamReader.Read();
        }

        public void Dispose()
        {
            _stream.Close();
            _port.Close();
        }
    }
}
