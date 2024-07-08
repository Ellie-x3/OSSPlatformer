using System.Numerics;

namespace Platformer.Components;

public class Transform : Component
{
    public Vector2 Position;
    public Vector2 Scale;
    public Vector2 Origin;
    public float Rotation;

    public Transform(Vector2 pos, Vector2 scale, Vector2 origin, float rotation = 0f)
    {
        Position = pos;
        Scale = scale;
        Origin = origin;
        Rotation = rotation;
    }

    public void Translate(Vector2 move)
    {
        Position += move;
    }

    public override void Update()
    {
        //Console.WriteLine(Position);
    }
}