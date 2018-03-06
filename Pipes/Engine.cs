using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipes
{
    public class Engine : Game
    {
        public const int ChunkSize = 32;

        public InputSystem Input { get; private set; }
        public Camera Camera { get; private set; }

        private GraphicsDeviceManager graphics;

        BasicEffect effect;
        Texture2D checkerboardTexture;
        Texture2D grassTexture;
        Texture2D outlineTexture;
        KeyboardState lastKeyState;
        Dictionary<Keys, bool> flags = new Dictionary<Keys, bool>();

        Chunk chunk = new Chunk();

        public Engine()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            this.Input = new InputSystem(this);
            this.Camera = new Camera(this);
            this.effect = new BasicEffect(graphics.GraphicsDevice);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            using (var stream = TitleContainer.OpenStream("Content/checkerboard.png"))
            {
                checkerboardTexture = Texture2D.FromStream(this.GraphicsDevice, stream);
            }
            using (var stream = TitleContainer.OpenStream("Content/Grass64.png"))
            {
                this.grassTexture = Texture2D.FromStream(this.GraphicsDevice, stream);
            }
            using (var stream = TitleContainer.OpenStream("Content/Outline64.png"))
            {
                this.outlineTexture = Texture2D.FromStream(this.GraphicsDevice, stream);
            }


        }

        protected override void Update(GameTime gameTime)
        {
            var time = (float)(gameTime.ElapsedGameTime.TotalSeconds);

            this.Input.Update();
            this.Camera.Update(time);

            if (this.Input.WasKeyPressed(Keys.Escape)) this.Exit();

            var currentKeyState = Keyboard.GetState();


            foreach (var key in currentKeyState.GetPressedKeys())
            {
                if (!this.lastKeyState.IsKeyDown(key))
                {
                    if (!this.flags.ContainsKey(key)) this.flags.Add(key, false);
                    this.flags[key] = !this.flags[key];
                }
            }

            this.lastKeyState = currentKeyState;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.DrawChunk(chunk);
            DrawGround();

            base.Draw(gameTime);
        }

        private void DrawChunk(Chunk chunk)
        {
            effect.View = this.Camera.ViewMatrix;
            effect.Projection = this.Camera.ProjectionMatrix;
            effect.TextureEnabled = true;
            effect.Texture = this.outlineTexture;


            for (int x = 0; x < Engine.ChunkSize; x++)
            {
                for (int y = 0; y < Engine.ChunkSize; y++)
                {
                    for (int z = 0; z < Engine.ChunkSize; z++)
                    {

                    }
                }
            }

            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();


                if (!this.isFlagged(Keys.D1)) graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Cube.UpSide, 0, (Cube.UpSide.Length / 3));
                if (!this.isFlagged(Keys.D2)) graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Cube.DownSide, 0, (Cube.DownSide.Length / 3));

                if (!this.isFlagged(Keys.D3)) graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Cube.LeftSide, 0, (Cube.LeftSide.Length / 3));
                if (!this.isFlagged(Keys.D4)) graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Cube.RightSide, 0, (Cube.RightSide.Length / 3));

                if (!this.isFlagged(Keys.D5)) graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Cube.ForwardSide, 0, (Cube.ForwardSide.Length / 3));
                if (!this.isFlagged(Keys.D6)) graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Cube.BackwardSide, 0, (Cube.BackwardSide.Length / 3));
            }
        }

        bool isFlagged(Keys key)
        {
            if (this.flags.ContainsKey(key)) return this.flags[key];
            else return false;
        }

        void DrawGround()
        {
            effect.View = this.Camera.ViewMatrix;
            effect.Projection = this.Camera.ProjectionMatrix;

            effect.TextureEnabled = true;
            effect.Texture = this.outlineTexture;

            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                if (!this.isFlagged(Keys.D1)) graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Cube.UpSide, 0, (Cube.UpSide.Length / 3));
                if (!this.isFlagged(Keys.D2)) graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Cube.DownSide, 0, (Cube.DownSide.Length / 3));

                if (!this.isFlagged(Keys.D3)) graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Cube.LeftSide, 0, (Cube.LeftSide.Length / 3));
                if (!this.isFlagged(Keys.D4)) graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Cube.RightSide, 0, (Cube.RightSide.Length / 3));

                if (!this.isFlagged(Keys.D5)) graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Cube.ForwardSide, 0, (Cube.ForwardSide.Length / 3));
                if (!this.isFlagged(Keys.D6)) graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Cube.BackwardSide, 0, (Cube.BackwardSide.Length / 3));
            }
        }

    }
}
