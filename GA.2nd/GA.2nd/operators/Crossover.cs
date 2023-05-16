using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA._2nd.operators
{
    public static class Crossover
    {
        //generalised order crossover

        public static Chromosome[] GOX(Chromosome[] arg1, Chromosome[] arg2)
        {
            Chromosome[] parent1 = arg1.CloneChromosome();
            Chromosome[] parent2 = arg2.CloneChromosome();

            


            //result to return
            List<Chromosome> resultList = new List<Chromosome>();

            //flag signalize which result assembly method to choose
            bool isSplitSample = false;

            Random rnd = new Random();

            //select random place to insert sample from parent 2 to parent 1
            var splitAfterPosition = rnd.Next(0, arg1.Length+1);

            //pointers to assign parent 1 sides after split 
            Chromosome[] leftAfterSplit;
            Chromosome[] rightAfterSplit;


            //counters fo each side of sample after splitting
            int rightSideCount = 0;
            int leftSideCount = 0;

            //selects random lenght of sample from parent 2
            var lenghtOfSample = rnd.Next(arg1.Length/3, arg1.Length/2);


            Chromosome[] sample = new Chromosome[lenghtOfSample];

            //randomly selects place where method starts to pick sample
            var startPointSample = rnd.Next(0, arg1.Length);


            //building sample
            for (int i = 0; i < lenghtOfSample; i++)
            {
                if (startPointSample + i < parent2.Length)
                {
                    sample[i] = parent2[startPointSample + i];
                    rightSideCount++;
                }
                else
                {
                    //if sample includes end of parent 2, split it
                    isSplitSample = true;
                    sample[i] = parent2[(startPointSample + i) - parent1.Length];
                    leftSideCount++;
                }
            }


            Chromosome[] buffer = new Chromosome[parent1.Length + lenghtOfSample];


            //building result

            
            if (!isSplitSample)
            {
                //jeśli próbkę mamy w całości ta część algorytmu stworzy potomka wstawiając w całości
                //w wylosowane miejsce pobrany fragment i usunie powtórzenia 
                int leftCount = splitAfterPosition;
                int rightCount = parent1.Length - splitAfterPosition;
                leftAfterSplit = new Chromosome[leftCount];
                rightAfterSplit = new Chromosome[rightCount];
                for (int i = 0; i < parent1.Length; i++)
                {
                    if (i < splitAfterPosition)
                    {
                        leftAfterSplit[i] = parent1[i];
                    }
                    else
                    {
                        rightAfterSplit[i - leftAfterSplit.Length] = parent1[i];
                    }
                }

                for (int i = 0; i < buffer.Length; i++)
                {
                    if (i < leftAfterSplit.Length)
                    {
                        buffer[i] = leftAfterSplit[i];
                        if(!sample.ToList().Any(x=>x.Index == buffer[i].Index && x.Zadanie == buffer[i].Zadanie))
                            resultList.Add(buffer[i]);
                    }
                    else if (i >= leftAfterSplit.Length && i < leftAfterSplit.Length + sample.Length)
                    {
                        buffer[i] = sample[i - leftAfterSplit.Length];
                        resultList.Add(buffer[i]);
                    }
                    else
                    {
                        buffer[i] = rightAfterSplit[i - leftAfterSplit.Length - sample.Length];
                        if (!sample.ToList().Any(x => x.Index == buffer[i].Index && x.Zadanie == buffer[i].Zadanie))
                            resultList.Add(buffer[i]);
                    }
                }
            }
            else
            {
                //jeśli jednak pobrany fragment jest z końca i początku chromosomu 
                //to lewą część dajemy na początek, do środka rodzic z usuniętymi powtórzeniami i prawa część na koniec
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (i < leftSideCount)
                    {
                        buffer[i] = sample[i];
                        resultList.Add(buffer[i]);
                    }
                    else if (i >= leftSideCount && i < leftSideCount + parent1.Length)
                    {
                        buffer[i] = parent1[i-leftSideCount];
                        if (!sample.ToList().Any(x => x.Index == buffer[i].Index && x.Zadanie == buffer[i].Zadanie))
                            resultList.Add(buffer[i]);
                    }
                }
                for (int i = 0; i < rightSideCount; i++)
                {
                    buffer[leftSideCount + parent1.Length + i] = sample[leftSideCount + i];
                    resultList.Add(buffer[leftSideCount + parent1.Length + i]);
                }
            }
             

            //przenumerowanie indeksów dla otrzymania prawidłowego chromosomu
            foreach (var item in resultList.Select(x => x.Zadanie).Distinct())
            {
                int k = 1;
                for (int i = 0; i < resultList.Count; i++)
                {
                    if (resultList[i].Zadanie == item)
                    {
                        resultList[i].Index = k;
                        k++;
                    }
                }
            }

            return resultList.ToArray();
        }

        public static Chromosome[] PPX(Chromosome[] arg1, Chromosome[] arg2)
        {
            var parent1List = arg1.CloneChromosome().ToList();
            var parent2List = arg2.CloneChromosome().ToList();



            Chromosome[] result = new Chromosome[arg1.Length];

            Random rnd = new Random();

            int[] vector = new int[arg1.Length];
            //losujemy wektor z 1 i 2 o długości naszego chromosomu wejściowego
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = rnd.Next(1, 3);
            }

            //dla każdego elementu wektora wybieramy gen z chromosomu rodzica (którego wskazuje element wektora)
            //gen ten jest usuwany z obu rodziców aby uniknąć powtórzeń
            for (int i = 0; i < vector.Length; i++)
            {
                switch (vector[i])
                {
                    case 1:
                        {
                            var insert = new Chromosome(parent1List.First());
                            parent1List.RemoveAt(0);
                            var toRemove = parent2List.FirstOrDefault(x => x.Zadanie == insert.Zadanie && x.Index == insert.Index);
                            parent2List.Remove(toRemove);

                            result[i] = insert;
                            break;
                        }
                    case 2:
                        {
                            var insert = new Chromosome(parent2List.First());
                            parent2List.RemoveAt(0);
                            var toRemove = parent1List.FirstOrDefault(x => x.Zadanie == insert.Zadanie && x.Index == insert.Index);
                            parent1List.Remove(toRemove);

                            result[i] = insert; 
                            break;
                        }
                    default:
                        break;
                }
            }
            //przenumerowanie indeksów dla otrzymania prawidłowego chromosomu
            foreach (var item in result.Select(x => x.Zadanie).Distinct())
            {
                int k = 1;
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i].Zadanie == item)
                    {
                        result[i].Index = k;
                        k++;
                    }
                }
            }

            return result;
        }
    }
}
