using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA._2nd
{
    public class osMaszyny2
    {
        public osMaszyny2(int nr)
        {
            this.Numer = nr;
            this.jednostki = new List<char>();
        }


        public int Numer { get; set; }
        public List<char> jednostki { get; set; }
    }
}
