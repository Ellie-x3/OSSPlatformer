using Foster.Framework;

namespace Platformer.Components;

public interface IComponent {
    void Update();
    void Draw(Batcher batcher);
}