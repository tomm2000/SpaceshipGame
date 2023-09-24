using Godot;
using System;

public partial class PlayerController : Controller {
  public override void Tick(double delta) {
    if (Input.IsActionJustPressed("shoot")) {
      InvokeFireStart();
    } else if (Input.IsActionJustReleased("shoot")) {
      InvokeFireEnd();
    }

    InvokeTarget(parent.GetGlobalMousePosition());
  }
}
