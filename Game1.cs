using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static AZUMANGA.ScreenManager;
using MonoGame.Extended;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.ViewportAdapters;

namespace AZUMANGA {

public class Game1 : Game
{
    TiledMap _tiledMap;
    TiledMapRenderer _tiledMapRenderer;
    private OrthographicCamera _camera;
    Player player;

    public ScreenState ScreenState_current = ScreenState.TITLE;

    SpriteFont spfont;

    Vector2 fontpos;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Vector3 cameraTopDownPosition = new Vector3(0.0f, 25000.0f, 1.0f);

    Texture2D bg;
    private Vector2 _cameraPosition;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = false;
    }

    protected override void Initialize()
    {

        _graphics.PreferredBackBufferWidth = 1024;
        _graphics.PreferredBackBufferHeight = 768;
        _graphics.ApplyChanges();

        var viewportadapter = new BoxingViewportAdapter(Window, GraphicsDevice, 1024, 768);
        _camera = new OrthographicCamera(viewportadapter);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Texture2D balltexture = Content.Load<Texture2D>("Placeholders/player");

        spfont = Content.Load<SpriteFont>("Fonts/gamefont");
        fontpos = new Vector2(0,0);

        player = new Player(balltexture, Vector2.Zero);

        bg = Content.Load<Texture2D>("Placeholders/bgs/bg");

        _tiledMap = Content.Load<TiledMap>("Maps/map1");
        _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);

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


        _tiledMapRenderer.Update(gameTime);
        _camera.LookAt(player.position);
        _cameraPosition = player.position;

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

        _spriteBatch.Begin();

        _tiledMapRenderer.Draw(_camera.GetViewMatrix());
        _spriteBatch.Draw(player.texture, player.position, Color.White);

        _spriteBatch.End();

        string text = "This is the game";

        _spriteBatch.Begin();

        _spriteBatch.DrawString(spfont, text, new Vector2(10,10), Color.White);
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
