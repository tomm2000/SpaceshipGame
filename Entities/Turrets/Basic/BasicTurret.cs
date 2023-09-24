using Godot;
using System;

public partial class BasicTurret : Turret
{
  [Export(PropertyHint.Range,"0,1000,1")] public int BulletSpread = 1;
  
	public override void _Process(double delta)
	{
    // call the _Process() function from BurstTurret.cs
    base._Process(delta);
	}

  public override void Shoot()
  {
    BasicBullet bullet = BulletScene.Instantiate<BasicBullet>();
    GetTree().Root.AddChild(bullet); 

    bullet.GlobalPosition = MuzzleAnchor.GlobalPosition;
    bullet.Rotation = GlobalRotation;

    // randomize bullet direction
    float spread = (float)BulletSpread / 1000f * Mathf.Pi * 2f;
    bullet.Rotation += (float)GD.RandRange(-spread, spread);
  }
}
