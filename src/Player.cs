using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Runtime.Serialization;

namespace AZUMANGA {

internal class Player : Sprite {

    // States for movement
    enum PlayerStates {
        IDLE,
        LR,
        UD
    }

    public Player(Texture2D texture, Vector2 position) : base(texture, position) {}

    float playerspeed = 150f;

    // Up down movement
    private void Move_ud(GameTime gameTime){
        var kstate = Keyboard.GetState();

        if (kstate.IsKeyDown(Keys.Up)){
            position.Y -= playerspeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        } 
        
        if (kstate.IsKeyDown(Keys.Down)){
            position.Y += playerspeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        } 

    }

    // Left right movement
    private void Move_lr(GameTime gameTime){
        var kstate = Keyboard.GetState();

        if (kstate.IsKeyDown(Keys.Right)){
            position.X += playerspeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        } 
        
        if (kstate.IsKeyDown(Keys.Left)){
            position.X -= playerspeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        } 
    }
    

    public void Update(GameTime gameTime){

    }

}
}