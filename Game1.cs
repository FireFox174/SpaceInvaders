using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch Surface;
        bool Start;
        EntityGroup group;
        Obstacle obstacle;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferHeight = 700;
            _graphics.PreferredBackBufferWidth = 900;
            _graphics.ApplyChanges();
            group = new EntityGroup();
            group.Add(new Player());
            obstacle = new Obstacle(Content, 120, 480);
            Start = false;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Surface = new SpriteBatch(GraphicsDevice);
            group.LoadContent(Content);
            obstacle.LoadContent(Content);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (Start)
            {
                obstacle.Update(gameTime, group.List.ToArray());
                group.Update(gameTime);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space)) Start = true;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            obstacle.Draw(Surface);
            group.Draw(Surface);
            base.Draw(gameTime);
        }
    }
}
