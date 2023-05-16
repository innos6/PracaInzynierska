[Serializable]
public class Chromosome
{
    //to tak na prawdę powinno nazywać się genem bo chromosom to tablica genów, zostanie zmienione
    //2 pola - zadanie (z kórego zadania pochodzi operacja), index (która to operacja danego zadania)
    public Chromosome(char zadanie, int index)
    {
        Zadanie = zadanie;
        Index = index;
    }

    //konstruktor kopiujący
    public Chromosome(Chromosome arg)
    {
        Zadanie = arg.Zadanie;
        Index = arg.Index;
    }


    public char Zadanie { get; set; }
    public int Index { get; set; }
}