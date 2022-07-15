using UnityEngine;

public class MouseLockController : MonoBehaviour
{
    private void Start ()
    {
        GameManager.Instance.OnGameStateChanged += Instance_OnGameStateChanged;
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Instance_OnGameStateChanged (GameState obj)
    {
        Cursor.lockState = obj switch
        {
            GameState.Normal => CursorLockMode.Locked,
            _ => CursorLockMode.None,
        };
    }

    private void OnDestroy () 
    {
        GameManager.Instance.OnGameStateChanged -= Instance_OnGameStateChanged;
    }
}
