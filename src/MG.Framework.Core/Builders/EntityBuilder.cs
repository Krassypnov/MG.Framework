using MG.Framework.Core.Entities;

namespace MG.Framework.Core.Builders;

public class EntityBuilder
{
    public Entity CurrentEntity { get; set; } = new();

    public Entity Build()
    {
        //TODO: Log this
        if (!IsEntityValid())
            return null;

        var entity = CurrentEntity;
        CurrentEntity = new Entity();

        return entity;
    }

    private bool IsEntityValid()
    {
        if (string.IsNullOrWhiteSpace(CurrentEntity.UniqueName))
            return false;

        return true;
    }
}
