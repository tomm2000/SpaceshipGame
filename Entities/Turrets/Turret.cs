using Godot;
using System;

public abstract partial class Turret : Node2D
{
  [Export] public PackedScene BulletScene;
  [Export] public Marker2D RotationAnchor;
  [Export] public Marker2D MuzzleAnchor;
  [Export] public Loader Loader;
  [Export] public Controller Controller;

  public abstract void Shoot();

  public void AimTo(Vector2 position)
  {
    Vector2 aim = position - RotationAnchor.GlobalPosition;
    GlobalRotation = aim.Angle();
  }

  public override void _Ready()
  {
    Loader.Init(this);
    Controller.Init(this);

    Controller.OnTarget += (_, position) => {
      AimTo(position);
    };

    Controller.OnFireStart += (_) => {
      Loader.setControllerActive(true);
    };

    Controller.OnFireEnd += (_) => {
      Loader.setControllerActive(false);
    };

    Loader.LoaderFire += (_, position) => {
      Shoot();
    };
  }

  public override void _Process(double delta)
  {
    base._Process(delta);
    Controller.Tick(delta);
    Loader.Tick(delta);
  }
}
