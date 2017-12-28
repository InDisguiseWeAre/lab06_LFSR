using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lfsr
{
    class lfsr
    {
        private int regLen { get; set; }
        public int size { get; set; }
        private string pol;

        public bool[] reg;
        private bool[] regCopy;

        public lfsr(int size, string polynom, bool[] start)
        {
            regLen = size;
            this.size = regLen;
            pol = polynom;
            reg = new bool[size];
            Array.Copy(start, reg, size);
        }

        private bool f()
        {
            bool res = true;
            int j = 0;

            for (var i = 0; i < regLen; i++)
            {
                if (pol[i] == '1')
                {
                    res = reg[i];
                    j = i;
                    break;
                }
            }

            for (int i = j + 1; i < regLen; i++)
                if (pol[i] == '1')
                    res = res ^ Convert.ToBoolean(reg[i]);
            return res;
        }

        public void next()
        {
            regCopy = new bool[size];
            regCopy[0] = f();
            Array.Copy(reg, 0, regCopy, 1, size - 1);
            reg = new bool[size];
            reg = regCopy;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < size; i++)
                if (reg[i] == true)
                    str += "1";
                else
                    str += "0";
            return str;
        }
    }
}
