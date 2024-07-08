using System.Numerics;
using Foster.Framework;
using Platformer.Components;
using Platformer.Resources;

namespace Platformer.Actors;

public class Player : Actor {

    public Vector2 Position => m_Transform!.Position;

    [Component(typeof(Components.Transform))]
    private Components.Transform? m_Transform = null!;

    [Component(typeof(Sprite))]
    private Sprite? m_Sprite = null!;

    private readonly VirtualStick Move = new();

    public Player() {
        Move.Add(Keys.A, Keys.D, Keys.W, Keys.S);
    }

    public override void Start(){
        m_Transform = new(new Vector2(50, 50), Vector2.One, Vector2.Zero, 0f);
        m_Sprite = new(m_Transform) {
            Texture = Assets.Textures["hero_idle"]
        };

        base.Start();
    }

    public override void Update()
    {
        base.Update();
        
        m_Transform?.Translate(new Vector2(Move.IntValue.X, 0f));
    }
}