using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace AZUMANGA {

internal class Player : Sprite {

    public Player(Texture2D texture, Vector2 position) : base(texture, position) {}

    float playerspeed = 15f;

    public void Update(GameTime gameTime){
        var kstate = Keyboard.GetState();

        if (kstate.IsKeyDown(Keys.Up)){
            position.Y -= playerspeed;
        }
        
        if (kstate.IsKeyDown(Keys.Down)){
            position.Y += playerspeed;
        }

        if (kstate.IsKeyDown(Keys.Right)){
            position.X += playerspeed;
        }
        
        if (kstate.IsKeyDown(Keys.Left)){
            position.X -= playerspeed;
        }

    }

}
}