using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HeatmapParserWPF
{

    class GameViewModel : ViewModelBase
    {
        #region fields
        private MapType type;

        private ICollectionView roundsCollection;

        private ICollectionView floorsCollection;

        private Dictionary<string, string> nameConversion;
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

        public ObservableCollection<string> identifiers { get; set; }

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

                return floorsCollection.CurrentItem.ToString();
                //string cF = "";

                //foreach(KeyValuePair<string, string> item in nameConversion)
                //{
                //    if(item.Value == floorsCollection.CurrentItem.ToString())
                //    {
                //        cF = item.Key;
                //    }
                //}

                //return cF;
            }
        }
        #endregion

        public GameViewModel(string p, ObservableCollection<string> _floors)
        {
            #region Conversion dictionnary
            nameConversion = new Dictionary<string, string>();

            nameConversion.Add("FirstFloor", "Basement");
            nameConversion.Add("SecondFloor", "Ground floor");
            nameConversion.Add("ThirdFloor", "First floor");
            nameConversion.Add("FourthFloor", "Roofs");

            #endregion

            path = p;

            #region List initiazation

            rounds = new ObservableCollection<string>();

            floors = new ObservableCollection<string>();

            characters = new ObservableCollection<string>();

            characters.Add("soldier");
            characters.Add("Scout");
            characters.Add("Trapper");
            characters.Add("Charger");

            foreach (string floor in _floors)
            {
                floors.Add(nameConversion[floor]);
            }

            rounds.Add("Global");

            foreach(string s in Directory.GetDirectories(p))
            {
                rounds.Add(Path.GetFileName(s));
            }

            identifiers = floors;

            #endregion

            double timestamp = double.Parse(Path.GetFileName(p));

            DateTime dayDate = ExtensionMethods.UnixTimeStampToDateTime(timestamp);

            StringBuilder sb = new StringBuilder(dayDate.DayOfWeek.ToString());

            sb.Append(", ");

            sb.Append(dayDate.ToString("M", new CultureInfo("en-us")));

            name = sb.ToString();

            type = MapType.NONE;

            #region collections views

            roundsCollection = CollectionViewSource.GetDefaultView(rounds);

            floorsCollection = CollectionViewSource.GetDefaultView(identifiers);

            if(roundsCollection == null)
            {
                throw new NullReferenceException("rounds view");
            }

            roundsCollection.CurrentChanged += RoundChanged;

            if(floorsCollection == null)
            {
                throw new NullReferenceException("floor collection");
            }

            floorsCollection.CurrentChanged += FloorsChanged;
            #endregion

        }

        private void RoundChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("currentRound");
        }

        private void FloorsChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("currentIdentifier");
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            if(type == MapType.Steps)
            {
                identifiers = characters;

                Console.WriteLine("toto");

                floorsCollection = CollectionViewSource.GetDefaultView(identifiers);
            }

            if (type != MapType.NONE && currentRound != null && currentIdentifier != null)
            {

                if (type == MapType.Steps)
                {

                }
            }
        }
    }
}
