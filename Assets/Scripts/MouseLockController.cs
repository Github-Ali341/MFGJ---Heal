using UnityEngine;

public class MouseLockController : MonoBehaviour
{
    private void Update ()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Cursor.lockState = Cursor.lockState switch
            {
                CursorLockMode.Locked => CursorLockMode.None,
                CursorLockMode.None => CursorLockMode.Locked,
                _ => Cursor.lockState
            };
        }
    }
}
