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
    public struct Vector
    {
        public float X;
        public float Y;
        public float Z;

        public Vector(float X = 0, float Y = 0, float Z = 0)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public Vector Reduce(float B)
        {
            Vector returnVector = new Vector();

            returnVector.X = X - B;

            returnVector.Y = Y - B;

            returnVector.Z = Z - B;

            return returnVector;
        }

        public static Vector operator-(Vector A, Vector B)
        {
            Vector returnVector = new Vector();

            returnVector.X = A.X - B.X;

            returnVector.Y = A.Y - B.Y;

            returnVector.Z = A.Z - B.Z;

            return returnVector;
        }

        public static Vector operator/(Vector A, float B)
        {
            Vector returnVector = new Vector();

            returnVector.X = A.X / B;

            returnVector.Y = A.Y / B;

            returnVector.Z = A.Z / B;

            return returnVector;
        }

        public static Vector operator *(Vector A, int B)
        {
            Vector returnVector = new Vector();

            returnVector.X = A.X * B;

            returnVector.Y = A.Y * B;

            returnVector.Z = A.Z * B;

            return returnVector;
        }
    };

    public struct HeatPoint
    {
        public float X;
        public float Y;

        public byte intensity;

        public HeatPoint(float iX, float iY, byte bIntensity)
        {
            X = iX;
            Y = iY;
            intensity = bIntensity;
        }
    }


    class Heatmap
    {
        List<HeatPoint> heatPoints = new List<HeatPoint>();

        Vector worldReference;

        float worldSize;

        public Bitmap referenceImage { get; set; }

        public Bitmap mask { get; set; }

        public Bitmap result;

        float radius = 20;

        public Heatmap(string path, string floor)
        {
            referenceImage = new Bitmap(Properties.Settings.Default.DatasPath + "\\" + floor + ".png");

            mask = new Bitmap(referenceImage.Width, referenceImage.Height);

            result = new Bitmap(referenceImage);

            Graphics.FromImage(mask).Clear(Color.Transparent);

            //referenceImage = new Bitmap(500, 500);

            Vector tempVector;

            byte[] referenceBuffer = File.ReadAllBytes(Properties.Settings.Default.DatasPath + "\\GeneralsDatas.bhd");

            worldReference = new Vector(BitConverter.ToSingle(referenceBuffer, 0), BitConverter.ToSingle(referenceBuffer, 4), BitConverter.ToSingle(referenceBuffer, 8));

            worldSize = BitConverter.ToSingle(referenceBuffer, 12);

            Vector worldMin = worldReference.Reduce(worldSize / 2);

            HeatPoint tempPoint;

            byte[] posBuffer = File.ReadAllBytes(path);

            for(int i = 4; i < posBuffer.Length; i += 12)
            {
                tempVector = new Vector(BitConverter.ToSingle(posBuffer, i), BitConverter.ToSingle(posBuffer, i + 4), BitConverter.ToSingle(posBuffer, i + 8));

                tempVector -= worldMin;

                tempVector /= worldSize;

                tempVector *= mask.Height;

                tempPoint = new HeatPoint(tempVector.Y, referenceImage.Size.Height - tempVector.X, 255);

                heatPoints.Add(tempPoint);
            }
        }

        public void Generate()
        {
            Graphics canvas = Graphics.FromImage(result);

            //canvas.Clear(Color.White);

            Point minBorder;

            Point maxBorder;

            Color pixel;

            foreach (HeatPoint point in heatPoints)
            {

                minBorder = new Point((int)(point.X - radius), (int)(point.Y - radius));

                maxBorder = new Point((int)(point.X + radius), (int)(point.Y + radius));

                for (int i = minBorder.X; i <= maxBorder.X; i++)
                {
                    for(int j = minBorder.Y; j <= maxBorder.Y; j++)
                    {

                        if (Math.Pow(i - point.X, 2) + Math.Pow(j - point.Y, 2) < radius * radius)
                        {
                            pixel = mask.GetPixel(i, j);

                            if(pixel.R == 0 && pixel.G == 0 && pixel.B == 0)
                            {
                                mask.SetPixel(i, j, Color.FromArgb(0, 255, 0));
                            }
                            else
                            {
                                if(pixel.R < 255)
                                {
                                    mask.SetPixel(i, j, Color.FromArgb(Math.Min(255, pixel.R + 100),  pixel.G, 0));
                                }
                                else
                                {
                                    mask.SetPixel(i, j, Color.FromArgb(pixel.R, Math.Max(0, pixel.G - 100), 0));
                                }
                            }
                        }
                    }
                }

                canvas.DrawImage(mask, new Rectangle(0, 0, mask.Width, mask.Height));
            }

            Colorize();
        }
        
        public void GenerateSoldier()
        {

        }
    }
}
