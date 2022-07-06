using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class GameManager : MonoBehaviour
{
    public event Action<GameState> OnGameStateChanged;

    private GameState _current;

    private void SetState (GameState gameState)
    {
        if (_current == gameState) return;
        if (_current == GameState.Paused && gameState != GameState.Normal) return;
        if ((_current == GameState.Win || _current == GameState.Lose) && gameState != GameState.Normal) return;

        _current = gameState;
        OnGameStateChanged?.Invoke(gameState);
    }

    private void Update ()
    {
        if (Input.GetKeyUp(KeyCode.L)) SetState(GameState.Lose);
        if (Input.GetKeyUp(KeyCode.I)) SetState(GameState.Win);
    }

    public void TogglePause (InputAction.CallbackContext c)
    {
        if (!c.performed) return;

        SetState(_current switch
        {
            GameState.Paused => GameState.Normal,
            GameState.Normal => GameState.Paused,
            _ => _current
        });
    }
}

public enum GameState
{
    Normal,
    Paused,
    Lose,
    Win
}