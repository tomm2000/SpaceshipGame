using Godot;
using System;

public partial class World : Node
{
  [Export] public Label FPSLabel;
  [Export] public Label PositionLabel;
  [Export] public PackedScene AsteroidScene;
  [Export] public Node2D Player;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
    var radius = 10000;

    var random = new Random();
    for (int i = 0; i < 400; i++) {
      var asteroid = AsteroidScene.Instantiate<Node2D>();
      asteroid.Position = new Vector2(random.Next(radius*2)-radius, random.Next(radius*2)-radius);
      AddChild(asteroid);
    }
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
    FPSLabel.Text = "FPS: " + Engine.GetFramesPerSecond();
    PositionLabel.Text = $"Position: {Math.Round(Player.Position.X)}, {Math.Round(Player.Position.Y)}";
	}
}
