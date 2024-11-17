using MG.Framework.Core.Render;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MG.Framework.Core.Entities;

public abstract class EntityBase
{
    public Vector2 Position { get; set; }
    public Texture2D Texture {  get; set; }
    public Color Color { get; set; }
    public RenderOptions RenderOptions { get; set; } = new();

    public EntityBase()
    {
        Position = Vector2.Zero;
    }
}
