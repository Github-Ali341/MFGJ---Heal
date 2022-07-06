using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Normal,
        Paused,
        Lose,
        Win
    }

    private GameState _current;

    private void SetState (GameState gameState) => _current = gameState;
    public GameState GetCurrent () => _current;

    private void Start ()
    {
        PlayerHealth.Instance.OnDestroyed += () =>
        {
            SetState(GameState.Lose);
        };
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

        Debug.Log(_current);
    }
}
