using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipes
{
    public struct Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }

        public Position(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override bool Equals(object obj)
        {
            return obj is Position &&
                ((Position)obj).X == this.X &&
                ((Position)obj).Y == this.Y &&
                ((Position)obj).Z == this.Z;
        }

        public override int GetHashCode()
        {
            int result;
            unchecked
            {
                result = (int)2166136261;
                result = (result * 16777619) ^ this.X.GetHashCode();
                result = (result * 16777619) ^ this.Y.GetHashCode();
                result = (result * 16777619) ^ this.Z.GetHashCode();
            }
            return result;
        }

        public override string ToString()
        {
            return "(" + this.X.ToString() + ", " + this.Y.ToString() + ", " + this.Z.ToString() + ")";
        }
    }
}
