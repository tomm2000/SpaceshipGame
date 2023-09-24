using Godot;
using System;

public abstract partial class Loader : Resource
{
  public Loader() {
    
  }

  protected Turret parent;
  public void Init(Turret parent) { this.parent = parent; }

  public event EventHandler<Vector2> LoaderFire;

  protected bool controllerActive = false;
  public void setControllerActive(bool active) {
    controllerActive = active;
  }

  public abstract void Tick(double delta);

  protected void Fire(Vector2 position)
  {
    LoaderFire.Invoke(this, position);
  }
}
