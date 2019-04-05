using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace HeatmapParserWPF
{
    public static class ExtensionMethods
    {

        public static Vector[] ConvertBytesToVectors(this byte[] arrayToConvert)
        {
            Vector[] returnArray = new Vector[BitConverter.ToInt32(arrayToConvert, 0)];

            int index = 0;

            for(int i = 4; i < arrayToConvert.Length; i += 12)
            {
                returnArray[index] = new Vector(BitConverter.ToSingle(arrayToConvert, i), BitConverter.ToSingle(arrayToConvert, i + 4), BitConverter.ToSingle(arrayToConvert, i + 8));

                index++;
            }            

            return returnArray;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static ImagePoint[] ConvertBytesToImagePoints(this byte[] arrayToConvert, Vector worldReference, float worldSize, Size imageSize)
        {
            ImagePoint[] returnArray = new ImagePoint[BitConverter.ToInt32(arrayToConvert, 0)];

            int index = 0;

            Vector tempVector;

            for (int i = 4; i < arrayToConvert.Length; i += 12)
            {

                tempVector = new Vector(BitConverter.ToSingle(arrayToConvert, i), BitConverter.ToSingle(arrayToConvert, i + 4), BitConverter.ToSingle(arrayToConvert, i + 8));

                tempVector -= worldReference.Reduce(worldSize / 2);

                tempVector /= worldSize;

                tempVector.X *= imageSize.Width;

                tempVector.Y *= imageSize.Height;

                returnArray[index] = new ImagePoint(tempVector.Y, imageSize.Height - tempVector.X);
                index++;
            }

            return returnArray;
        }

        public static ImagePoint ConvertVectorToImagePoint(this Vector vectorToConvert, Vector worldReference, float worldSize, Size imageSize)
        {

            vectorToConvert -= worldReference.Reduce(worldSize / 2);

            vectorToConvert /= worldSize;

            vectorToConvert.X *= imageSize.Width;

            vectorToConvert.Y *= imageSize.Width;

            return new ImagePoint(vectorToConvert.Y, imageSize.Height - vectorToConvert.X);
        }

        
    }
}
