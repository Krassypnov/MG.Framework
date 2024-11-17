using MG.Framework.Core.Entities;
using MG.Framework.Core.Extensions;
using Microsoft.Xna.Framework;

namespace MG.Framework.Core.Render;

public class RenderOptions
{
    public Vector2 Position {  get; set; }

    #region Flags
    public bool IsOptionsEnabled { get; set; }
    public bool PositionFromTextureCenter { get; set; }

    #endregion

    internal void SetDefault(Entity entity)
    {
        Position = entity.Position;
    }

    internal void Apply(Entity entity)
    {
        Position = entity.Position;
        if (PositionFromTextureCenter)
        {
            if (entity.Texture != null)
            {
                var center = entity.Texture.GetCenterPoint();
                Position -= center;
            }
        }
    }
}
