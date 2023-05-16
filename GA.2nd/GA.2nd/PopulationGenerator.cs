using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA._2nd
{
    //generator losowego chromosomu
    public static class PopulationGenerator
    {
        public static Chromosome[] GetChromosome(string zadania)
        {
            Chromosome[] result = new Chromosome[zadania.Length];
            string temp = "";
            List<int> pozycjeDoLosowania = new List<int>();
            for (int i = 0; i < zadania.Length; i++)
            {
                pozycjeDoLosowania.Add(i);
            }
            for (int i = 0; i < zadania.Length; i++)
            {
                var buffer = wylosuj(pozycjeDoLosowania);
                temp += zadania[buffer];
                result[i] = new Chromosome (zadania[buffer], ileIndex(temp, zadania[buffer]));
                pozycjeDoLosowania.Remove(buffer);
            }

            return result;
        }

        private static int ileIndex(string x, char y)
        {
            return x.Count(z => z == y);
        }

        private static int wylosuj(List<int> pozostale)
        {
            Random r = new Random();
            return pozostale[r.Next(0, pozostale.Count)];
        }

    }
}
