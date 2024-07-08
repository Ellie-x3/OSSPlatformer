using Platformer.Actors;
using Foster.Framework;

namespace Platformer.Components;

public abstract class Component : IComponent
{
    public Actor Owner = null!;
    public virtual void Update() { }
    public virtual void Draw(Batcher batcher) { }
}