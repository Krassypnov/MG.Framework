using MG.Framework.Core.Entities;
using MG.Framework.Core.Render;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MG.Framework.Core.Game;

public class GameManager
{
    public RenderManager RenderManager { get; private set; }

    private static GameManager instance;

    private readonly Dictionary<string, Entity> entities;
    private readonly SpriteBatch spriteBatch;
    private GameTime gameTime;

    private GameManager(SpriteBatch spriteBatch)
    {
        entities = new Dictionary<string, Entity>();
        this.spriteBatch = spriteBatch ?? throw new ArgumentNullException(nameof(spriteBatch));
    }

    public static GameManager GetOrCreateInstance(SpriteBatch spriteBatch)
    {
        instance ??= new GameManager(spriteBatch);

        return instance;
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public Entity GetEntity(string name)
    {
        if (entities.TryGetValue(name, out var entity))
            return entity;

        return null;
    }

    public IEnumerable<Entity> GetEntities()
    {
        return entities.Values;
    }

    public bool AddEntity(Entity entity)
    {
        if (entity == null)
            return false;

        return entities.TryAdd(entity.UniqueName, entity);
    }

    public void RemoveEntity(string entityName)
    {
        entities.Remove(entityName);
    }

    public void HandleAllBehaviors()
    {
        
    }

    public void RenderEntities()
    {
        spriteBatch.Begin();

        foreach (var entity in entities.Values)
        {
            entity.Draw(spriteBatch);
        }

        spriteBatch.End();
    }

    public void Update(GameTime gameTime)
    {
        this.gameTime = gameTime;
        
        foreach (var entity in entities.Values)
        {
            entity.HandleBehavior(gameTime);
        }
    }

    public GameTime GetGameTime()
        => gameTime;
}
