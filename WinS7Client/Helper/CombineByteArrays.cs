using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinS7Client.Helper
{
    class CombineByteArrays
    {
        public static byte[] Combine(byte[] first, byte[] second, byte[] third, byte[] fourth, byte[] fifth)
        {
            byte[] ret = new byte[first.Length + second.Length + third.Length + fourth.Length + fifth.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            Buffer.BlockCopy(third, 0, ret, first.Length + second.Length, third.Length);
            Buffer.BlockCopy(fourth, 0, ret, first.Length + second.Length + third.Length, fourth.Length);
            Buffer.BlockCopy(fifth, 0, ret, first.Length + second.Length + third.Length + fourth.Length, fifth.Length);
            return ret;
        }
    }
}
