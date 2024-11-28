using Microsoft.Xna.Framework;

namespace MG.Framework.Core.Extensions;

public static class GraphicExtensions
{

    public static Vector2 GetCenter(this GraphicsDeviceManager graphics)
        => new (graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
}
