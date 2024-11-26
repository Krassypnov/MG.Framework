using MG.Framework.Core.IO.Enums;
using MG.Framework.Core.Render;
using MG.Framework.Core.Render.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MG.Framework.Core.Entities;

public abstract class EntityBase : IDrawableEntity
{
    protected Vector2 position;

    public Vector2 Position {  get { return position; } set { position = value; } }
    public Texture2D Texture {  get; set; }
    public Color Color { get; set; }
    public RenderOptions RenderOptions { get; set; } = new();
    public InputDevices InputDevices { get; set; } = InputDevices.None;
    public int Layer { get; set; } = 0;

    public EntityBase()
    {
        Position = Vector2.Zero;
    }

    public abstract void HandleBehavior(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch);
}
