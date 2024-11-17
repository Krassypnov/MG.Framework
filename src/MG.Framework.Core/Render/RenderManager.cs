using MG.Framework.Core.Render.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace MG.Framework.Core.Render;

public class RenderManager
{
    private List<IDrawableEntity> drawbles;

    public RenderManager()
    {
        drawbles = new List<IDrawableEntity>();
    }


    public void AddDrawble(IDrawableEntity item)
    {
        drawbles.Add(item);
        drawbles = drawbles.OrderBy(x => x.Layer).ToList();
    }

    public void RemoveDrawble(IDrawableEntity item)
    {
        drawbles.Remove(item);
    }

    public void DrawAll(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();

        foreach (IDrawableEntity item in drawbles)
            item.Draw(spriteBatch);

        spriteBatch.End();
    }
}
