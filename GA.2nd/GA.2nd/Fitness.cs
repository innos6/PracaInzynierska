using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA._2nd
{
    public static class Fitness
    {
        //funkcja dopasowania
        public static int Check(Chromosome[] arg, Chromosom chromosome)
        {
            List<int> maszyny = new List<int>();
            var operacje = chromosome.Geny.Select(x => x.Operacje);
            foreach (var operacja in operacje)
            {
                var maszynyOperacji = operacja.Select(x => x.NrMaszyny);
                foreach (var maszynaOperacji in maszynyOperacji)
                {
                    maszyny.Add(maszynaOperacji);
                }
            }
            int ileMaszyn = maszyny.Max();


            //przestrzeń rozwiązań - liczby zostaną podmienione na zmienne w późniejszym etapie 
            osMaszyny[] harmonogram = new osMaszyny[ileMaszyn];

            for (int i = 0; i < ileMaszyn; i++)
            {
                harmonogram[i] = new osMaszyny(i + 1);
            }

            //dla każdego genu w chromosomie
            foreach (var item in arg)
            {
                //pobieramy za którą operację odpowieda gen
                var operacja = chromosome.Geny.FirstOrDefault(x => x.NrZadania == item.Zadanie)?.Operacje.FirstOrDefault(x => x.NrOperacji == item.Index);
                
                //która maszyna będzie ją wykonywała
                var osWymagana = harmonogram.FirstOrDefault(x => x.Numer == operacja?.NrMaszyny);

                int odKadZaczac = 0;

                //pierwsze kryterium to określenie kiedy zakończyła się poprzednia operacja z naszego zadania
                //w tym celu przepatrujemy wszystkie osie w poszukiwaniu odpowiednich literek
                foreach (var os in harmonogram)
                {
                    for (int k = 0; k < os.jednostki.Length; k++)
                    {
                        if (os.jednostki[k] == operacja?.NrZadania && k > odKadZaczac) odKadZaczac = k;
                    }
                }

                //drugie kryterium to sprawdzenie czy dana maszyna której musimy użyć jest wolna
                int odKadZaczac2 = 0;

                int licznikWolnychMiejsc = 0;
                int pomocnik = 0;

                //dlatego przeszukujemy już konkretną oś która nas interesuje (maszyna) w poszukiwaniu
                //wolnej przestrzeni na naszą operacje - tyle literek 'Z' ile trwa nasza operacja
                for (int k = odKadZaczac; k < osWymagana?.jednostki.Length; k++)
                {
                    if (licznikWolnychMiejsc == operacja?.Czas) { odKadZaczac2 = pomocnik; break; }

                    if (osWymagana.jednostki[k] == 'Z')
                    {
                        licznikWolnychMiejsc++;
                    }
                    else
                    {
                        pomocnik = k;
                        licznikWolnychMiejsc = 0;
                    }
                }

                int pozycja = odKadZaczac >= odKadZaczac2 ? odKadZaczac : odKadZaczac2;

                for (int l = 0; l < operacja?.Czas; l++)
                {
                    osWymagana.jednostki[l + pozycja] = operacja.NrZadania;
                }
            }

            List<int> dlugosciOsi = new List<int>();


            //gdy już mamy wszytkie osie wypełnione czyli każdą operację na harmonogramie sprawdzamy każdą oś od końca
            //dzięk temu wiemy na której maszynie zakończyła się ostatnia operacja ostatniego zadania i możemy zbadać długość
            //ta wartość to czas trwania całego procesu którą zwracamy
            foreach (var os in harmonogram)
            {
                for (int i = os.jednostki.Length - 1; i > 0; i--)
                {
                    if (os.jednostki[i] != 'Z') { dlugosciOsi.Add(i); break; }
                }
            }
            return dlugosciOsi.Max();
        }


        //tutaj asynchronicznie możemy zbadać całą populację gdyż poszczególne osobniki nie są ze sobą powiązane 
        //każda funkcja fitness może być wykonywana równolegle, dzięki temu algorytm przyspieszył o ok 80%
        //zastosowano semafor binarny aby nie było konfliktów wątków w dostępie do rezultatu
        public static async Task<List<KeyValuePair<int, int>>> RatePupulation(List<Chromosome[]> population, Chromosom data)
        {
            SemaphoreSlim mutex = new SemaphoreSlim(1);

            List<Chromosome[]> args = population.CloneChromosomeList();


            List<KeyValuePair<int, int>> result = new List<KeyValuePair<int, int>>();

            Parallel.For(0, args.Count, (i, state) => {
                var buffer = Fitness.Check(args[i], data);
                var t = i;

                mutex.Wait();

                result.Add(new KeyValuePair<int,int>(t, buffer));

                mutex.Release();
            });

            return result;
        }





        public static int Check2(Chromosome[] arg, Chromosom chromosome)
        {
            List<int> maszyny = new List<int>();
            var operacje = chromosome.Geny.Select(x => x.Operacje);
            foreach (var operacja in operacje)
            {
                var maszynyOperacji = operacja.Select(x => x.NrMaszyny);
                foreach (var maszynaOperacji in maszynyOperacji)
                {
                    maszyny.Add(maszynaOperacji);
                }
            }
            int ileMaszyn = maszyny.Max();

            osMaszyny2[] harmonogram2 = new osMaszyny2[ileMaszyn];


            for (int i = 0; i < ileMaszyn; i++)
            {
                harmonogram2[i] = new osMaszyny2(i + 1);
            }

            //dla każdego genu w chromosomie
            foreach (var item in arg)
            {
                //pobieramy za którą operację odpowieda gen
                var operacja = chromosome.Geny.FirstOrDefault(x => x.NrZadania == item.Zadanie)?.Operacje.FirstOrDefault(x => x.NrOperacji == item.Index);

                var osWymagana2 = harmonogram2.FirstOrDefault(x => x.Numer == operacja?.NrMaszyny);

                int odKadZaczac3 = 0;

                
                foreach (var os in harmonogram2)
                {
                    for (int k = 0; k < os.jednostki.Count; k++)
                    {
                        if (os.jednostki[k] == operacja?.NrZadania && k > odKadZaczac3) odKadZaczac3 = k;
                    }
                }


                int odKadZaczac4 = 0;
                int licznikWolnychMiejsc4 = 0;
                int pomocnik4 = 0;

                //dlatego przeszukujemy już konkretną oś która nas interesuje (maszyna) w poszukiwaniu
                //wolnej przestrzeni na naszą operacje - tyle literek 'Z' ile trwa nasza operacja
                for (int k = odKadZaczac3; k < osWymagana2?.jednostki.Count; k++)
                {
                    if (licznikWolnychMiejsc4 == operacja?.Czas) { odKadZaczac4 = pomocnik4; break; }

                    if (osWymagana2.jednostki[k] == 'Z')
                    {
                        licznikWolnychMiejsc4++;
                    }
                    else
                    {
                        pomocnik4 = k;
                        licznikWolnychMiejsc4 = 0;
                    }
                }

                int pozycja2 = odKadZaczac3 >= odKadZaczac4 ? odKadZaczac3 : odKadZaczac4;

                for (int l = 0; l < operacja?.Czas; l++)
                {

                    //osWymagana2.jednostki[l + pozycja2] = operacja.NrZadania;
                    for (int i = 0; i < l + pozycja2; i++)
                    {
                        if (osWymagana2.jednostki.Count < l + pozycja2)
                        {

                            osWymagana2.jednostki.Add(operacja.NrZadania);
                        }
                        else
                        {

                        }
                    }
                }



            }

            List<int> dlugosciOsi = new List<int>();


            //gdy już mamy wszytkie osie wypełnione czyli każdą operację na harmonogramie sprawdzamy każdą oś od końca
            //dzięk temu wiemy na której maszynie zakończyła się ostatnia operacja ostatniego zadania i możemy zbadać długość
            //ta wartość to czas trwania całego procesu którą zwracamy
            foreach (var os in harmonogram2)
            {
                for (int i = os.jednostki.Count - 1; i > 0; i--)
                {
                    if (os.jednostki[i] != 'Z') { dlugosciOsi.Add(i); break; }
                }
            }
            return dlugosciOsi.Max();
        }


    }
}
