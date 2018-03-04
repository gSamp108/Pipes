using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipes
{
    public sealed class Cube
    {
        public static float Left { get { return -1; } }
        public static float Right { get { return 1; } }
        public static float Top { get { return 1; } }
        public static float Bottom { get { return -1; } }
        public static float Near { get { return 1; } }
        public static float Far { get { return -1; } }

        public static Vector3 LeftNearTop { get { return new Vector3(Cube.Left, Cube.Near, Cube.Top); } }
        public static Vector3 LeftNearBottom { get { return new Vector3(Cube.Left, Cube.Near, Cube.Bottom); } }
        public static Vector3 RightNearTop { get { return new Vector3(Cube.Right, Cube.Near, Cube.Top); } }
        public static Vector3 RightNearBottom { get { return new Vector3(Cube.Right, Cube.Near, Cube.Bottom); } }
        public static Vector3 LeftFarTop { get { return new Vector3(Cube.Left, Cube.Far, Cube.Top); } }
        public static Vector3 LeftFarBottom { get { return new Vector3(Cube.Left, Cube.Far, Cube.Bottom); } }
        public static Vector3 RightFarTop { get { return new Vector3(Cube.Right, Cube.Far, Cube.Top); } }
        public static Vector3 RightFarBottom { get { return new Vector3(Cube.Right, Cube.Far, Cube.Bottom); } }

        public static VertexPositionNormalTexture[] TopSide
        {
            get
            {
                return new VertexPositionNormalTexture[]
                {
                    new VertexPositionNormalTexture(Cube.LeftFarTop, new Vector3(0,0,Cube.Top), new Vector2(0, 0)),
                    new VertexPositionNormalTexture(Cube.LeftNearTop, new Vector3(0,0,Cube.Top), new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.RightFarTop, new Vector3(0,0,Cube.Top), new Vector2(1, 0)),
                    new VertexPositionNormalTexture(Cube.LeftNearTop, new Vector3(0,0,Cube.Top), new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.RightNearTop, new Vector3(0,0,Cube.Top), new Vector2(1, 1)),
                    new VertexPositionNormalTexture(Cube.RightFarTop, new Vector3(0,0,Cube.Top), new Vector2(1, 0)),
                };
            }
        }

        public static VertexPositionNormalTexture[] BottomSide
        {
            get
            {
                return new VertexPositionNormalTexture[]
                {
                    new VertexPositionNormalTexture(Cube.LeftNearBottom, new Vector3(0,0,Cube.Bottom), new Vector2(0, 0)),
                    new VertexPositionNormalTexture(Cube.LeftFarBottom, new Vector3(0,0,Cube.Bottom), new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.RightNearBottom, new Vector3(0,0,Cube.Bottom), new Vector2(1, 0)),
                    new VertexPositionNormalTexture(Cube.LeftFarBottom, new Vector3(0,0,Cube.Bottom), new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.RightFarBottom, new Vector3(0,0,Cube.Bottom), new Vector2(1, 1)),
                    new VertexPositionNormalTexture(Cube.RightNearBottom, new Vector3(0,0,Cube.Bottom), new Vector2(1, 0)),
                };
            }
        }

        public static VertexPositionNormalTexture[] NearSide
        {
            get
            {
                return new VertexPositionNormalTexture[]
                {
                    new VertexPositionNormalTexture(Cube.LeftNearTop, new Vector3(0,Cube.Near,0), new Vector2(0, 0)),
                    new VertexPositionNormalTexture(Cube.LeftNearBottom, new Vector3(0,Cube.Near,0), new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.RightNearTop, new Vector3(0,Cube.Near,0), new Vector2(1, 0)),
                    new VertexPositionNormalTexture(Cube.LeftNearBottom, new Vector3(0,Cube.Near,0), new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.RightNearBottom, new Vector3(0,Cube.Near,0), new Vector2(1, 1)),
                    new VertexPositionNormalTexture(Cube.RightNearTop, new Vector3(0,Cube.Near,0), new Vector2(1, 0)),
                };
            }
        }

        public static VertexPositionNormalTexture[] FarSide
        {
            get
            {
                return new VertexPositionNormalTexture[]
                {
                    new VertexPositionNormalTexture(Cube.RightFarTop, new Vector3(0,Cube.Far,0), new Vector2(0, 0)),
                    new VertexPositionNormalTexture(Cube.RightFarBottom, new Vector3(0,Cube.Far,0), new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.LeftFarTop, new Vector3(0,Cube.Far,0), new Vector2(1, 0)),
                    new VertexPositionNormalTexture(Cube.RightFarBottom, new Vector3(0,Cube.Far,0), new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.LeftFarBottom, new Vector3(0,Cube.Far,0), new Vector2(1, 1)),
                    new VertexPositionNormalTexture(Cube.LeftFarTop, new Vector3(0,Cube.Far,0), new Vector2(1, 0)),
                };
            }
        }

        public static VertexPositionNormalTexture[] LeftSide
        {
            get
            {
                return new VertexPositionNormalTexture[]
                {
                    new VertexPositionNormalTexture(Cube.LeftFarTop, new Vector3(Cube.Left,0,0), new Vector2(0, 0)),
                    new VertexPositionNormalTexture(Cube.LeftFarBottom, new Vector3(Cube.Left,0,0), new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.LeftNearTop, new Vector3(Cube.Left,0,0), new Vector2(1, 0)),
                    new VertexPositionNormalTexture(Cube.LeftFarBottom, new Vector3(Cube.Left,0,0), new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.LeftNearBottom, new Vector3(Cube.Left,0,0), new Vector2(1, 1)),
                    new VertexPositionNormalTexture(Cube.LeftNearTop, new Vector3(Cube.Left,0,0), new Vector2(1, 0)),
                };
            }
        }

        public static VertexPositionNormalTexture[] RightSide
        {
            get
            {
                return new VertexPositionNormalTexture[]
                {
                    new VertexPositionNormalTexture(Cube.RightNearTop, new Vector3(Cube.Right,0,0), new Vector2(0, 0)),
                    new VertexPositionNormalTexture(Cube.RightNearBottom, new Vector3(Cube.Right,0,0), new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.RightFarTop, new Vector3(Cube.Right,0,0), new Vector2(1, 0)),
                    new VertexPositionNormalTexture(Cube.RightNearBottom, new Vector3(Cube.Right,0,0), new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.RightFarBottom, new Vector3(Cube.Right,0,0), new Vector2(1, 1)),
                    new VertexPositionNormalTexture(Cube.RightFarTop, new Vector3(Cube.Right,0,0), new Vector2(1, 0)),
                };
            }
        }


    }
}
