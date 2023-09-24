using Godot;
using System;

public partial class HitBoxComponent : Area2D
{
	[Export] public LifeComponent? LifeComponent;

  public override void _Ready() {
    base._Ready();
  }

  public void ApplyDamage(int damage) {
    LifeComponent?.Damage(damage, this);
  }

  public void ApplyHeal(int heal) {
    LifeComponent?.Heal(heal, this);
  }
}
