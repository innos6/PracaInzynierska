using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA._2nd
{
    //Extension methods 
    public static class Extensions
    {

        //dzięki tej metodzie możemy w trybe debug testowo po prostu wypisać sobie jako string chromosom 
        //potrzebne gdyż rozklikiwanie elementów tablicy było męczące
        public static string Stringify(this Chromosome[] arg)
        {
            string result = "";

            foreach (var item in arg)
            {
                result += item.Zadanie;
            }

            return result;
        }
        
        //klonowanie Chromosomu aby otrzymać niezależną instancję 
        public static Chromosome[] CloneChromosome(this Chromosome[] arg)
        {
            Chromosome[] cloned = new Chromosome[arg.Length];

            for (int i = 0; i < arg.Length; i++)
            {
                cloned[i] = new Chromosome(arg[i]);
            }

            return cloned;
        }
 

        //klonowanie populacji dla otrzymania niezależnych instancji
        public static List<Chromosome[]> CloneChromosomeList(this List<Chromosome[]> arg)
        {
            List<Chromosome[]> cloned = new List<Chromosome[]>();

            foreach (var item in arg)
            {
                cloned.Add(item.CloneChromosome());
            }

            return cloned;
        }
    }
}
