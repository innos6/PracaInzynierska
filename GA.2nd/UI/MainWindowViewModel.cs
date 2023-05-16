using GA._2nd;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UI.Models;

namespace UI
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public Chromosom Data { get; set; }



        public MainWindowViewModel()
        {
            LogLines = "";
            PopulationSizeValue = 100;
            mutex = new SemaphoreSlim(1);
            Data = new Chromosom(1);

            BestResult = new ObservableCollection<ChartItem>();
            AverageResult = new ObservableCollection<ChartItem>();
            IsRozpocznijEnabled = true;
            PauseButtonCaption = "Pause";
            //test1 = new ObservableCollection<ChartItem>();
            //test2 = new ObservableCollection<ChartItem>();


            //AverageResult.CollectionChanged += (sender, arg) =>
            //{
            //    foreach (var item in arg.NewItems)
            //    {
            //        test1.Add((ChartItem)item);
            //    }
            //};
            //BestResult.CollectionChanged += (sender, arg) =>
            //{
            //    foreach (var item in arg.NewItems)
            //    {
            //        test2.Add((ChartItem)item);
            //    }
            //};
        }

        //public ObservableCollection<ChartItem> test1 { get; set; }

        //public ObservableCollection<ChartItem> test2 { get; set; }

        private string filePath;

        public string FilePath 
        {
            get
            {
                return filePath;
            }
            set
            {
                filePath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilePath)));
            }
        }


        private string dane;

        public string Dane
        {
            get
            {
                return dane;
            }
            set
            {
                dane = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Dane)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilePath)));
            }
        }




        private int mutationFrequency;

        public int MutationFrequency
        {
            get
            {
                return mutationFrequency;
            }
            set
            {
                mutationFrequency = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MutationFrequency)));
            }
        }

        private int populationSizeValue;

        public int PopulationSizeValue
        {
            get 
            {
                return populationSizeValue; 
            }
            set 
            {
                populationSizeValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PopulationSizeValue)));
            }
        }


        private bool searchPaused;

        public bool SearchPaused 
        {
            get 
            {
                return searchPaused;
            }
            set 
            {
                searchPaused = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchPaused)));
            }
        }

        private Chromosome[] bestSolution;

        public Chromosome[] BestSolution
        {
            get { return bestSolution; }
            set
            {
                bestSolution = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BestSolution)));
            }
        }



        public SemaphoreSlim mutex { get; set; }



        public virtual async void OnNewLogAppear(object sender, NewLogApearEventArgs e)
        {
            Generation++;
            await mutex.WaitAsync();
            LogLines = $"Wynik {e.Body} w {Generation} pokoleniu.";
            
            mutex.Release();
        }

        private int Generation;


        private bool isRozpocznijEnabled;

        public bool IsRozpocznijEnabled
        {
            get
            {
                return isRozpocznijEnabled;
            }
            set
            {
                isRozpocznijEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRozpocznijEnabled)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsPauseEnabled)));
            }
        }

        private string pauseButtonCaption;

        public string PauseButtonCaption
        {
            get
            {
                return pauseButtonCaption;
            }
            set
            {
                pauseButtonCaption = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PauseButtonCaption)));
            }
        }



        public bool IsPauseEnabled
        {
            get
            {
                return !IsRozpocznijEnabled;
            }
        }


        private string? logLines;
        public string? LogLines {
            get
            {
                return logLines;
            }
            set 
            { 
                logLines = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LogLines)));
            }
        }

        private ObservableCollection<ChartItem> bestResult;
        private ObservableCollection<ChartItem> averageResult;


        public ObservableCollection<ChartItem> BestResult
        {
            get
            {
                return bestResult;
            }
            set
            {
                bestResult = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BestResult)));
            }
        }

        public ObservableCollection<ChartItem> AverageResult
        {
            get
            {
                return averageResult;
            }
            set
            {
                averageResult = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AverageResult)));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
