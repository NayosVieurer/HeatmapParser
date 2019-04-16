using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HeatmapParserWPF
{
    class Heatmap : Map
    {
        public Heatmap(string dPath, string r, string i, MapType t) : base(dPath, r, i, t)
        {
            string path = dPath + "\\" + round + "\\" + type.ToString() + "\\" + identifier + ".bhd";

            string datasPath = Properties.Settings.Default.Path + "\\GeneralsDatas\\" + identifier + ".png";

            baseColor = Color.Green;

            if(File.Exists(datasPath))
            {
                referenceImage = new Bitmap(datasPath);

                mask = new Bitmap(referenceImage.Size.Width, referenceImage.Size.Height);

                byte[] buffer = File.ReadAllBytes(path);

                Vector tempVector;

                foreach (Vector vector in buffer.ConvertBytesToVectors())
                {
                    tempVector = vector;
                
                    tempVector -= worldRef.Reduce(worldSize / 2);

                    tempVector /= worldSize;

                    tempVector.X *= referenceImage.Size.Width;

                    tempVector.Y *= referenceImage.Size.Height;

                    points.Add(new Vector(tempVector.Y, referenceImage.Height - tempVector.X, tempVector.Z));
                }
            }
        }

        public void GenerateHeatmap()
        {

            Point minBorder;

            Point maxBorder;

            Color pixel;

            foreach(Vector vector in points)
            {
                minBorder = new Point((int)(vector.X - radius), (int)(vector.Y - radius));

                maxBorder = new Point((int)(vector.X + radius), (int)(vector.Y + radius));

                for (int i = minBorder.X; i <= maxBorder.X; i++)
                {
                    for (int j = minBorder.Y; j <= maxBorder.Y; j++)
                    {
                        if (Math.Pow(i - vector.X, 2) + Math.Pow(j - vector.Y, 2) < radius * radius)
                        {
                            pixel = mask.GetPixel(i, j);

                            if (pixel.R == 0 && pixel.G == 0 && pixel.B == 0)
                            {
                                mask.SetPixel(i, j, baseColor);
                            }
                            else
                            {
                                if (pixel.R < 255)
                                {
                                    mask.SetPixel(i, j, Color.FromArgb(Math.Min(255, pixel.R + 200), pixel.G, 0));
                                }
                                else
                                {
                                    mask.SetPixel(i, j, Color.FromArgb(pixel.R, Math.Max(0, pixel.G - 200), 0));
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
