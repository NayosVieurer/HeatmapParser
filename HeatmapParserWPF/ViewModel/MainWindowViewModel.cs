using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.ComponentModel;
using System.Windows.Data;

namespace HeatmapParserWPF
{
    class MainWindowViewModel : ViewModelBase
    {
        public string path { get; set; }

        public ObservableCollection<GameViewModel> Games { get; }
            
        private ICollectionView collectionView;

        public GameViewModel selectedGame
        {
            get
            {
                return collectionView.CurrentItem as GameViewModel;
            }
        }

        private ObservableCollection<string> floorsList;

        public CustomCommand increaseCommand { get; set; }

        public CustomCommand decreaseCommand { get; set; }

        public MainWindowViewModel()
        {
            path = Properties.Settings.Default.Path;

            if (!Directory.Exists(path))
            {

                PathInput dialog;

                do
                {
                    dialog = new PathInput("The heatmap folder was not found. Please enter a valid path : ");

                    if (dialog.ShowDialog() == true)
                    {
                        path = dialog.answer;
                    }
                } while (!Directory.Exists(path));
            }

            increaseCommand = new CustomCommand(() => Increase(), () => CanUpdateTimeline());

            decreaseCommand = new CustomCommand(() => Decrease(), () => CanUpdateTimeline());

            floorsList = new ObservableCollection<string>();

            foreach(string s in Directory.GetFiles(path + "\\GeneralsDatas", "*.png"))
            {
                floorsList.Add(Path.GetFileNameWithoutExtension(s));
            }

            Games = new ObservableCollection<GameViewModel>();

            foreach(string day in Directory.GetDirectories(path))
            {
                if(Path.GetFileName(day) == "GeneralsDatas")
                {
                    continue;
                }

                Games.Add(new GameViewModel(day, floorsList));
            }

            collectionView = CollectionViewSource.GetDefaultView(Games);

            if(collectionView == null)
            {
                throw new NullReferenceException("CollectionView");
            }

            collectionView.CurrentChanged += new EventHandler(OnCollectionViewCurrentChanged);
        }

        private void OnCollectionViewCurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("selectedGame");
        }

        private bool CanUpdateTimeline()
        {
            if(selectedGame == null && selectedGame.CanUpdateTimeline())
            {
                return false;
            }

            return true;
        }

        private void Increase()
        {
            Console.WriteLine("Increase");
            selectedGame.Increase();
        }

        private void Decrease()
        {
            Console.WriteLine("Decrease");
            selectedGame.Decrease();
        }
    }
}
