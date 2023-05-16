using GA._2nd;

//PROGRAM KONSOLOWY TYLKO DO CELÓW TESTOWYCH NA WCZESNYM ETAPIE PROJEKTOWANIA
//NA TEN MOMENT NIE UŻYWANY WCALE, ZACZYNAMY OD PROJEKTU WPF

var rnd = new Random();


List<Operacja> geny = new List<Operacja>();

string wszystkieGeny = "";


Chromosome[] wylosujGenom(string zadania)
{
    Chromosome[] result = new Chromosome[50];
    string temp = "";
    List<int> pozycjeDoLosowania = new List<int>();
    for (int i = 0; i < 50; i++)
    {
        pozycjeDoLosowania.Add(i);
    }
    for (int i = 0; i < 50; i++)
    {
        var buffer = wylosuj(pozycjeDoLosowania);
        temp += zadania[buffer];
        result[i] = new Chromosome (zadania[buffer] , ileIndex(temp, zadania[buffer]));
        pozycjeDoLosowania.Remove(buffer);
    }

    return result;
}

int ileIndex(string x, char y)
{
    return x.Count(z => z == y);
}


int wylosuj(List<int> pozostale)
{
    Random r = new Random();
    return pozostale[r.Next(0, pozostale.Count)];
}

void printChromosomeInConsole(Chromosome[] arg)
{
    foreach (var item in arg)
    {
        Console.Write($"{item.Zadanie} ");
    }
    Console.WriteLine();
    foreach (var item in arg)
    {
        if (item.Index > 9)
        {
            Console.Write(item.Index);
        }
        else
        {
            Console.Write($"{item.Index} ");
        }
    }
    Console.WriteLine();
    Console.WriteLine();
}

int best = 2000;

//for (int i = 0; i < 100; i++)
//{
//    var p = wylosujGenom(wszystkieGeny);
//    //printChromosomeInConsole(p);
//    var res = fitness(p);
//    Console.WriteLine(res);
//    best = res < best ? res : best;
//}
//Console.WriteLine(best);

//int fitness(Chromosome[] arg)
//{
//    osMaszyny[] harmonogram = new osMaszyny[9];

//    for (int i = 0; i < 9; i++)
//    {
//        harmonogram[i] = new osMaszyny(i + 1);
//    }
//    foreach (var item in arg)
//    {
//        var operacja = chromosome.Geny.FirstOrDefault(x => x.NrZadania == item.Zadanie)?.Operacje.FirstOrDefault(x=>x.NrOperacji == item.Index);
//        var osWymagana = harmonogram.FirstOrDefault(x => x.Numer == operacja?.NrMaszyny);

//        int odKadZaczac = 0;


//        foreach (var os in harmonogram)
//        {
//            for (int k = 0; k < os.jednostki.Length; k++)
//            {
//                if (os.jednostki[k] == operacja?.NrZadania && k > odKadZaczac) odKadZaczac = k;
//            }
//        }

//        int odKadZaczac2 = 0;

//        int licznikWolnychMiejsc = 0;
//        int pomocnik = 0;

//        for (int k = 0; k < osWymagana?.jednostki.Length; k++)
//        {
//            if(licznikWolnychMiejsc == operacja?.Czas) { odKadZaczac2 = pomocnik; break; }

//            if (osWymagana.jednostki[k] == 'Z')
//            {
//                licznikWolnychMiejsc++;
//            }
//            else 
//            {
//                pomocnik = k;
//                licznikWolnychMiejsc = 0;
//            }
//        }

//        int pozycja = odKadZaczac >= odKadZaczac2 ? odKadZaczac : odKadZaczac2;

//        for (int l = 0; l < operacja?.Czas; l++)
//        {
//            osWymagana.jednostki[l + pozycja] = operacja.NrZadania;
//        }
//    }

//    List<int> dlugosciOsi = new List<int>();

//    foreach (var os in harmonogram)
//    {
//        for (int i = os.jednostki.Length-1; i > 0; i--)
//        {
//            if (os.jednostki[i] != 'Z') { dlugosciOsi.Add(i); break; }
//        }
//    }

//    foreach (var item in harmonogram)
//    {
//        foreach (var item2 in item.jednostki)
//        {
//            Console.Write(item2 =='Z'? ' ' : item2);
//        }
//        Console.WriteLine();
//    }
//    return dlugosciOsi.Max();
//}
