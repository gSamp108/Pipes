using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pipes
{
    public sealed class InputSystem
    {
        private KeyboardState lastKeyboardState;
        private KeyboardState currentKeyboardState;
        private MouseState lastMouseState;
        private MouseState currentMouseState;
        private Engine engine;

        public InputSystem (Engine engine)
        {
            this.engine = engine;
        }

        public void Update()
        {
            this.lastKeyboardState = this.currentKeyboardState;
            this.currentKeyboardState = Keyboard.GetState();
            this.lastMouseState = this.currentMouseState;
            this.currentMouseState = Mouse.GetState();
            Mouse.SetPosition(this.engine.GraphicsDevice.Viewport.Width / 2, this.engine.GraphicsDevice.Viewport.Height / 2);
        }

        public bool IsKeyDown(Keys key)
        {
           return this.currentKeyboardState.IsKeyDown(key);
        }
        public bool WasKeyPressed(Keys key)
        {
            return this.lastKeyboardState.IsKeyUp(key) && this.currentKeyboardState.IsKeyDown(key);
        }

        internal Vector2 GetMouseMovement()
        {
            return new Vector2((this.engine.GraphicsDevice.Viewport.Width / 2) - this.currentMouseState.Position.X, (this.engine.GraphicsDevice.Viewport.Height / 2) - this.currentMouseState.Position.Y);
        }
    }
}
