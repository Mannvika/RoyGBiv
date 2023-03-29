namespace RoyGBiv.Movement
{
    using UnityEngine;
    using RoyGBiv.Core;

    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rb = null;
        private ColorChanger colorChanger = null;

        [SerializeField]
        private bool isGrounded = false;

        [SerializeField]
        private float jumpForce;

        [SerializeField]
        private float moveSpeed;

        private void Awake() {
            rb = GetComponent<Rigidbody2D>();
            colorChanger = GetComponent<ColorChanger>();
        }

        void Update() {
            Move();
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
                Jump();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.collider.CompareTag("floor")) {
                isGrounded = true;
                Color color = collision.collider.GetComponent<SpriteRenderer>().color;
                colorChanger.ChangeColor(color.r, color.g, color.b);
            }
            else {
                isGrounded = false;
            }
        }
        private void Jump() {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        private void Move() {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
    }
}