using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace AZUMANGA {

internal class Player : Sprite {

    // States for movement
    public enum PlayerStates {
        IDLE,
        LR,
        UD
    };

    public PlayerStates currentstate = PlayerStates.IDLE;

    public Player(Texture2D texture, Vector2 position) : base(texture, position) {}

    float playerspeed = 300f;

    public void Update(GameTime gameTime){
        KeyboardState kstate = Keyboard.GetState();

        float Deltatime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        bool right = kstate.IsKeyDown(Keys.Right);
        bool left = kstate.IsKeyDown(Keys.Left);
        bool up = kstate.IsKeyDown(Keys.Up);
        bool down = kstate.IsKeyDown(Keys.Down);

        bool anyx = left || right;
        bool anyy = up || down;

        if (anyx){
            currentstate = PlayerStates.LR;
        }
        else if (anyy){
            currentstate = PlayerStates.UD;
        } else {
            currentstate = PlayerStates.IDLE;
        }

        switch(currentstate){
            case PlayerStates.LR:
                Update_PlayerX(right, left, Deltatime);
            break;

            case PlayerStates.UD:
                Update_PlayerY(up, down, Deltatime);
            break;

            case PlayerStates.IDLE:
            break;

        }
                   

    }

    private void Update_PlayerY(bool up, bool down, float Deltatime){

        if (up){
            position.Y -= playerspeed * Deltatime;
        }
        
        else if (down){
            position.Y += playerspeed * Deltatime;
        }

    }
    private void Update_PlayerX(bool left, bool right, float Deltatime){
        if (left){
            position.X += playerspeed * Deltatime;
        } 
        
        else if (right){
            position.X -= playerspeed * Deltatime;
        }
    }
    


}
}