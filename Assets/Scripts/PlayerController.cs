using UnityEngine;
using UnityEngine.InputSystem;
using Heal.Controllers;

public class PlayerController : MonoBehaviour
{
    /*
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private CharacterController2D characterController;

    private float _direction;

    private void Awake ()
    {
        playerInput.actions.FindActionMap("Player").FindAction("Move").performed += PlayerController_performed;
        playerInput.actions.FindActionMap("Player").FindAction("Move").canceled += PlayerController_canceled;
    }

    private void PlayerController_canceled (InputAction.CallbackContext obj)
    {
        _direction = 0;
    }

    private void PlayerController_performed (InputAction.CallbackContext obj)
    {
        _direction = obj.ReadValue<float>();
    }

    private void Update ()
    {
        characterController.Move(_direction);
    }
    */
}
