using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeineLibFürsTesten
{
    public class Taschenrechner
    {
        public int Add(int z1, int z2)
        {
            return checked(z1 + z2);
        }
    }
}
