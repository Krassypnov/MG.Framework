using MG.Framework.Core.Builders;
using MG.Framework.Core.Entities;
using MG.Framework.Core.IO.Enums;
using MG.Framework.Core.IO.Modules;
using MG.Framework.Core.Render;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MG.Framework.Core.Extensions.Builder;

public static class EntityBuilderExtensions
{

    public static EntityBuilder WithPosition(this EntityBuilder builder, Vector2 position)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        builder.CurrentEntity.Position = position;

        return builder;
    }

    public static EntityBuilder WithTexture(this EntityBuilder builder, Texture2D texture)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        ArgumentNullException.ThrowIfNull(texture, nameof(texture));

        builder.CurrentEntity.Texture = texture;

        return builder;
    }

    public static EntityBuilder WithName(this EntityBuilder builder, string name)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        builder.CurrentEntity.UniqueName = name;

        return builder;
    }

    public static EntityBuilder WithColor(this EntityBuilder builder, Color color)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        builder.CurrentEntity.Color = color;

        return builder;
    }

    public static EntityBuilder WithRenderOptions(this EntityBuilder builder, RenderOptions renderOptions)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        ArgumentNullException.ThrowIfNull(renderOptions, nameof(renderOptions));

        builder.CurrentEntity.RenderOptions = renderOptions;

        return builder;
    }

    public static EntityBuilder WithInputDevices(this EntityBuilder builder, params InputDevices[] inputDevices)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        ArgumentNullException.ThrowIfNull(inputDevices, nameof(inputDevices));

        foreach (var inputDevice in inputDevices)
            builder.CurrentEntity.InputDevices |= inputDevice;

        return builder;
    }

    public static EntityBuilder WithDefaultKeyActions(this EntityBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        builder.CurrentEntity.KeyActions.Add(new MovementModule());

        return builder;
    }
}
