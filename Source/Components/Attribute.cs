namespace Platformer.Components;

[AttributeUsage(AttributeTargets.Field)]
public class ComponentAttribute : Attribute
{
    public Type ComponentType { get; }

    public ComponentAttribute(Type c)
    {
        ComponentType = c;
    }
}