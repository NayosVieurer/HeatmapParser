using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;

namespace HeatmapParserWPF
{


    class SoldierTrace
    {

        public List<TracePoint> tracePoints { get; set; }

        public Dictionary<string, Bitmap> masks { get; set; }

        Dictionary<string, Bitmap> referencesImages;

        Color baseColor;

        public string game { get; set; }

        public Bitmap currentMask;

        public Bitmap currentImage { get; set; }

        TracePoint previousPoint = new TracePoint();

        int lastIndex;

        int radius = 20;

        public SoldierTrace(string g)
        {
            game = g;

            tracePoints = new List<TracePoint>();

            baseColor = Color.Gray;

            masks = new Dictionary<string, Bitmap>();

            Bitmap tempImage;

            referencesImages = new Dictionary<string, Bitmap>();

            foreach (string s in Directory.GetFiles(Properties.Settings.Default.Path + "\\GeneralsDatas", "*.png"))
            {
                tempImage = new Bitmap(s);

                masks.Add(Path.GetFileNameWithoutExtension(s), new Bitmap(tempImage.Width, tempImage.Height));

                referencesImages.Add(Path.GetFileNameWithoutExtension(s), tempImage);
            }
            
        }

        public void Reset()
        {
            lastIndex = 0;

            Bitmap baseImage = referencesImages[tracePoints[0].floor];

            currentImage = new Bitmap(baseImage);

            Graphics canvas;

            foreach(KeyValuePair<string, Bitmap> mask in masks)
            {
                canvas = Graphics.FromImage(mask.Value);

                canvas.Clear(Color.Transparent);
            }

            currentMask = masks[tracePoints[0].floor];
        }

        public void UpdateTrace(int index)
        {
            //List<TracePoint> pointsToUpdate = tracePoints.GetRange(index, Math.Abs(index - lastIndex));

            currentImage = previousPoint.floor != null ? new Bitmap(referencesImages[previousPoint.floor]) : new Bitmap(referencesImages[tracePoints[0].floor]);

            Graphics canvas;

            Color pixelColor;

            Point minBorder;

            Point maxBorder;

            for(int i = 0; i < index; i++)
            {
                if(previousPoint.floor != null && tracePoints[i].floor != previousPoint.floor)
                {
                    currentImage = referencesImages[tracePoints[i].floor];

                    currentMask = masks[tracePoints[i].floor];
                }

                if(tracePoints[i] == tracePoints[tracePoints.Count - 1])
                {
                    baseColor = Color.Red;
                }

                minBorder = new Point((int)tracePoints[i].point.X - radius, (int)tracePoints[i].point.Y - radius);

                maxBorder = new Point((int)tracePoints[i].point.X + radius, (int)tracePoints[i].point.Y + radius);

                for(int j = minBorder.X; j <= maxBorder.X;j++)
                {
                    for(int k = minBorder.Y; k <= maxBorder.Y; k++)
                    {
                        if(Math.Pow(j - tracePoints[i].point.X, 2) + Math.Pow(k - tracePoints[i].point.Y, 2) < radius * radius)
                        {   
                            currentMask.SetPixel(j, k, baseColor);
                        }
                    }
                }
                previousPoint = tracePoints[i];
            }

            //canvas = Graphics.FromImage(currentImage);

            //canvas.DrawImage(currentMask, new Rectangle(0, 0, currentMask.Width, currentMask.Height));
        }
    }
}
