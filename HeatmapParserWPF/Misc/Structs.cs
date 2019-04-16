using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
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

        public override bool Equals(object obj)
        {
            if (!(obj is Vector))
            {
                return false;
            }

            var vector = (Vector)obj;
            return X == vector.X &&
                   Y == vector.Y &&
                   Z == vector.Z;
        }

        public override int GetHashCode()
        {
            var hashCode = -307843816;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Z.GetHashCode();
            return hashCode;
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

        public static bool operator ==(Vector A, Vector B)
        {
            return A.X == B.X && A.Y == B.Y && A.Z == B.Z;
        }

        public static bool operator !=(Vector A, Vector B)
        {
            return A.X != B.X || A.Y != B.Y || A.Z != B.Z;
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
