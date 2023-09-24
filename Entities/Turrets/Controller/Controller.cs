using Godot;
using System;

public abstract partial class Controller : Resource
{
  public delegate void TargetHandler(object sender, Vector2 position);
  public event TargetHandler OnTarget; 
  public event Action<Controller> OnFireStart;
  public event Action<Controller> OnFireEnd;

  public abstract void Tick(double delta);

  protected Turret parent;
  public void Init(Turret parent) { this.parent = parent; }

  public void InvokeTarget(Vector2 position)
  {
    OnTarget?.Invoke(this, position);
  }

  public void InvokeFireStart()
  {
    OnFireStart?.Invoke(this);
  }

  public void InvokeFireEnd()
  {
    OnFireEnd?.Invoke(this);
  }
}
