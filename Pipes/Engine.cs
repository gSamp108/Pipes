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
        public InputSystem Input { get; private set; }
        public Camera Camera { get; private set; }

        private GraphicsDeviceManager graphics;

        BasicEffect effect;
        Texture2D checkerboardTexture;
        Texture2D grassTexture;
        Texture2D outlineTexture;
        KeyboardState lastKeyState;
        Dictionary<Keys, bool> flags = new Dictionary<Keys, bool>();
        bool cameraOrbit;

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

            DrawGround();

            base.Draw(gameTime);
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

                if (!this.isFlagged(Keys.D1)) graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Cube.TopSide, 0, (Cube.TopSide.Length / 3));
                if (!this.isFlagged(Keys.D2)) graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Cube.RightSide, 0, (Cube.RightSide.Length / 3));
                if (!this.isFlagged(Keys.D3)) graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Cube.LeftSide, 0, (Cube.LeftSide.Length / 3));
                if (!this.isFlagged(Keys.D4)) graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Cube.BottomSide, 0, (Cube.BottomSide.Length / 3));
                if (!this.isFlagged(Keys.D5)) graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Cube.FarSide, 0, (Cube.FarSide.Length / 3));
                if (!this.isFlagged(Keys.D6)) graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Cube.NearSide, 0, (Cube.NearSide.Length / 3));
            }
        }

    }
}
