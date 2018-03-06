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
        public static Vector3 LeftUpForward { get { return new Vector3(Vector3.Left.X, Vector3.Up.Y, Vector3.Forward.Z); } }
        public static Vector3 LeftDownForward { get { return new Vector3(Vector3.Left.X, Vector3.Down.Y, Vector3.Forward.Z); } }
        public static Vector3 RightUpForward { get { return new Vector3(Vector3.Right.X, Vector3.Up.Y, Vector3.Forward.Z); } }
        public static Vector3 RightDownForward { get { return new Vector3(Vector3.Right.X, Vector3.Down.Y, Vector3.Forward.Z); } }
        public static Vector3 LeftUpBackward { get { return new Vector3(Vector3.Left.X, Vector3.Up.Y, Vector3.Backward.Z); } }
        public static Vector3 LeftDownBackward { get { return new Vector3(Vector3.Left.X, Vector3.Down.Y, Vector3.Backward.Z); } }
        public static Vector3 RightUpBackward { get { return new Vector3(Vector3.Right.X, Vector3.Up.Y, Vector3.Backward.Z); } }
        public static Vector3 RightDownBackward { get { return new Vector3(Vector3.Right.X, Vector3.Down.Y, Vector3.Backward.Z); } }

        public static VertexPositionNormalTexture[] UpSide
        {
            get
            {
                return new VertexPositionNormalTexture[]
                {
                    new VertexPositionNormalTexture(Cube.LeftUpBackward, Vector3.Up, new Vector2(0, 0)),
                    new VertexPositionNormalTexture(Cube.LeftUpForward,Vector3.Up, new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.RightUpBackward, Vector3.Up, new Vector2(1, 0)),
                    new VertexPositionNormalTexture(Cube.LeftUpForward, Vector3.Up, new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.RightUpForward, Vector3.Up, new Vector2(1, 1)),
                    new VertexPositionNormalTexture(Cube.RightUpBackward, Vector3.Up, new Vector2(1, 0)),
                };
            }
        }

        public static VertexPositionNormalTexture[] DownSide
        {
            get
            {
                return new VertexPositionNormalTexture[]
                {
                    new VertexPositionNormalTexture(Cube.LeftDownForward, Vector3.Down, new Vector2(0, 0)),
                    new VertexPositionNormalTexture(Cube.LeftDownBackward, Vector3.Down, new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.RightDownForward, Vector3.Down, new Vector2(1, 0)),
                    new VertexPositionNormalTexture(Cube.LeftDownBackward, Vector3.Down, new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.RightDownBackward, Vector3.Down, new Vector2(1, 1)),
                    new VertexPositionNormalTexture(Cube.RightDownForward, Vector3.Down, new Vector2(1, 0)),
                };
            }
        }

        public static VertexPositionNormalTexture[] ForwardSide
        {
            get
            {
                return new VertexPositionNormalTexture[]
                {
                    new VertexPositionNormalTexture(Cube.LeftUpForward, Vector3.Forward, new Vector2(0, 0)),
                    new VertexPositionNormalTexture(Cube.LeftDownForward, Vector3.Forward, new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.RightUpForward, Vector3.Forward, new Vector2(1, 0)),
                    new VertexPositionNormalTexture(Cube.LeftDownForward, Vector3.Forward, new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.RightDownForward, Vector3.Forward, new Vector2(1, 1)),
                    new VertexPositionNormalTexture(Cube.RightUpForward, Vector3.Forward, new Vector2(1, 0)),
                };
            }
        }

        public static VertexPositionNormalTexture[] BackwardSide
        {
            get
            {
                return new VertexPositionNormalTexture[]
                {
                    new VertexPositionNormalTexture(Cube.RightUpBackward, Vector3.Backward, new Vector2(0, 0)),
                    new VertexPositionNormalTexture(Cube.RightDownBackward, Vector3.Backward, new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.LeftUpBackward, Vector3.Backward, new Vector2(1, 0)),
                    new VertexPositionNormalTexture(Cube.RightDownBackward, Vector3.Backward, new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.LeftDownBackward, Vector3.Backward, new Vector2(1, 1)),
                    new VertexPositionNormalTexture(Cube.LeftUpBackward, Vector3.Backward, new Vector2(1, 0)),
                };
            }
        }

        public static VertexPositionNormalTexture[] LeftSide
        {
            get
            {
                return new VertexPositionNormalTexture[]
                {
                    new VertexPositionNormalTexture(Cube.LeftUpBackward, Vector3.Left, new Vector2(0, 0)),
                    new VertexPositionNormalTexture(Cube.LeftDownBackward, Vector3.Left, new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.LeftUpForward,Vector3.Left, new Vector2(1, 0)),
                    new VertexPositionNormalTexture(Cube.LeftDownBackward, Vector3.Left, new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.LeftDownForward, Vector3.Left, new Vector2(1, 1)),
                    new VertexPositionNormalTexture(Cube.LeftUpForward, Vector3.Left, new Vector2(1, 0)),
                };
            }
        }

        public static VertexPositionNormalTexture[] RightSide
        {
            get
            {
                return new VertexPositionNormalTexture[]
                {
                    new VertexPositionNormalTexture(Cube.RightUpForward, Vector3.Right, new Vector2(0, 0)),
                    new VertexPositionNormalTexture(Cube.RightDownForward, Vector3.Right, new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.RightUpBackward, Vector3.Right, new Vector2(1, 0)),
                    new VertexPositionNormalTexture(Cube.RightDownForward, Vector3.Right, new Vector2(0, 1)),
                    new VertexPositionNormalTexture(Cube.RightDownBackward, Vector3.Right, new Vector2(1, 1)),
                    new VertexPositionNormalTexture(Cube.RightUpBackward, Vector3.Right, new Vector2(1, 0)),
                };
            }
        }


    }
}
