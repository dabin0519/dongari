using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public int jumpsAmount;
    int jumpsLeft;
    public Transform GroundCheck;
    public LayerMask GroundLayer;

    private float moveInput;
    private float scaleX;
    
    private Rigidbody2D rb2d;
    private BoxCollider2D boxCollider2D;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        scaleX = transform.localScale.x;
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (isGrounded() &&Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = Vector2.up * jumpForce;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        Flip();
        rb2d.velocity = new Vector2(moveInput * moveSpeed, rb2d.velocity.y);
    }

    public void Flip()
    {
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(-1 * scaleX, transform.localScale.y, transform.localScale.z);
        }
        if (moveInput < 0)
        {
            transform.localScale = new Vector3( scaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.size, 0f, Vector2.down * 1f);
        return hit.collider != null;
    }
}