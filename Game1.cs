using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AZUMANGA {

public class Game1 : Game
{

    Player player;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D baal;

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

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Texture2D balltexture = Content.Load<Texture2D>("Assets/Placeholders/player");
        baal = Content.Load<Texture2D>("Assets/Placeholders/ball");

        player = new Player(balltexture, new Vector2(500, 500));

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        player.Update(gameTime);

       base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        
        _spriteBatch.Draw(player.texture, player.position, Color.White);
        _spriteBatch.Draw(baal, Vector2.Zero, Color.White);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
}
