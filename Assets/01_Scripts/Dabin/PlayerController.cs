using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public LayerMask GroundLayer;
    public Transform groundCheck;

    private bool isGround;
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

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
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

    public void Jump()
    {
        rb2d.velocity = Vector2.up * jumpForce;
        IsGrounded();
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

    private bool IsGrounded()
    {
        isGround = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1, 0.13f), CapsuleDirection2D.Horizontal, 0, GroundLayer);
        return isGround;
    }
}