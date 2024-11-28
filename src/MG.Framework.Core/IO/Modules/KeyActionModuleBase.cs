using MG.Framework.Core.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MG.Framework.Core.IO.Modules;

public abstract class KeyActionModuleBase
{
    public abstract void DoAction(Entity entity, KeyboardState keyboardState, GameTime gameTime);
}
