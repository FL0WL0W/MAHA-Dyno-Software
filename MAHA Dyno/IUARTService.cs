using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAHA_Dyno
{
    public interface IUARTService
    {
        void Send(char[] arr);
        string ReadLine();
        int Read();
    }
}
