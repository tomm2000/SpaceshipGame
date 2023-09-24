using Godot;
using System;

public enum LoaderState {
  Idle,
  Loading,
  Loaded,
  Shooting,
  Refreshing,
  Refreshed,
}

public abstract partial class Loader : Resource
{
  private LoaderState State = LoaderState.Idle;
  public void setState(LoaderState state) {
    if (State == state) { return; }

    State = state;

    if (state == LoaderState.Loading) {
      OnLoadingInit?.Invoke();
    }
    if (state == LoaderState.Refreshing) {
      OnRefreshingInit?.Invoke();
    }
    OnStateChanged?.Invoke(this, state);

    UpdateStateMachine();
  }
  public LoaderState getState() {
    return State;
  }

  public event EventHandler<LoaderState> OnStateChanged;

  public void UpdateStateMachine() {
    if (State == LoaderState.Idle) {
      OnIdle?.Invoke();
    } else if (State == LoaderState.Loading) {
      OnLoading?.Invoke();
    } else if (State == LoaderState.Loaded) {
      OnLoaded?.Invoke();
    } else if (State == LoaderState.Shooting) {
      OnShooting?.Invoke();
    } else if (State == LoaderState.Refreshing) {
      OnRefreshing?.Invoke();
    } else if (State == LoaderState.Refreshed) {
      OnRefreshed?.Invoke();
    }
  }

  public event Action OnTick;
  public event Action OnIdle;
  public event Action OnLoadingInit;
  public event Action OnLoading;
  public event Action OnLoaded;
  public event Action OnShooting;
  public event Action OnRefreshingInit;
  public event Action OnRefreshing;
  public event Action OnRefreshed;
}
