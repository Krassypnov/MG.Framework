namespace MG.Framework.Core.IO.Enums;

[Flags]
public enum InputDevices
{
    None = 0,
    Keyboard = 1 << 0,
    Mouse = 1 << 1,
}
