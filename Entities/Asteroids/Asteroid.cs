using Godot;
using System;

public partial class Asteroid : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
    // randomize rotation
    var random = new Random();
    Rotation = (float)random.NextDouble() * 360;

    // randomize scale
    var scale = (float) random.NextDouble() + 1f;
    Scale = new Vector2(scale, scale);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
