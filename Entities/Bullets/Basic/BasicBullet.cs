using Godot;
using System;

public partial class BasicBullet : Node2D
{
  [Export] public Timer LifespanTimer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
    LifespanTimer.Timeout += () => {
      QueueFree();
    };
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
    // move forward
    Vector2 velocity = new Vector2(1, 0);
    velocity = velocity.Rotated(Rotation);
    GlobalPosition += velocity * 10;
	}
}
