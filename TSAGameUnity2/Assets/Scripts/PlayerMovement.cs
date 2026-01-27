using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 12f;

    public RisingLava lava;   // drag Lava here in Inspector

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool hasMoved = false;
    private bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!canMove) return;

        float moveX = Input.GetAxis("Horizontal");

        // Horizontal movement
        rb.linearVelocity = new Vector2(
            moveX * moveSpeed,
            rb.linearVelocity.y
        );

        // Start lava after FIRST movement
        if (!hasMoved && Mathf.Abs(moveX) > 0.01f)
        {
            hasMoved = true;
            if (lava != null)
            {
                lava.StartRising();
            }
        }

        // Jump (Space or Up Arrow)
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    public void DisableMovement()
    {
        canMove = false;
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0f; // prevent falling
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }

    // 💎 Ruby pickup = WIN
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ruby"))
        {
            Destroy(other.gameObject);

            if (lava != null)
            {
                lava.StopRising();
            }

            GameManager.Instance.WinGame();
        }
    }
}
