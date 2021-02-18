using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;

namespace MAHA_Dyno
{
    public class UARTLogService : IUARTService
    {
        public string Log = "";
        private IUARTService _wrapped;
        private void LogWrite(char c)
        {
            //Log = "TX: 0x" + ((byte)c).ToString("X") + " " + CharBits(c) + "\n" + Log;
        }
        private void LogRead(char c)
        {
            //Log = "RX: 0x" + ((byte)c).ToString("X") + " " + CharBits(c) + "\n" + Log;
            //Log += c;
        }
        private string CharBits(char c)
        {
            var ret = "";
            for(int i = 7; i >= 0; i--)
            {
                if (((c >> i) & 1) > 0)
                    ret += "1";
                else
                    ret += "0";
            }
            return ret;
        }

        public UARTLogService(IUARTService wrapped)
        {
            _wrapped = wrapped;
        }

        public void Send(char[] arr)
        {
            _wrapped.Send(arr);

            foreach(char c in arr)
            {
                LogWrite(c);
            }
        }

        public string ReadLine()
        {
            var ret = _wrapped.ReadLine();

            foreach (char c in ret)
            {
                LogRead(c);
            }

            return ret;
        }

        public int Read()
        {
            var t = _wrapped.Read();

            if(t != -1)
            {
                LogRead((char)t);
            }

            return t;
        }
    }
}
