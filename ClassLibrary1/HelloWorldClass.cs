using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldClassDLL
{
    public class HelloWorldClass
    {
        public static decimal? FactorialN(int n)
        {
            if (Math.Abs(n) > 27) return null;

            decimal? _n = n;

            if (_n > 0) return _n *= FactorialN((int )_n - 1);

            return 1;
        }

        public static decimal? SummN(int n)
        {
            if (Math.Abs(n) > 2576) return null;

            decimal? _n = n;

            if (_n > 0) return _n += SummN((int)_n - 1);

            return 0;
        }
    }
}
