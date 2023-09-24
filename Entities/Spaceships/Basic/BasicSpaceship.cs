using Godot;
using System;

public partial class BasicSpaceship : CharacterBody2D
{
  [Export] int MaxSpeed = 900;
  [Export] int Acceleration = 3;
  [Export] int RotationSpeed = 10;
  [Export] Sprite2D ThrustSprite;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _PhysicsProcess(double delta)
	{
    // thrust
    if (Input.IsActionPressed("thrust"))
    {
      Velocity += new Vector2(1, 0).Rotated(Rotation) * Acceleration;
      ThrustSprite.Show();
    }
    else {
      // velocity = velocity.Lerp(Vector2.Zero, 0.05f);
      ThrustSprite.Hide();
    }

    // rotate
    if (Input.IsActionPressed("left"))
    {
      Rotation -= RotationSpeed * (float)delta / 10;
    }

    if (Input.IsActionPressed("right"))
    {
      Rotation += RotationSpeed * (float)delta / 10;
    }
    
    // move
    if (Velocity.Length() > MaxSpeed)
    {
      Velocity = Velocity.Normalized() * MaxSpeed;
    }

    MoveAndSlide();
	}
}
