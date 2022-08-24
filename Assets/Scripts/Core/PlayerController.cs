using Heal.Components;
using UnityEngine;

namespace Heal.Systems
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterController2D characterController2D;

        private void Start ()
        {
            Controls.InputActions.Player.Jump.performed += characterController2D.Jump;
            Controls.InputActions.Player.Move.performed += characterController2D.Move;
            Controls.InputActions.Player.Move.canceled += characterController2D.Stop;
            GameManager.Instance.OnGameStateChanged += OnGameStateChanged;
        }

        private void OnDestroy ()
        {
            Controls.InputActions.Player.Jump.performed -= characterController2D.Jump;
            Controls.InputActions.Player.Move.performed -= characterController2D.Move;
            Controls.InputActions.Player.Move.canceled -= characterController2D.Stop;
            GameManager.Instance.OnGameStateChanged -= OnGameStateChanged;
        }

        private void OnGameStateChanged (GameState obj)
        {
            characterController2D.SetActive(obj switch
            {
                GameState.Normal => true,
                _ => false
            });
        }
    } 
}
