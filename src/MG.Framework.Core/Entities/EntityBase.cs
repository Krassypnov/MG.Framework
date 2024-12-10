using MG.Framework.Core.IO.Enums;
using MG.Framework.Core.IO.Modules;
using MG.Framework.Core.Render;
using MG.Framework.Core.Render.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MG.Framework.Core.Entities;

public abstract class EntityBase : IDrawableEntity
{
    protected Vector2 position;
    protected string name = string.Empty;

    public string UniqueName 
    {
        get
        {
            return name;
        }
        set
        {
            if (name != string.Empty)
                return;
            name = value;
        } 
    }
    public Guid Id { get; init; }
    public Vector2 Position {  get { return position; } set { position = value; } }
    public Texture2D Texture {  get; set; }
    public Color Color { get; set; }
    public RenderOptions RenderOptions { get; set; } = new();
    public int Layer { get; set; } = 0;

    public InputDevices InputDevices { get; set; } = InputDevices.None;
    public List<KeyActionModuleBase> KeyActions { get; set; } = new();

    public EntityBase()
    {
        Position = Vector2.Zero;
        Id = Guid.NewGuid();
    }

    public abstract void HandleBehavior(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch);

    public void MoveX(float x)
    {
        position.X += x;
    }

    public void MoveY(float y)
    {
        position.Y += y;
    }
}
