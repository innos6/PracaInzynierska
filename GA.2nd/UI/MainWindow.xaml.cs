using DlhSoft.Windows.Controls;
using GA._2nd;
using GA._2nd.operators;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI.Models;

namespace UI
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel VM { get; set; }

        //główne okno aplikacji
        public MainWindow()
        {
            InitializeComponent();
            
            //zainicjalizowany viewModel dla głównego okna
            VM = new MainWindowViewModel();

            //subskrybcja na event publikujący w logu 
            OnNewLog += VM.OnNewLogAppear;
            //przypisanie VM do okna
            this.DataContext = VM;

            var rnd = new Random();

        }

        private void printLine(int arg, Char[] data)
        {
            Char[] temp = data; //8 5 5 13 3 14 8

            temp[temp.Length-1] = 'X';

            for (int i = 0; i < temp.Length; i++)
            {
                var symbol = temp[i];
                if(symbol == 'X') { break; }
                int lenght = 0;
                for (int j = i; temp[j] == symbol && symbol!='X'; j++)
                {
                    lenght++;
                }
                i += lenght-1;
                //30 18 31  29 13 30 30
                if(symbol == 'Z') { continue; }

                var rect = new Rectangle();

                var label = new Label();
                label.Content = symbol;
                label.VerticalAlignment = VerticalAlignment.Top;
                label.FontSize = 12;
                label.HorizontalAlignment = HorizontalAlignment.Left;
                label.Margin = new Thickness((i - lenght)+(lenght/2)-8 , arg * 30-2, 0, 0);

                rect.Height = 20;
                rect.Width = lenght;
                SolidColorBrush blueBrush = new SolidColorBrush();
                blueBrush.Color = Colors.White;
                SolidColorBrush blackBrush = new SolidColorBrush();
                blackBrush.Color = Colors.Black;
                rect.StrokeThickness = 1;
                rect.Stroke = blackBrush; 
                rect.Fill = blueBrush; 
                rect.HorizontalAlignment = HorizontalAlignment.Left;
                rect.VerticalAlignment = VerticalAlignment.Top;
                rect.Margin = new Thickness(i-lenght, arg * 30, 0, 0);

                myGrid.Children.Add(rect);
                myGrid.Children.Add(label);
            }
        }

        public static RenderTargetBitmap GetImage(Grid view)
        {
            Size size = new Size(view.ActualWidth, view.ActualHeight);
            if (size.IsEmpty)
                return null;

            RenderTargetBitmap result = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);

            DrawingVisual drawingvisual = new DrawingVisual();
            using (DrawingContext context = drawingvisual.RenderOpen())
            {
                context.DrawRectangle(new VisualBrush(view), null, new Rect(new Point(), size));
                context.Close();
            }

            result.Render(drawingvisual);
            return result;
        }

        private static void SaveUsingEncoder(string fileName, RenderTargetBitmap bitmap)
        {
            var encoder = new BmpBitmapEncoder();
            BitmapFrame frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);

            using (var stream = File.Create(fileName))
            {
                encoder.Save(stream);
            }
        }

        //funkcja drukująca rozwiązanie w gridzie na interfejsie, działa tak samo jak fitness (buduje harmonogram) ale dodatkowo drukuje
        int PrintSolution(Chromosome[] arg, Chromosom chromosome)
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

            myGrid.Children.Clear();

            osMaszyny[] harmonogram = new osMaszyny[ileMaszyn];

            for (int i = 0; i < ileMaszyn; i++)
            {
                harmonogram[i] = new osMaszyny(i + 1);
            }
            foreach (var item in arg)
            {
                var operacja = chromosome.Geny.FirstOrDefault(x => x.NrZadania == item.Zadanie)?.Operacje.FirstOrDefault(x => x.NrOperacji == item.Index);
                var osWymagana = harmonogram.FirstOrDefault(x => x.Numer == operacja?.NrMaszyny);

                int odKadZaczac = 0;


                foreach (var os in harmonogram)
                {
                    for (int k = 0; k < os.jednostki.Length; k++)
                    {
                        if (os.jednostki[k] == operacja?.NrZadania && k > odKadZaczac) odKadZaczac = k;
                    }
                }

                int odKadZaczac2 = 0;

                int licznikWolnychMiejsc = 0;
                int pomocnik = 0;

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

            foreach (var os in harmonogram)
            {
                for (int i = os.jednostki.Length - 1; i > 0; i--)
                {
                    if (os.jednostki[i] != 'Z') { dlugosciOsi.Add(i); break; }
                }
            }
            int w = 1;
            foreach (var item in harmonogram)
            {
                printLine(w, item.jednostki);
                w++;
            }
            myGrid.Visibility = Visibility.Visible;
            myImage.Source =  ScreenCapture.SaveToPng(myGrid);
            myGrid.Visibility = Visibility.Hidden;
            return dlugosciOsi.Max();
        }

        //metoda dla drukowania harmonogramu, jedno wywołanie to jedna kreska (jednostka czasu)
        void paintLine(int q, int z, SolidColorBrush color)
        {
            var myLine = new Line();
            myLine.Fill = System.Windows.Media.Brushes.Black;
            myLine.X1 = 10 + q;
            myLine.X2 = 10 + q;
            myLine.Y1 = 10 + (z * 20);
            myLine.Y2 = 30 + (z * 20);
            myLine.StrokeThickness = 2;
            myLine.Stroke = color;
            myLine.Opacity = 1;
            //myLine.Width = 2;
            myGrid.Children.Add(myLine);
        }

        //metoda poszukiwania rozwiązania
        private async void RozpocznijClicked(object sender, RoutedEventArgs e)
        {
            VM.IsRozpocznijEnabled = false;
            await Task.Run(async () => {
                //miejsce w pamięci dla pierwszej populacji
                List<Chromosome[]> population = new List<Chromosome[]>();

                //dane wejściowe
                var chromosome = VM.Data;

                //TEST - tutaj zapiszemy geny (operacje) testowo dla podejrzenia w trybie debug 
                List<Operacja> geny = new List<Operacja>();

                //pula genów 
                string wszystkieGeny = "";

                foreach (var item in chromosome.Geny)
                {
                    foreach (var item2 in item.Operacje)
                    {
                        wszystkieGeny += item2.NrZadania;
                        geny.Add(item2);
                    }
                }


                //inicjalizacja pierwotnej populacji w sposób losowy 
                for (int i = 0; i < VM.PopulationSizeValue; i++)
                {
                    population.Add(PopulationGenerator.GetChromosome(wszystkieGeny));
                }

                //kopia dla ograniczenia ryzyka nadpisania danych przez referencje
                List<Chromosome[]> populationBuffer = population.CloneChromosomeList();

                //główna pętla poszkująca rezltatu 
                do
                {
                    //warunek przerwania (pauzy) jeśli chcemy wstrzymac poszukiwanie
                    if (!VM.SearchPaused)
                    {
                        //metoda oceni populację, drugim argumentem są dane wsadowe - zwraca nową populację oraz najlepszy wynik aktualnej
                        var res = await test(populationBuffer, chromosome);
                        //kolekcja którą otrzymaliśmy jest uporządkowana od najlepszego rezultatu dlatego do pola VM przypisujemy zerowy element
                        //będzie można go wydrukować w dowolnym momencie
                        VM.BestSolution = res.Item1[0].CloneChromosome();

                        var count = VM.BestResult.Count();

                        var ChartItemBest = new ChartItem { Generation = count + 1, Fitness = res.Item2 };
                        var ChartItemAverage = new ChartItem { Generation = count + 1, Fitness = res.Item3 };

                        chart.Dispatcher.Invoke(() =>
                        {
                            VM.BestResult.Add(ChartItemBest);
                            VM.AverageResult.Add(ChartItemAverage);
                        });

                        var wynik = $"{res.Item2.ToString()} | średnia : {res.Item3}";

                        //nowa populacja trafia do bufora aby rekurencyjnie powtórzyć działanie algorytmu poszukującego
                        populationBuffer = res.Item1.CloneChromosomeList();


                        //publikujemy event zapisujący w logu aktualnie najlepsze rozwiązanie
                        OnNewLog?.Invoke(this, new NewLogApearEventArgs { 
                            Body = wynik,
                            ChartItemBest = new ChartItem { Generation = count + 1, Fitness = res.Item2 },
                            ChartItemAverage = new ChartItem { Generation = count + 1, Fitness = res.Item3 }
                        });
                        
                    }
                } while (true);

            });
            
        }

        public int i { get; set; }

        public delegate void OnNewLogEventHandler(object sender, NewLogApearEventArgs e);

        public event OnNewLogEventHandler OnNewLog;

        


        private async Task<Tuple<List<Chromosome[]>, int, int>> test(List<Chromosome[]> population, Chromosom chromosome)
        {
            //TEST - kontrolne sprawdzenie w trybie debug aby upewnić się, że nie mamy tej samej populacji co poprzednio
            var checksum = GA._2nd.Utils.Tools.ComputeChecksum(population);

            var test = new List<string>();
            var fitnessRes = new List<int>();

            //ocena populacji
            var results = await Fitness.RatePupulation(population, chromosome);

 
            foreach (var item in results)
            {
                fitnessRes.Add(item.Value);
            }

            //uporządkowanie od najlepiej przystosowanego do najgorzej 
            var ordered = results.OrderBy(x => x.Value).ToList();

            //wybieramy 2% najlepszych osobników do nowej populacji (sukcesja czystoelitarna)
            var selected = new List<Chromosome[]>();
            for (int i = 0; i < (2 * population.Count)/100; i++)
            {
                selected.Add(population[ordered[i].Key].CloneChromosome());
            }

            Random rnd = new Random();

            //selekcja turniejowa pozostałych 18%  rodziców którzy utworzą nowe pokolenie
            for (int i = 0; i < (18*population.Count)/100; i++)
            {
                List<Chromosome[]> tournamentPopulation = new List<Chromosome[]>();
                int tSize = rnd.Next(2, 4);
                for(int j = 0; j < tSize; j++)
                {
                    tournamentPopulation.Add(population[rnd.Next(0, population.Count)]);
                }
                var result = Fitness.RatePupulation(tournamentPopulation, chromosome).Result.OrderBy(x => x.Value).ToList();
                var winner = tournamentPopulation[result[0].Key].CloneChromosome();
                selected.Add(winner);
            }




            //pozostałych 80 osobników otrzymujemy poprzez krzyżowanie
            for (int i = 0; i < (80* population.Count)/100; i++)
            {
                //edit po refactoringu metody selekcji najlepiej działa właśnie zastosowanie obu operatorów
                var t = i % 2 == 0 ? 
                    Crossover.GOX(selected[rnd.Next(0, (20* population.Count) / 100)], selected[rnd.Next(0, (20 * population.Count) / 100)]) : 
                    Crossover.PPX(selected[rnd.Next(0, (20 * population.Count) / 100)], selected[rnd.Next(0, (20 * population.Count) / 100)]);


                var matches = new List<int>();

                for (int j = 0; j < VM.MutationFrequency; j++)
                {
                    matches.Add(rnd.Next(0, 100));
                }

                //wprowadzono mutację z szansą zadaną przez użytkownika
                if (matches.Contains(rnd.Next(0, 100)))
                {
                    var mutated = Mutation.PBM(t);
                    selected.Add(mutated);
                }
                else
                {
                    selected.Add(t);
                }
            }



            //najlepsze i najgorsze rozwiązanie z początkowej populacji
            var max = fitnessRes.Max();
            var min = fitnessRes.Min();
            var srednia = fitnessRes.Sum()/fitnessRes.Count;
            //zwracamy nową populację aby rekurencyjnie powtórzyć działanie oraz najlepszy wynik
            return new Tuple<List<Chromosome[]>, int, int> (selected, min, srednia);
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            if(VM.PauseButtonCaption == "Pause")
            {
                VM.PauseButtonCaption = "Resume";
            }
            else
            {
                VM.PauseButtonCaption = "Pause";
            }

            VM.SearchPaused = !VM.SearchPaused;
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            var test = VM.BestSolution.Stringify();
            PrintSolution(VM.BestSolution, VM.Data);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    VM.FilePath = openFileDialog.FileName;
                    VM.Dane = File.ReadAllText(openFileDialog.FileName);
                    VM.Data = new Chromosom(VM.Dane);
                } 
        }
    }
}
