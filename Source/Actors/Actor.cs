using System.Numerics;
using Foster.Framework;
using Platformer.Components;

namespace Platformer.Actors;

public abstract class Actor {
    public string Tag { get; protected set; } = "Default";
    
    public static readonly List<IComponent> Components = new();

    protected void AddComponent(Component c) {
        Components.Add(c);
        c.Owner = this;
    }

    public virtual void Start() {
        AttachComponents();
    }

    public void Draw(Batcher batcher){
        foreach(IComponent c in Components){
            if(c is not Sprite) continue;

            c.Draw(batcher);
        }
    }

    public virtual void Update(){
        foreach(IComponent c in Components){
            c.Update();
        }
    }

    private void AttachComponents(){
        var fields = GetType().GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

        foreach (var field in fields){
            var attr = field.GetCustomAttributes(typeof(ComponentAttribute), false);

            if(attr.Length > 0){
                var c = (Component?)field.GetValue(this);
                if(c != null)
                    AddComponent(c);
            }
        }
    }
}