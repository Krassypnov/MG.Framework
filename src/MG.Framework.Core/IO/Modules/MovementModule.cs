using MG.Framework.Core.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MG.Framework.Core.IO.Modules;

public class MovementModule : KeyActionModuleBase
{
    private float SpeedModifier = 2.5f;
    public override void DoAction(Entity entity, KeyboardState keyboardState, GameTime gameTime)
    {
        var deltaPosition = (float)gameTime.ElapsedGameTime.TotalSeconds * entity.Speed;

        if (keyboardState.IsKeyDown(Keys.LeftShift))
            deltaPosition *= SpeedModifier;
        else
            deltaPosition *= 1f;

        if (keyboardState.IsKeyDown(Keys.W))
            entity.MoveY(-deltaPosition);
        if (keyboardState.IsKeyDown(Keys.S))
            entity.MoveY(deltaPosition);
        if (keyboardState.IsKeyDown(Keys.D))
            entity.MoveX(deltaPosition);
        if (keyboardState.IsKeyDown(Keys.A))
            entity.MoveX(-deltaPosition);
    }
}
