using Godot;
using System;

public partial class LifeComponent : Node2D
{
  [Export] public int MaxHealth = 100;
  [Export] public int Health = 100;
  [Export] public bool IsInvincible = false;
  
  public delegate void OnDamagedHandler(int damage, int healthBefore, int healthAfter, Node? source);
  public event OnDamagedHandler OnDamaged;
  public delegate void OnHealthDepletedHandler(int damage, Node? source);
  public event OnHealthDepletedHandler OnHealthDepleted;

  public delegate void OnHealedHandler(int heal, int healthBefore, int healthAfter, Node? source);
  public event OnHealedHandler OnHealed;
  public event Action OnHealthMaxed;

  public delegate void OnHealthChangedHandler(int healthBefore, int healthAfter, Node? source);
  public event OnHealthChangedHandler OnHealthChanged;


  public void Damage(int damage, Node? source = null) {
    if (IsInvincible) { return; }

    int healthBefore = Health;
    Health -= damage;
    if (Health < 0) { Health = 0; }
    int healthAfter = Health;

    OnDamaged?.Invoke(damage, healthBefore, healthAfter, source);
    OnHealthChanged?.Invoke(healthBefore, healthAfter, source);

    if (Health == 0) {
      OnHealthDepleted?.Invoke(damage, source);
    }
  }

  public void Heal(int heal, Node? source = null) {
    int healthBefore = Health;
    Health += heal;
    if (Health > MaxHealth) { Health = MaxHealth; }
    int healthAfter = Health;

    OnHealed?.Invoke(heal, healthBefore, healthAfter, source);
    OnHealthChanged?.Invoke(healthBefore, healthAfter, source);

    if (Health == MaxHealth) {
      OnHealthMaxed?.Invoke();
    }
  }
}
