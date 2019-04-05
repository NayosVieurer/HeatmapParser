using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace HeatmapParserWPF
{

    public struct TracePoint
    {
        public ImagePoint point;

        public string floor;

        public TracePoint(ImagePoint p, string f)
        {
            point = p;


            floor = f;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is TracePoint))
            {
                return false;
            }

            var point = (TracePoint)obj;
            return EqualityComparer<ImagePoint>.Default.Equals(this.point, point.point) &&
                   floor == point.floor;
        }

        public override int GetHashCode()
        {
            var hashCode = 403149910;
            hashCode = hashCode * -1521134295 + EqualityComparer<ImagePoint>.Default.GetHashCode(point);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(floor);
            return hashCode;
        }

        public static bool operator ==(TracePoint p1, TracePoint p2)
        {

            return p1.point == p2.point && p1.floor == p2.floor;
        }

        public static bool operator !=(TracePoint p1, TracePoint p2)
        {
            return p1.point != p2.point || p1.floor != p2.floor;
        }
    }

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

        public static Vector operator -(Vector A, Vector B)
        {
            Vector returnVector = new Vector();

            returnVector.X = A.X - B.X;

            returnVector.Y = A.Y - B.Y;

            returnVector.Z = A.Z - B.Z;

            return returnVector;
        }

        public static Vector operator /(Vector A, float B)
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

    public struct ImagePoint
    {
        public float X;
        public float Y;

        public ImagePoint(float iX, float iY)
        {
            X = iX;
            Y = iY;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ImagePoint))
            {
                return false;
            }

            var point = (ImagePoint)obj;
            return X == point.X &&
                   Y == point.Y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(ImagePoint p1, ImagePoint p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(ImagePoint p1, ImagePoint p2)
        {
            return p1.X != p2.X || p1.Y != p2.Y;
        }


    }


}
