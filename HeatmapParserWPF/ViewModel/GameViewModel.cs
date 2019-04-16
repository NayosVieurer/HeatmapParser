using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace HeatmapParserWPF
{

    class GameViewModel : ViewModelBase
    {
    #region fields
        private MapType type;

        private ICollectionView roundsCollection;

        private ICollectionView floorsCollection;

        private ICollectionView charactersCollection;

        private Dictionary<string, string> nameConversion;

        private List<Map> maps;

        private Map currentMap;

        private int timelineEnd;
    #endregion

    #region Properties
        public string name { get; set; }

        public string path { get; set; }

        public MapType Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
                OnPropertyChanged("type");
            }
        }

        public ObservableCollection<string> rounds { get; set; }

        public ObservableCollection<string> floors { get; set; }

        public ObservableCollection<string> characters { get; set; }

        public int TimelineEnd
        {
            get
            {
                return timelineEnd;
            }
            set
            {
                timelineEnd = value;
                OnPropertyChanged("timelineEnd");
            }
        }

        public int maxTimeline
        {
            get {
                if(currentMap == null)
                {
                    return 100;
                }
                return currentMap.points.Count;
            }
        }

        public string currentRound
        {
            get
            {
                return roundsCollection.CurrentItem.ToString();
            }
        }

        public string currentIdentifier 
        {
            get
            {
                if (type == MapType.Steps)
                {
                    return charactersCollection.CurrentItem.ToString();
                }

                else if (type == MapType.NONE)
                {
                    return "";
                }
                else
                {
                    string cF = "";

                    foreach (KeyValuePair<string, string> item in nameConversion)
                    {
                        if (item.Value == floorsCollection.CurrentItem.ToString())
                        {
                            cF = item.Key;
                        }
                    }

                    return cF;
                }
            }
        }

        public BitmapSource currentMask
        {
            get
            {
                if (currentMap == null || currentMap.mask == null)
                {
                    return new BitmapImage(new Uri("../Resources/placeholder.png", UriKind.Relative));
                }
                return Imaging.CreateBitmapSourceFromHBitmap(currentMap.mask.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
        }

        public BitmapSource currentImage
        {
            get
            {
                if(currentMap == null || currentMap.referenceImage == null)
                {
                    return new BitmapImage(new Uri("../Resources/placeholder.png", UriKind.Relative));
                }
                return Imaging.CreateBitmapSourceFromHBitmap(currentMap.referenceImage.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
        }

        public CustomCommand IncreaseCommand
        {
            get; set;
        }

        public CustomCommand DecreaseCommand { get; set; }
    #endregion

        public GameViewModel(string p, ObservableCollection<string> _floors)
        {

            type = MapType.NONE;

            path = p;

            GetName();

            IncreaseCommand = new CustomCommand(() => Increase(), () => CanUpdateTimeline());

            DecreaseCommand = new CustomCommand(() => Decrease(), () => CanUpdateTimeline());

            #region Conversion dictionnary
            nameConversion = new Dictionary<string, string>();

            nameConversion.Add("FirstFloor", "Basement");
            nameConversion.Add("SecondFloor", "Ground floor");
            nameConversion.Add("ThirdFloor", "First floor");
            nameConversion.Add("FourthFloor", "Roofs");

            #endregion

            #region List initiazation

            rounds = new ObservableCollection<string>();

            floors = new ObservableCollection<string>();

            characters = new ObservableCollection<string>();

            maps = new List<Map>();

            characters.Add("soldier");
            characters.Add("Scout");
            characters.Add("Trapper");
            characters.Add("Charger");

            foreach (string floor in _floors)
            {
                floors.Add(nameConversion[floor]);
            }

            //rounds.Add("Global");

            foreach(string s in Directory.GetDirectories(p))
            {
                rounds.Add(Path.GetFileName(s));
            }

            #endregion

            #region collections views

            roundsCollection = CollectionViewSource.GetDefaultView(rounds);

            floorsCollection = CollectionViewSource.GetDefaultView(floors);

            charactersCollection = CollectionViewSource.GetDefaultView(characters);

            if (roundsCollection == null)
            {
                throw new NullReferenceException("rounds view");
            }

            roundsCollection.CurrentChanged += RoundChanged;

            if(floorsCollection == null)
            {
                throw new NullReferenceException("floor collection");
            }

            floorsCollection.CurrentChanged += FloorsChanged;

            if (charactersCollection == null)
            {
                throw new NullReferenceException("character collection");
            }

            charactersCollection.CurrentChanged += CharactersChanged;
            #endregion
        }

    #region collection changes delegates
        private void RoundChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("currentRound");
        }

        private void FloorsChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("currentIdentifier");
        }

        private void CharactersChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("currentIdentifier");
        }
    #endregion

        private void GetName()
        {
            double timestamp = double.Parse(Path.GetFileName(path));

            DateTime dayDate = ExtensionMethods.UnixTimeStampToDateTime(timestamp);

            StringBuilder sb = new StringBuilder(dayDate.DayOfWeek.ToString());

            sb.Append(", ");

            sb.Append(dayDate.ToString("M", new CultureInfo("en-us")));

            name = sb.ToString();
        }

        public bool CanUpdateTimeline()
        {
            return type == MapType.Steps && currentMap != null;
        }

        public void Increase()
        {
            if (timelineEnd < maxTimeline)
            {
                timelineEnd++;
                OnPropertyChanged("timelineEnd");
            }
        }

        public void Decrease()
        {
            if (timelineEnd > 0)
            {
                timelineEnd--;
                OnPropertyChanged("timelineEnd");
            }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            if(propertyName == "timelineEnd" && type == MapType.Steps)
            {

                if (currentMap != null)
                {
                    ((Trace)currentMap).UpdateTrace(timelineEnd);

                    OnPropertyChanged("currentImage");
                    OnPropertyChanged("currentMask");
                }
            }

            else if (propertyName == "currentIdentifier" || propertyName == "currentRound" || propertyName == "type")
            {
                if (type != MapType.NONE && currentRound != null && currentIdentifier != null)
                {
                    currentMap = maps.Find(x => x.round == currentRound && x.type == type && x.identifier == currentIdentifier);
                    if (currentMap == null && File.Exists(path + "\\" + currentRound + "\\" + type.ToString() + "\\" + currentIdentifier + ".bhd"))
                    {
                        if (type == MapType.Steps)
                        {
                            currentMap = new Trace(path, currentRound, currentIdentifier, type);
                        }
                        else
                        {
                            currentMap = new Heatmap(path, currentRound, currentIdentifier, type);
                            ((Heatmap)currentMap).GenerateHeatmap();
                        }
                    }

                    timelineEnd = 0;
                    OnPropertyChanged("timelineEnd");
                    OnPropertyChanged("currentImage");
                    OnPropertyChanged("currentMask");
                    OnPropertyChanged("maxTimeline");
                }
            }
        }
    }
}
