using System.Numerics;
using Foster.Framework;

namespace Platformer.Components;

public class Sprite : Component
{

    public Texture Texture { get; set; } = null!;
    public sbyte Facing { get; set; } = 1;
    public Vector2 Squish = new(1f);

    private Transform m_Transform = null!;
    private Rect m_FrameToDraw = new();

    public Sprite(in Transform transform)
    {
        m_Transform = transform;
    }

    public void SetFrame(float x, float y, float w, float h)
    {
        m_FrameToDraw = new(x, y, w, h);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Draw(Batcher batcher)
    {
        batcher.PushMatrix(Matrix3x2.CreateScale(Facing * Squish.X, Squish.Y));
        batcher.Image(Texture, m_FrameToDraw, m_Transform.Position, m_Transform.Origin, m_Transform.Scale, m_Transform.Rotation, Color.White);
        batcher.PopMatrix();
    }
}