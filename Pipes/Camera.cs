using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipes
{
    public sealed class Camera
    {
        public const float RotationSpeed = 0.3f;
        public const float MovementSpeed = 30.0f;

        public Vector3 Position;
        public Vector3 LookAtVector;
        public Matrix ProjectionMatrix;
        public Matrix ViewMatrix;
        public Matrix WorldMatrix;
        public bool Orbit;
        public float LeftRightRotation = MathHelper.PiOver2;
        public float UpDownRotation = -MathHelper.Pi / 10.0f;

        private Engine engine;

        public Camera(Engine engine)
        {
            this.engine = engine;
            this.LookAtVector = new Vector3(0f, 0f, 0f);
            this.Position = new Vector3(10f, 0f, 0f);
            this.ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f), this.engine.GraphicsDevice.DisplayMode.AspectRatio, 1f, 1000f);
            this.WorldMatrix = Matrix.CreateWorld(this.LookAtVector, Vector3.Forward, Vector3.Up);
            this.UpdateViewMatrix();
        }

        public void UpdateViewMatrix()
        {
            Matrix cameraRotation = Matrix.CreateRotationX(this.UpDownRotation) * Matrix.CreateRotationY(this.LeftRightRotation);

            Vector3 cameraOriginalTarget = new Vector3(0, 0, -1);
            Vector3 cameraRotatedTarget = Vector3.Transform(cameraOriginalTarget, cameraRotation);
            Vector3 cameraFinalTarget = this.Position + cameraRotatedTarget;

            Vector3 cameraOriginalUpVector = new Vector3(0, 1, 0);
            Vector3 cameraRotatedUpVector = Vector3.Transform(cameraOriginalUpVector, cameraRotation);

            this.ViewMatrix = Matrix.CreateLookAt(this.Position, cameraFinalTarget, cameraRotatedUpVector);
        }

        private void AddToCameraPosition(Vector3 vectorToAdd)
        {
            Matrix cameraRotation = Matrix.CreateRotationX(this.UpDownRotation) * Matrix.CreateRotationY(this.LeftRightRotation);
            Vector3 rotatedVector = Vector3.Transform(vectorToAdd, cameraRotation);
            this.Position += Camera.MovementSpeed * rotatedVector;
            this.UpdateViewMatrix();
        }

        internal void Update(float time)
        {
            Vector3 moveVector = new Vector3(0, 0, 0);
            if (this.engine.Input.IsKeyDown(Keys.W)) moveVector += new Vector3(0, 0, -1);
            if (this.engine.Input.IsKeyDown(Keys.S)) moveVector += new Vector3(0, 0, 1);
            if (this.engine.Input.IsKeyDown(Keys.D)) moveVector += new Vector3(1, 0, 0);
            if (this.engine.Input.IsKeyDown(Keys.A)) moveVector += new Vector3(-1, 0, 0);
            if (this.engine.Input.IsKeyDown(Keys.Q)) moveVector += new Vector3(0, 1, 0);
            if (this.engine.Input.IsKeyDown(Keys.Z)) moveVector += new Vector3(0, -1, 0);
            this.AddToCameraPosition(moveVector * time);

            MouseState currentMouseState = Mouse.GetState();
            Vector2 mouseMovement = this.engine.Input.GetMouseMovement();
            this.LeftRightRotation += Camera.RotationSpeed * mouseMovement.X * time;
            this.UpDownRotation += Camera.RotationSpeed * mouseMovement.Y * time;
            this.UpdateViewMatrix();
        }
    }
}
