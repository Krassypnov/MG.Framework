using Microsoft.Xna.Framework.Graphics;

namespace MG.Framework.Core.Render.Interfaces;

public interface IDrawableEntity
{
    public int Layer { get; set; }

    public void Draw(SpriteBatch spriteBatch);
}
