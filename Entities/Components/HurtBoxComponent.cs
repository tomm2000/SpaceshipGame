using Godot;
using System;

public partial class HurtBoxComponent : Area2D
{
  [Export] public int Damage = 1;
  [Export] public DeathComponent? DeathComponent;

  public delegate void OnHitHandler(HitBoxComponent hitBox);
  public event OnHitHandler? OnHit;

	public override void _Ready() {
    base._Ready();

    BodyEntered += HandleBodyEntered;
    AreaEntered += HandleBodyEntered;
  }

  public void HandleBodyEntered(Node body) {
    if (body is HitBoxComponent hitBox) {
      hitBox.ApplyDamage(1);
      OnHit?.Invoke(hitBox);
      
      DeathComponent?.HandleDeath(Damage, hitBox);
    }
  }
}
