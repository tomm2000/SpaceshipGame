using Godot;
using System;

public partial class BasicLoader : Loader
{
  #region STATS
  // refresh rate goes from 0 to infinity, 0 is instant, 1 is 1 shot/tick, 60 is 1 shot/second,...
  [Export] public int RefreshRate = 1;

  // reload rate goes from 0 to infinity, 0 is instant, 1 is 1 shot/tick, 60 is 1 shot/second,...
  [Export] public int ReloadRate = 60;

  // number of bullets in a burst
  [Export] public int BurstSize = 20;

  // if true, burst will be completed even if the controller is not firing
  [Export] public bool ForceBurstComplete = false;
  #endregion

  #region DATA
  private int ammo = 0;
  private Vector2 shootPosition;

  private int loadingTicks = 0;
  private int refreshingTicks = 0;
  #endregion

  public BasicLoader()
  {
    if (RefreshRate == 0 && ReloadRate == 0) {
      GD.PushWarning("RefreshRate and ReloadRate cannot both be 0");
      ReloadRate = 1;
    }

    OnIdle += StateIdle;
    OnLoadingInit += StateLoadingInit;
    OnLoading += StateLoading;
    OnLoaded += StateLoaded;
    OnShooting += StateShooting;
    OnRefreshingInit += StateRefreshingInit;
    OnRefreshing += StateRefreshing;
    OnRefreshed += StateRefreshed;
  }

  public override void Tick(double delta) {
    loadingTicks++;
    refreshingTicks++;
    base.UpdateStateMachine();
  }

  #region STATE MACHINE
  protected void StateIdle() {
    if(controllerActive) {
      setState(LoaderState.Loading);
    }
  }

  protected void StateLoadingInit() {
    loadingTicks = 0;
  }

  protected void StateLoading() {
    if (loadingTicks >= ReloadRate) {
      ammo =BurstSize;
      setState(LoaderState.Loaded);
    }
  }

  protected void StateLoaded() {
    if(controllerActive) {
      setState(LoaderState.Shooting);
    }
  }

  protected void StateShooting() {
    Fire(shootPosition);
    ammo--;

    if (ammo > 0) {
      setState(LoaderState.Refreshing);
    } else {
      setState(LoaderState.Loading);
    }
  }

  protected void StateRefreshingInit() {
    refreshingTicks = 0;
  }

  protected void StateRefreshing() {
    if (refreshingTicks >= RefreshRate) {
      setState(LoaderState.Refreshed);
    }  
  }

  protected void StateRefreshed() {
    if (ForceBurstComplete) {
      setState(LoaderState.Shooting);
    } else {
      setState(LoaderState.Loaded);
    }
  }
  #endregion
}

