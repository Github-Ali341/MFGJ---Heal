using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class GameManager : MonoBehaviour
{
    public event Action<GameState> OnGameStateChanged;

    private GameState _current;

    private void Start ()
    {
        PlayerHealth.Instance.OnDestroyed += Instance_OnDestroyed;
        PlayerHealth.Instance.OnReachedGoal += Instance_OnReachedGoal; ;
    }

    private void Instance_OnReachedGoal ()
    {
        SetState(GameState.Win);
    }

    private void Instance_OnDestroyed ()
    {
        SetState(GameState.Lose);
    }

    private void SetState (GameState gameState)
    {
        if (_current == gameState) return;
        if (_current == GameState.Paused && gameState != GameState.Normal) return;
        if ((_current == GameState.Win || _current == GameState.Lose) && gameState != GameState.Normal) return;

        _current = gameState;
        OnGameStateChanged?.Invoke(gameState);

        //if (gameState != GameState.Normal) Time.timeScale = 0;
        //else Time.timeScale = 1;
    }

    public void TogglePause (InputAction.CallbackContext c)
    {
        if (!c.performed) return;

        TogglePauseBase();
    }

    public void TogglePause () => TogglePauseBase();

    private void TogglePauseBase ()
    {
        SetState(_current switch
        {
            GameState.Paused => GameState.Normal,
            GameState.Normal => GameState.Paused,
            _ => _current
        });
    }

    private void OnDestroy ()
    {
        PlayerHealth.Instance.OnDestroyed -= Instance_OnDestroyed;
        PlayerHealth.Instance.OnReachedGoal -= Instance_OnReachedGoal;
    }
}

public enum GameState
{
    Normal,
    Paused,
    Lose,
    Win
}