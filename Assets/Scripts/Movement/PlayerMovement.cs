namespace RoyGBiv.Movement
{
    using UnityEngine;
    using RoyGBiv.Core;

    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rb = null;
        private ColorChanger colorChanger = null;
        private GameManager gameManager = null;

        [SerializeField]
        private float jumpForce = 0f;

        [SerializeField]
        private float moveSpeed = 0f;

        [SerializeField]
        private float speedIncreaseMilestone = 0f;

        [SerializeField]
        private float speedMultiplier = 0f;

        private float speedMilestoneCount = 0f;

        [SerializeField]
        private float jumpTime = 0f;

        private float jumpTimeCounter = 0f;

        [SerializeField]
        private LayerMask ground;

        [SerializeField]
        private bool isGrounded = false;

        private bool stoppedJumping = true;
        private bool canDoubleJump = true;

        [SerializeField]
        private Transform groundCheck = null;
        [SerializeField]
        private float groundCheckRadius = 0f;

        private void Awake() {
            rb = GetComponent<Rigidbody2D>();
            colorChanger = GetComponent<ColorChanger>();
            gameManager = FindObjectOfType<GameManager>();
        }
        private void Start() {
            jumpTimeCounter = jumpTime;

            speedMilestoneCount = speedIncreaseMilestone;
        }

        void Update() {

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);
            gameManager.currentScore = transform.position.x;

            Move();
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (isGrounded) {
                    Jump();
                    stoppedJumping = false;
                }

                if (!isGrounded && canDoubleJump) {
                    Jump();
                    canDoubleJump = false;
                    stoppedJumping = false;
                }
            }

            if (Input.GetKey(KeyCode.Space) && !stoppedJumping) { 
                if(jumpTimeCounter > 0) {
                    Jump();
                    jumpTimeCounter -= Time.deltaTime;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space)) {
                jumpTimeCounter = 0;
                stoppedJumping = true;
            }

            if (isGrounded) {
                jumpTimeCounter = jumpTime;
                canDoubleJump = true; 
            }
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.collider.CompareTag("floor")) {
                Color color = collision.collider.GetComponent<SpriteRenderer>().color;
                colorChanger.ChangeColor(color.r, color.g, color.b);
            }

            if (collision.collider.CompareTag("deathzone")) {
                gameManager.RestartGame();
            }
        }
        private void Jump() {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        private void Move() {
            if(transform.position.x > speedMilestoneCount) {
                speedMilestoneCount += speedIncreaseMilestone;

                speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
                moveSpeed = moveSpeed * speedMultiplier;
            }

            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
    }
}