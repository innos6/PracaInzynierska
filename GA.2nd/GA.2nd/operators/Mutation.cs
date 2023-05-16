using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA._2nd.operators
{
    public static class Mutation
    {
        
        public static Chromosome[] PBM(Chromosome[] reference)
        {
            var arg = new Chromosome[reference.Length];

            for (int i = 0; i < reference.Length; i++)
            {
                arg[i] = new Chromosome(reference[i]);
            }
            //mutacja po prostu losowo wybiera gen który chcemy przestawić i wstawia go w losowe miejsce

            Random random = new Random();
            int whichSwap = random.Next(0, arg.Length);
            var toSwap = arg[whichSwap];
            var whereInsert = random.Next(0, arg.Length);

            List<Chromosome> buffer = arg.ToList();
            buffer.Remove(toSwap);

            buffer.Insert(whereInsert, toSwap);
            //przenumerowanie indeksów dla otrzymania prawidłowego chromosomu
            int k = 1;
            for (int i = 0; i < buffer.Count; i++)
            {
                if (buffer[i].Zadanie == toSwap.Zadanie)
                {
                    buffer[i].Index = k;
                    k++;
                }
            }

            return buffer.ToArray();
        }
    }
}
