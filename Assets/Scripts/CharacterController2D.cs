using UnityEngine;
using UnityEngine.InputSystem;

namespace Heal.Controllers
{
    public class CharacterController2D : MonoBehaviour
    {
        [SerializeField] private LayerMask jumpMask;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;
        [SerializeField] private AudioSource jumpSource;

        private Rigidbody2D rb;
        private BoxCollider2D boxCollider;
        private float _direction;
        private const float GROUND_DISTANCE = 0.03f;
        
        private bool _disable;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            boxCollider = GetComponent<BoxCollider2D>();
        }

        private void Start ()
        {
            Controls.InputActions.Player.Jump.performed += Jump;
            Controls.InputActions.Player.Move.performed += Move;
            Controls.InputActions.Player.Move.canceled += Stop;
            GameManager.Instance.OnGameStateChanged += OnGameStateChanged;
        }

        private void FixedUpdate ()
        {
            if (!_disable)
                rb.velocity = new Vector2(_direction * moveSpeed, rb.velocity.y);
        }

        private void OnDestroy ()
        {
            Controls.InputActions.Player.Jump.performed -= Jump;
            Controls.InputActions.Player.Move.performed -= Move;
            Controls.InputActions.Player.Move.canceled -= Stop;
            GameManager.Instance.OnGameStateChanged -= OnGameStateChanged;
        }

        private void OnGameStateChanged (GameState obj)
        {
            _disable = obj switch
            {
                GameState.Normal => false,
                _ => true
            };
        }

        private void Jump (InputAction.CallbackContext c)
        {
            if (IsTouching(Vector2.down) && !_disable)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpSource.Play();
            }
        }
        private void Move (InputAction.CallbackContext c) => _direction = c.ReadValue<float>();
        private void Stop (InputAction.CallbackContext c) => _direction = 0;

        private bool IsTouching(Vector2 direction)
        {
            RaycastHit2D hitInfo = Physics2D.BoxCast(
                boxCollider.bounds.center, 
                boxCollider.bounds.size, 
                0f, 
                direction, 
                GROUND_DISTANCE, 
                jumpMask
            );

            return hitInfo.collider != null;
        }
    } 
}