using System;
using System.Dynamic;
using System.Reflection.Emit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AZUMANGA {
    public class Camera {
        public Vector2 position { get; set; }
        public Matrix viewMatrix { get; private set; }
        private readonly Viewport _viewport;

        public Camera(Viewport viewport){
            _viewport = viewport;
            position = Vector2.Zero;
            UpdateMatrix();
        }

        public void Update(Vector2 targetposition){
            position = targetposition;
            UpdateMatrix();
        }

        private void UpdateMatrix(){
            viewMatrix = Matrix.CreateTranslation(
                -position.X + _viewport.Width - 280,
                -position.Y + _viewport.Height - 90,
                1
            );
        }

    }
}