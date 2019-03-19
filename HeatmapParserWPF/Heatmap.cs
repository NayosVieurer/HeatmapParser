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




    class Heatmap
    {
        public List<ImagePoint> heatPoints { get; set; }

        Color baseColor;

        public string floor { get; set; }

        public string game { get; set; }

        public MapType playerType { get; set; }

        public Bitmap referenceImage { get; set; }

        public Bitmap mask { get; set; }

        float radius = 20;

        public Heatmap(string floor, string game, MapType playerType)
        {

            this.floor = floor;

            baseColor = Color.FromArgb(0, 255, 0);
            
            this.game = game;

            this.playerType = playerType;

            heatPoints = new List<ImagePoint>();

            referenceImage = new Bitmap(Properties.Settings.Default.Path + "\\GeneralsDatas\\" + floor + ".png");
        }

        public void GenerateHeatmap()
        {

            mask = new Bitmap(referenceImage.Width, referenceImage.Height);

            Point minBorder;

            Point maxBorder;

            Color pixel;
            
            for (int index = 0; index < heatPoints.Count; index++)
            {
                minBorder = new Point((int)(heatPoints[index].X - radius), (int)(heatPoints[index].Y - radius));

                maxBorder = new Point((int)(heatPoints[index].X + radius), (int)(heatPoints[index].Y + radius));

                for (int i = minBorder.X; i <= maxBorder.X; i++)
                {
                    for(int j = minBorder.Y; j <= maxBorder.Y; j++)
                    {
                        if (Math.Pow(i - heatPoints[index].X, 2) + Math.Pow(j - heatPoints[index].Y, 2) < radius * radius)
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
