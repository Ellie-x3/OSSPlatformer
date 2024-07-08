using System.Numerics;
using Foster.Framework;
using Platformer.Actors;
using Platformer.Resources;

namespace Platformer;

public class Program {
    public static void Main() {
        App.Register<Game>();
        App.Run("Platformer", 1280, 720);
    }
}

public class Game : Module {

    public const int WIDTH = 320;
    public const int HEIGHT = 180;

    private readonly Batcher m_Batcher = new();
    private readonly Target m_Screen = new(WIDTH, HEIGHT);

    private Player p = null!;

    public override void Startup() { 
        base.Startup();
        Assets.Load();
        p = new Player();
        p.Start();
    }

    public override void Update() {
        base.Update();

        p.Update();
    }

    public override void Render() {
        {
            m_Screen.Clear(Color.CornflowerBlue);
            
            m_Batcher.PushMatrix((Point2)p.Position);
            p.Draw(m_Batcher);
            m_Batcher.PopMatrix();

            m_Batcher.Render(m_Screen);
            m_Batcher.Clear();
        }

        {
            m_Batcher.SetSampler(new(TextureFilter.Nearest, TextureWrap.ClampToEdge, TextureWrap.ClampToEdge));
            m_Batcher.Image(m_Screen, 
                            new Vector2(0, 0), 
                            new Vector2(0,0), 
                            new Vector2(App.SizeInPixels.X / m_Screen.Bounds.Width, App.SizeInPixels.Y / m_Screen.Bounds.Height), 
                            0f, 
                            Color.White
                        );
                        
            m_Batcher.Render();
            m_Batcher.Clear();
        }
    }
}