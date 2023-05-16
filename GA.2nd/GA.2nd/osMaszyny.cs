public class osMaszyny
{
    //przyjęto tutaj długość 5000 bo taka około była suma wszytkich zadań więc najbardziej pesymistyczny przypadek
    //gdyby żadna operacja nie mogła wykonać się równolegle, w praktyce najgorsze rozwiązania dla rozważanego przykładu to ok 2000 jednostek
    //po analizie innych przyładów z książki ustalimy optymalną max długość harmonogramu aby niepotrzebnie nie zajmować pamięci
    public osMaszyny(int nr)
    {
        this.Numer = nr;
        this.jednostki = new char[3000];
        for (int i = 0; i < jednostki.Length; i++)
        {
            jednostki[i] = 'Z';
        }
    }


    public int Numer { get; set; }
    public char[] jednostki { get; set; }
}
