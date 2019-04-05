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
        string path = "";

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

        public MainWindowViewModel()
        {
            path = Properties.Settings.Default.Path;

            if (!Directory.Exists(path))
            {
                Console.WriteLine("directory not found");

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
    }
}
