using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spirals
{
    public class MathX
    {

        public static int LCM(int a, int b)
        {

            return a * b / GCD(a, b);

        }


        public static int LCM2(int a, int b)
        {
            int aV = a;
            int bV = b;

            while (aV != bV)
            {
                if (aV > bV)
                {
                    bV += b;
                }
                else
                {
                    aV += a;
                }
            }
            return aV;
        }

        public static int GCD(int a, int b)
        {
            int Remainder;

            while (b != 0)
            {
                Remainder = a % b;
                a = b;
                b = Remainder;
            }

            return a;
        }

    }
}
