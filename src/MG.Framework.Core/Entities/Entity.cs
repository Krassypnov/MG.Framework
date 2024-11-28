using MG.Framework.Core.Render;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MG.Framework.Core.Entities;

public class Entity : EntityBase
{
    //TODO: move params to class
    public float Speed { get; set; } = 80;

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

        foreach (var action in KeyActions)
        {
            action.DoAction(this, keyboardState, gameTime);
        }
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
