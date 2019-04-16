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
        List<int> deathsIndexes;

        private Dictionary<string, float> floorNameToFloat;

        public Dictionary<float, Bitmap> masks { get; set; }

        private Dictionary<float, Bitmap> referencesImages;


        public Trace(string dPath, string r, string i, MapType t) : base(dPath, r, i, t)
        {
            #region Basic instanciation
            baseColor = Color.Gray;

            floorNameToFloat = new Dictionary<string, float>();

            floorNameToFloat.Add("FirstFloor.png", 0);
            floorNameToFloat.Add("SecondFloor.png", 1);
            floorNameToFloat.Add("ThirdFloor.png", 2);
            floorNameToFloat.Add("FourthFloor.png", 3);

            masks = new Dictionary<float, Bitmap>();

            referencesImages = new Dictionary<float, Bitmap>();

            deathsIndexes = new List<int>();

            Bitmap tempImage;

            foreach (string file in Directory.GetFiles(Properties.Settings.Default.Path + "\\GeneralsDatas", "*.png"))
            {
                tempImage = new Bitmap(file);

                referencesImages.Add(floorNameToFloat[Path.GetFileName(file)], tempImage);

                masks.Add(floorNameToFloat[Path.GetFileName(file)], new Bitmap(tempImage.Width, tempImage.Height));
            }

            #endregion

            Vector tempVector;

            string path = dPath + "\\" + round + "\\" + type.ToString() + "\\" + identifier + ".bhd";        

            if(File.Exists(path))
            {
                byte[] buffer = File.ReadAllBytes(path);

                if (buffer.Length > 0)
                {
                    float floor;

                    int vectorArrayLength = BitConverter.ToInt32(buffer, 0);

                    foreach (Vector vector in buffer.ConvertBytesToVectors())
                    {

                        tempVector = vector;

                        floor = tempVector.Z;

                        tempVector -= worldRef.Reduce(worldSize / 2);

                        tempVector /= worldSize;

                        tempVector.X *= referencesImages[floor].Size.Height;

                        tempVector.Y *= referencesImages[floor].Size.Width;

                        tempVector.Z = floor;

                        tempVector.X = referencesImages[floor].Height - tempVector.X;

                        points.Add(new Vector(tempVector.Y, tempVector.X, floor));
                    }

                    int startIndex;

                    if (buffer.Length == vectorArrayLength * 12 + 4)
                    {
                        deathsIndexes.Add(points.Count - 1);
                    }
                    else
                    {
                        startIndex = vectorArrayLength * 12 + 8;
                        for (int k = startIndex; k < buffer.Length; k += 4)
                        {
                            deathsIndexes.Add(BitConverter.ToInt32(buffer, k));
                        }
                    }
                }

                referenceImage = points.Count > 0 ? referencesImages[points[0].Z] : referencesImages[0];
                mask = points.Count > 0 ? masks[points[0].Z] : masks[0];
            }

        }

        public void Reset()
        {

            Bitmap baseImage = points.Count > 0 ? referencesImages[points[0].Z] : referencesImages[1];

            referenceImage = new Bitmap(baseImage);

            Graphics canvas;

            foreach (KeyValuePair<float, Bitmap> mask in masks)
            {
                canvas = Graphics.FromImage(mask.Value);

                canvas.Clear(Color.Transparent);
            }

            mask = points.Count > 0 ? masks[points[0].Z] : masks[1] ;
        }

        public void UpdateTrace(int index)
        {
            Reset();

            Color pixelColor;

            Point minBorder;

            Point maxBorder;

            for (int i = 0; i < index; i++)
            {
                if (i > 0)
                {
                    if (points[i].Z != points[i - 1].Z)
                    {
                        referenceImage = referencesImages[points[i].Z];
                        mask = masks[points[i].Z];
                    }
                }

                if (deathsIndexes.Contains(i))
                {
                    pixelColor = Color.Red;
                }
                else
                {
                    pixelColor = baseColor;
                }

                minBorder = new Point((int)points[i].X - radius, (int)points[i].Y - radius);

                maxBorder = new Point((int)points[i].X + radius, (int)points[i].Y + radius);

                for (int j = minBorder.X; j <= maxBorder.X; j++)
                {
                    for (int k = minBorder.Y; k <= maxBorder.Y; k++)
                    {
                        if (Math.Pow(j - points[i].X, 2) + Math.Pow(k - points[i].Y, 2) < radius * radius)
                        {
                            mask.SetPixel(j, k, pixelColor);
                        }
                    }
                }           
            }
        }
    }
}
