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
            int arrayLength = BitConverter.ToInt32(arrayToConvert, 0);

            Vector[] returnArray = new Vector[0];

            if (arrayLength > 0)
            {
                returnArray = new Vector[arrayLength];

                byte[] buffer = new byte[arrayLength * 12];

                Array.Copy(arrayToConvert, 4, buffer, 0, arrayLength * 12);

                int index = 0;

                for (int i = 0; i < buffer.Length; i += 12)
                {
                    returnArray[index] = new Vector(BitConverter.ToSingle(buffer, i), BitConverter.ToSingle(buffer, i + 4), BitConverter.ToSingle(buffer, i + 8));

                    index++;
                }
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
    }
}
