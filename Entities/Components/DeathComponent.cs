using Godot;
using System;

public partial class DeathComponent : Node2D
{
	[Export] public LifeComponent? LifeComponent;
  [Export] public DropComponent? DropComponent;

  public delegate void OnDeathHandler(Node? source);
  public event OnDeathHandler OnDeath;

  public override void _Ready() {
    if (LifeComponent == null) { return; }

    LifeComponent.OnHealthDepleted += HandleDeath;
  }

  public void HandleDeath(int damage, Node? source = null) {
    OnDeath?.Invoke(source);
    GetParent().QueueFree();
  }
}
