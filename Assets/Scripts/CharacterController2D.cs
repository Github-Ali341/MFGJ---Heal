using UnityEngine;
using UnityEngine.InputSystem;

namespace Heal.Components
{
    public class CharacterController2D : MonoBehaviour
    {
        [SerializeField] private LayerMask jumpMask;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;
        [SerializeField] private AudioSource jumpSource;

        private bool _disable;
        private Rigidbody2D rb;
        private BoxCollider2D boxCollider;
        private float _direction;
        
        private const float GROUND_DISTANCE = 0.03f;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            boxCollider = GetComponent<BoxCollider2D>();
        }

        private void FixedUpdate ()
        {
            if (!_disable)
                rb.velocity = new Vector2(_direction * moveSpeed, rb.velocity.y);
        }

        public void SetActive (bool active)
        {
            _disable = !active;
        }
        public void Jump (InputAction.CallbackContext c)
        {
            if (IsTouching(Vector2.down) && !_disable)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpSource.Play();
            }
        }
        public void Move (InputAction.CallbackContext c) => _direction = c.ReadValue<float>();
        public void Stop (InputAction.CallbackContext c) => _direction = 0;
        public bool IsTouching(Vector2 direction)
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