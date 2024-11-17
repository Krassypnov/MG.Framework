using MG.Framework.Core.Entities;

namespace MG.Framework.Core.Builders;

public class EntityBuilder
{
    public Entity CurrentEntity { get; set; } = new();

    public Entity Build()
    {
        var entity = CurrentEntity;
        CurrentEntity = new Entity();

        return entity;
    }
}
