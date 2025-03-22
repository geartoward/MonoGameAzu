using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static AZUMANGA.ScreenManager;

namespace AZUMANGA {

public class Game1 : Game
{
    Camera camera2d;
    Player player;

    ScreenManager screenmanager;

    public ScreenState ScreenState_current = ScreenState.TITLE;

    SpriteFont spfont;

    Vector2 fontpos;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Vector3 cameraTopDownPosition = new Vector3(0.0f, 25000.0f, 1.0f);

    Texture2D baal;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = false;
    }

    protected override void Initialize()
    {

        camera2d = new Camera(GraphicsDevice.Viewport);
        _graphics.PreferredBackBufferWidth = 1024;
        _graphics.PreferredBackBufferHeight = 768;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Texture2D balltexture = Content.Load<Texture2D>("Assets/Placeholders/player");
        baal = Content.Load<Texture2D>("Assets/Placeholders/ball");

        spfont = Content.Load<SpriteFont>("Assets/Fonts/gamefont");
        fontpos = new Vector2(0,0);

        player = new Player(balltexture, new Vector2(0,0));

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if (Keyboard.GetState().IsKeyDown(Keys.A)) {
            ScreenState_current = ScreenState.GAME;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.B)) {
            ScreenState_current = ScreenState.ENDING;
        }

        
        player.Update(gameTime);

        Vector2 characterCenter = new Vector2(
            player.position.X + player.texture.Width / 2,
            player.position.Y + player.texture.Height / 2
        );

        camera2d.Update(characterCenter);

       base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        switch (ScreenState_current)
        {
            case ScreenState.TITLE:
                IntroDraw();
            break;

            case ScreenManager.ScreenState.GAME:
                GameDraw(gameTime);
            break;

            case ScreenState.ENDING:
                EndDraw();
            break;

            default:
            break;
            
        }
        

        base.Draw(gameTime);
    }

    protected void GameDraw(GameTime gameTime){
        GraphicsDevice.Clear(Color.CornflowerBlue);

        string text = "This is the game";

        _spriteBatch.Begin();

        _spriteBatch.DrawString(spfont, text, new Vector2(10,10), Color.White);
        _spriteBatch.End();


        _spriteBatch.Begin(transformMatrix: camera2d.viewMatrix);

        _spriteBatch.Draw(baal, Vector2.Zero, Color.White);
        _spriteBatch.Draw(player.texture, player.position, Color.White);

        _spriteBatch.End();
    }

    protected void IntroDraw(){
        GraphicsDevice.Clear(Color.Green);

        string textintro = "Presss A to enter";

        _spriteBatch.Begin();

        _spriteBatch.DrawString(spfont, textintro, new Vector2(360,384), Color.White);
        _spriteBatch.End();

    }

    protected void EndDraw(){
        GraphicsDevice.Clear(Color.Red);

        string textend = "Cool now gtfo";

        _spriteBatch.Begin();

        _spriteBatch.DrawString(spfont, textend, new Vector2(360,384), Color.White);
        _spriteBatch.End();
    }
}
}
