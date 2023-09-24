using Godot;
using System;

public partial class ZoomCamera2D : Camera2D
{
  [Export] public float MinZoom = 0.5f;
  [Export] public float MaxZoom = 4.0f;
  [Export] public float ZoomFactor = 0.1f;
  [Export] public float ZoomDuration = 0.5f;

  private float _zoomTarget = 1.0f;
  private float ZoomTarget {
    get => _zoomTarget;
    set {
      _zoomTarget = Mathf.Clamp(value, MinZoom, MaxZoom);
      AnimateZoom();
    }
  }

  private float _zoomLevel = 1.0f;
  private float ZoomLevel {
    get => _zoomLevel;
    set {
      _zoomLevel = value;
      Zoom = Vector2.One * _zoomLevel;
    }
  }

  public Tween tween;


  public void AnimateZoom() {
    tween?.Kill();
    tween = CreateTween();

    tween.TweenProperty(this, "ZoomLevel", _zoomTarget, ZoomDuration).SetTrans(Tween.TransitionType.Sine).SetEase(Tween.EaseType.Out);
  }


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

  public override void _UnhandledInput(InputEvent @event) {
    base._UnhandledInput(@event);

    if(@event.IsActionPressed("zoom_in")) {
      ZoomTarget += ZoomFactor;
    }
    if(@event.IsActionPressed("zoom_out")) {
      ZoomTarget -= ZoomFactor;
    }
  }
}
