using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MG.Framework.Core.Extensions;

public static class Texture2DExtensions
{
    public static Vector2 GetCenterPoint(this Texture2D texture)
        => new(texture.Width / (float)2, texture.Height / (float)2);
}
