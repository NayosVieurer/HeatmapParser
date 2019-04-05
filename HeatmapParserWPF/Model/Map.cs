using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatmapParserWPF
{
    abstract class Map
    {

        protected Color baseColor;

        protected List<Vector> points;

        protected Vector worldRef;

        protected float worldSize;

        protected int radius;

        public string round { get; set; }

        public string identifier { get; set; }

        public MapType type;

        public Bitmap referenceImage { get; set; }

        public Bitmap mask { get; set; }

        public Map(string r, string i, MapType t)
        {

            radius = 20;

            points = new List<Vector>();

            round = r;

            identifier = i;

            type = t;

            byte[] worldBuffer = File.ReadAllBytes(Properties.Settings.Default.Path + "\\GeneralsDatas\\generalsDatas.bhd");

            worldRef = new Vector(BitConverter.ToSingle(worldBuffer, 0), BitConverter.ToSingle(worldBuffer, 4), BitConverter.ToSingle(worldBuffer, 8));

            worldSize = BitConverter.ToSingle(worldBuffer, 12);
        }
    }
}
