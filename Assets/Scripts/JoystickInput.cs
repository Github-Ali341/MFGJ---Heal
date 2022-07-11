using UnityEngine;
using UnityEngine.Events;

public class JoystickInput : MonoBehaviour
{
    [SerializeField] private Joystick stick;
    [SerializeField] private UnityEvent<Vector2> onJoystick;

    private void Update ()
    {
        onJoystick?.Invoke(new(stick.Horizontal, stick.Vertical));
    }
}
