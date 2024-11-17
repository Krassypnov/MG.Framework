using MG.Framework.Core.Render;
using MG.Framework.Core.Render.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace MG.Framework.Core.Entities;

public class Entity : EntityBase, IDrawableEntity
{
    private int layer = 0;
    public int Layer { get => layer; set => layer = value; }

    public void Draw(SpriteBatch spriteBatch)
    {
        ApplyOptions();
        spriteBatch.Draw(this.Texture, RenderOptions.Position, this.Color);
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
