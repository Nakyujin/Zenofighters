using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float jumpForce = 10f; 
    private Animator animator;
    
    public LayerMask jumpableGround;
    private Rigidbody2D rb;
    private Collider2D coll;
    private bool canMove = true; 
    public PlayerAttack playerattack;
    public PlayerHealth playerhealth;
    public bool isGrounded;

    public int playerNumber;

    const string idle = "idle";
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        isGrounded = IsGrounded();

        if (canMove)
        {
            float moveInput = 0f;
            float jumpInput = 0f;

            // Check player number to determine which controls to use
            if (playerNumber == 1)
            {
                moveInput = Input.GetAxisRaw("Player1_Horizontal");
                jumpInput = Input.GetAxisRaw("Player1_Jump");
            }
            else if (playerNumber == 2)
            {
                moveInput = Input.GetAxisRaw("Player2_Horizontal");
                jumpInput = Input.GetAxisRaw("Player2_Jump");
            }

            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

            if (moveInput != 0)
            {
                animator.SetBool("IsWalking", true);
            }
            else
            {
                animator.SetBool("IsWalking", false);
            }

            if (isGrounded)
            {
                animator.SetBool("IsJumping", false);
            }
            else
            {
                animator.SetBool("IsJumping", true);
            }

            if (jumpInput > 0 && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsJumping", false);
        }
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.01f, jumpableGround);
        return hit.collider != null;
    }

    public bool IsPlayerGrounded()
    {
        return isGrounded;
    }
    
    public void SetCanMove(bool move)
    {
        canMove = move;
        playerattack.ChangeAnimationState(idle);
    }
}
