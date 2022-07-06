using UnityEngine;
using UnityEngine.InputSystem;

namespace MFGJ.Controllers
{
    public class CharacterController2D : MonoBehaviour
    {
        [SerializeField] private LayerMask jumpMask;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;

        private Rigidbody2D rb;
        private BoxCollider2D boxCollider;
        private const float GROUND_DISTANCE = 0.03f;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            boxCollider = GetComponent<BoxCollider2D>();
        }

        public void Jump()
        {
            if (IsTouching(Vector2.down))
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }

        public void Move(InputAction.CallbackContext c)
        {
            float direction = c.ReadValue<float>();
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        }

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