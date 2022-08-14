using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;

public class GameManager : Singleton<GameManager>
{
    public event Action<GameState> OnGameStateChanged;

    private GameState _current;

    private void Start ()
    {
        SetState(GameState.Normal);

        Player.Instance.OnDestroyed += Instance_OnDestroyed;
        Player.Instance.OnReachedGoal += Instance_OnReachedGoal;
        Controls.InputActions.Game.Pause.performed += TogglePauseInputSystem;
    }

    private void OnDestroy ()
    {
        Player.Instance.OnDestroyed -= Instance_OnDestroyed;
        Player.Instance.OnReachedGoal -= Instance_OnReachedGoal;
        Controls.InputActions.Game.Pause.performed -= TogglePauseInputSystem;
    }

    public void LoadCurrent ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Instance_OnReachedGoal () => SetState(GameState.Win);
    private void Instance_OnDestroyed () => SetState(GameState.Lose);

    private void SetState (GameState gameState)
    {
        if (_current == GameState.Paused && gameState != GameState.Normal) return;
        // Prevents pausing while endgame.
        if ((_current == GameState.Win || _current == GameState.Lose) && gameState != GameState.Normal) return;

        if (gameState != GameState.Normal) Time.timeScale = 0;
        else Time.timeScale = 1;

        _current = gameState;
        OnGameStateChanged?.Invoke(gameState);
    }

    public void TogglePauseInputSystem (InputAction.CallbackContext c)
    {
        if (!c.performed) return;

        TogglePause();
    }

    public void TogglePauseNoParameters ()
    {
        TogglePause();
    }

    private void TogglePause ()
    {
        SetState(_current switch
        {
            GameState.Paused => GameState.Normal,
            GameState.Normal => GameState.Paused,
            _ => _current
        });
    }
}