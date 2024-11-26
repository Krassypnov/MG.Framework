using MG.Framework.Core.Render;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MG.Framework.Core.Entities;

public class Entity : EntityBase
{
    //TODO: move params to class
    private const float speed = 80;
    public override void Draw(SpriteBatch spriteBatch)
    {
        if (!RenderOptions.IsRendered)
            return;

        ApplyOptions();
        spriteBatch.Draw(this.Texture, RenderOptions.Position, this.Color);
    }

    public override void HandleBehavior(GameTime gameTime)
    {
        if (InputDevices != IO.Enums.InputDevices.None)
            HandleInputs(gameTime);

        return;
    }

    private void HandleInputs(GameTime gameTime)
    {
        if (InputDevices == (IO.Enums.InputDevices.Keyboard | IO.Enums.InputDevices.Mouse))
            HandleKeyboard(gameTime);
        if (InputDevices == IO.Enums.InputDevices.Mouse)
            HandleMouse();
    }

    //TODO: refactor input system
    private void HandleKeyboard(GameTime gameTime)
    {
        var keyboardState = Keyboard.GetState();

        if (keyboardState.IsKeyDown(Keys.W))
            position.Y -= (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
        if (keyboardState.IsKeyDown(Keys.S))
            position.Y += (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
        if (keyboardState.IsKeyDown(Keys.D))
            position.X += (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
        if (keyboardState.IsKeyDown(Keys.A))
            position.X -= (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
    }

    private void HandleMouse()
    {
        throw new NotImplementedException();
    }

    private void ApplyOptions()
    {
        if (!RenderOptions.IsOptionsEnabled)
        {
            RenderOptions.SetDefault(this);
            return;
        }

        RenderOptions.Apply(this);
    }
}
