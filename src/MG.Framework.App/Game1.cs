using MG.Framework.Core.Builders;
using MG.Framework.Core.Entities;
using MG.Framework.Core.Events;
using MG.Framework.Core.Events.Modules;
using MG.Framework.Core.Extensions;
using MG.Framework.Core.Extensions.Builder;
using MG.Framework.Core.Game;
using MG.Framework.Core.IO.Enums;
using MG.Framework.Core.IO.Mouse;
using MG.Framework.Core.Render;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using System;

namespace MG.Framework.App
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        private GameManager gameManager;
        private EntityBuilder entityBuilder;
        private EventManager eventManager;

        private SpriteBatch spriteBatch;

        private Texture2D texture;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1800;
            _graphics.PreferredBackBufferHeight = 1000;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: Add your initialization logic here
            entityBuilder = new EntityBuilder();
            gameManager = GameManager.GetOrCreateInstance(spriteBatch);
            eventManager = new EventManager();

            base.Initialize();
        }

        protected override void LoadContent()
        {

            // TODO: use this.Content to load your game content here
            texture = Content.Load<Texture2D>("demon_sprite");



            var testEntity = entityBuilder.WithTexture(texture)
                                          .WithPosition(new Vector2(100, 100))
                                          .WithColor(Color.White)
                                          .WithRenderOptions(new RenderOptions { IsRendered = true, IsOptionsEnabled = true, PositionFromTextureCenter = true })
                                          .WithInputDevices(InputDevices.Keyboard, InputDevices.Mouse)
                                          .WithDefaultKeyActions()
                                          .Build();


            gameManager.AddEntity("entity 1", testEntity);

            eventManager.AddPeriodicEvent(TimeSpan.FromSeconds(1), LogEventModule.LogTime);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            eventManager.HandleEvents();
            gameManager.Update(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            var screenCenter = _graphics.GetCenter();

            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            //spriteBatch.DrawCircle(new CircleF(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), 30), 20, Color.White);
            spriteBatch.DrawRectangle(new RectangleF(screenCenter.X - 50, screenCenter.Y - 50, 100, 100), Color.LimeGreen, 100);
            //spriteBatch.DrawRectangle
            spriteBatch.End();

            // TODO: Add your drawing code here
            gameManager.RenderEntities();

            base.Draw(gameTime);
        }
    }
}
