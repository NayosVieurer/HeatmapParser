using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;

namespace HeatmapParserWPF
{


    class Trace : Map
    {

        private Dictionary<float, string> floorIntToString;

        public Dictionary<float, Bitmap> masks { get; set; }

        private Dictionary<float, Bitmap> referencesImages;


        private string character;

        public Trace(string r, string i, MapType t) : base(r, i, t)
        {
            #region Basic instanciation
            baseColor = Color.Gray;

            floorIntToString = new Dictionary<float, string>();

            floorIntToString.Add(0, "FirstFloor.png");
            floorIntToString.Add(1, "SecondFloor.png");
            floorIntToString.Add(2, "ThirdFloor.png");
            floorIntToString.Add(3, "FourthFloor.png");

            masks = new Dictionary<float, Bitmap>();

            referencesImages = new Dictionary<float, Bitmap>();

            #endregion

            Vector tempVector;

            Bitmap tempImage;

            float floor;

            //foreach (Vector vector in worldPoints)
            //{
            //    tempVector = vector;

            //    floor = tempVector.Z;

            //    tempVector -= worldRef.Reduce(worldSize / 2);

            //    tempVector /= worldSize;

            //    if (!referencesImages.ContainsKey(floor))
            //    {
            //        tempImage = new Bitmap(Properties.Settings.Default.Path + "\\GeneralsDatas\\" + floorIntToString[floor]);
            //        referencesImages.Add(floor, tempImage);
            //        masks.Add(floor, new Bitmap(tempImage.Size.Width, tempImage.Size.Height));
            //    }

            //    tempVector.X *= referencesImages[floor].Size.Width;

            //    tempVector.Y *= referencesImages[floor].Size.Height;

            //    tempVector.Z = floor;

            //    points.Add(tempVector);
            //}
        }

        public void Reset()
        {

            //Bitmap baseImage = referencesImages[points[0].Z];

            //currentImage = new Bitmap(baseImage);

            //Graphics canvas;

            //foreach(KeyValuePair<string, Bitmap> mask in masks)
            //{
            //    canvas = Graphics.FromImage(mask.Value);

            //    canvas.Clear(Color.Transparent);
            //}

            //currentMask = masks[tracePoints[0].floor];
        }

        public void UpdateTrace(int index)
        {

            //referenceImage = referencesImages[points[0].Z];

            //Graphics canvas;

            //Color pixelColor;

            //Point minBorder;

            //Point maxBorder;

            //for(int i = 0; i < index; i++)
            //{
            //    if(i > 0)
            //    {
            //        if(points[i].Z != points[i - 1].Z)
            //        {
            //            referenceImage = referencesImages[points[i].Z];
            //        }
            //    }

            //    if(tracePoints[i] == tracePoints[tracePoints.Count - 1])
            //    {
            //        baseColor = Color.Red;
            //    }

            //    minBorder = new Point((int)tracePoints[i].point.X - radius, (int)tracePoints[i].point.Y - radius);

            //    maxBorder = new Point((int)tracePoints[i].point.X + radius, (int)tracePoints[i].point.Y + radius);

            //    for(int j = minBorder.X; j <= maxBorder.X;j++)
            //    {
            //        for(int k = minBorder.Y; k <= maxBorder.Y; k++)
            //        {
            //            if(Math.Pow(j - tracePoints[i].point.X, 2) + Math.Pow(k - tracePoints[i].point.Y, 2) < radius * radius)
            //            {   
            //                currentMask.SetPixel(j, k, baseColor);
            //            }
            //        }
            //    }
            //    previousPoint = tracePoints[i];
            //}

            ////canvas = Graphics.FromImage(currentImage);

            ////canvas.DrawImage(currentMask, new Rectangle(0, 0, currentMask.Width, currentMask.Height));
        }
    }
}
