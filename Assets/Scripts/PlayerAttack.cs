using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    public bool isInAnimation;
    public Collider2D punch1Hitbox;
    public Collider2D kick1Hitbox;
    public Collider2D punch2Hitbox;
    public Collider2D jumppunch1Hitbox;
    public Collider2D jumppunch2Hitbox;
    public Collider2D jumpkick1Hitbox;
    public Collider2D jumpkick2Hitbox;
    public Collider2D kick2Hitbox;
    public PlayerMovement playerMovement;
    public PlayerHealth playerHealth;
    
    public float punchCooldown = 0.5f; 
    public float kickCooldown = 1f; 
    private float lastPunchTime; 
    private float lastKickTime;
    public string currentState;

    // Animation States
    const string punch1 = "punch1";
    const string punch2 = "punch2";
    const string kick1 = "kick1";
    const string kick2 = "kick2";
    const string jumppunch1 = "jumpPunch1";
    const string jumppunch2 = "jumpPunch2";
    const string jumpkick1 = "jumpKick1";
    const string jumpkick2 = "jumpKick2";
    const string idle = "idle";

    
    void Start()
    {
        animator = GetComponent<Animator>();
        OnAttackInterrupted();
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.SetBool("IsWalking", false);
        animator.SetBool("IsJumping", false);
        animator.Play(newState);
        currentState = newState;
    }

    void Update()
    {
        Debug.Log(isInAnimation);
        if (playerMovement.playerNumber == 1)
        {
        if (Input.GetKeyDown(KeyCode.X) && Time.time >= lastPunchTime + punchCooldown && !isInAnimation)
        {
            if (playerHealth.lowHp)
            {
                if (!playerMovement.isGrounded)
                {
                    StartJumpPunch2();
                    lastPunchTime = Time.time;
                }
                else
                {
                    StartPunch2();
                    lastPunchTime = Time.time;
                }
            }
            else
            {
                if (!playerMovement.isGrounded)
                {
                    StartJumpPunch1();
                    lastPunchTime = Time.time;
                }
                else
                {
                    StartPunch1();
                    lastPunchTime = Time.time;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.V) && Time.time >= lastKickTime + kickCooldown && !isInAnimation)
        {
        
            if (playerHealth.lowHp)
            {
                if (!playerMovement.isGrounded)
                {
                    StartJumpKick2();
                    lastKickTime = Time.time;
                }
                else
                {
                    StartKick2();
                    lastKickTime = Time.time;
                }
            }
            else
            {
                if (!playerMovement.isGrounded)
                {
                    StartJumpKick1();
                    lastKickTime = Time.time;
                    Debug.Log("kick1");
                }
                else
                {
                    StartKick1();
                    lastKickTime = Time.time;
                }
            }
        }
        }
        if (playerMovement.playerNumber == 2)
        {
        if (Input.GetKeyDown(KeyCode.RightBracket) && Time.time >= lastPunchTime + punchCooldown && !isInAnimation)
        {
            if (playerHealth.lowHp)
            {
                if (!playerMovement.isGrounded)
                {
                    StartJumpPunch2();
                    lastPunchTime = Time.time;
                }
                else
                {
                    StartPunch2();
                    lastPunchTime = Time.time;
                }
            }
            else
            {
                if (!playerMovement.isGrounded)
                {
                    StartJumpPunch1();
                    lastPunchTime = Time.time;
                }
                else
                {
                    StartPunch1();
                    lastPunchTime = Time.time;
                }
            }
        }
        

        
        if (Input.GetKeyDown(KeyCode.Backslash) && Time.time >= lastKickTime + kickCooldown && !isInAnimation)
        {
        
            if (playerHealth.lowHp)
            {
                if (!playerMovement.isGrounded)
                {
                    StartJumpKick2();
                    lastKickTime = Time.time;
                }
                else
                {
                    StartKick2();
                    lastKickTime = Time.time;
                }
            }
            else
            {
                if (!playerMovement.isGrounded)
                {
                    StartJumpKick1();
                    lastKickTime = Time.time;
                    Debug.Log("kick1");
                }
                else
                {
                    StartKick1();
                    lastKickTime = Time.time;
                }
            }
        }
        }
    }
    


    //Attack Start Logic
    public void StartPunch1()
    {
        playerMovement.SetCanMove(false);
        ChangeAnimationState(punch1);
        isInAnimation = true;
    }

    public void StartKick1()
    {
        playerMovement.SetCanMove(false);
        ChangeAnimationState(kick1);
        isInAnimation = true;
    }

    public void StartPunch2()
    {
        playerMovement.SetCanMove(false);
        ChangeAnimationState(punch2);
        isInAnimation = true;
    }

    public void StartKick2()
    {
        playerMovement.SetCanMove(false);
        ChangeAnimationState(kick2);
        isInAnimation = true;
    }

    public void StartJumpPunch1()
    {
        ChangeAnimationState(jumppunch1);
        isInAnimation = true;
    }

    public void StartJumpPunch2()
    {
        ChangeAnimationState(jumppunch2);
        isInAnimation = true;  
    }

    public void StartJumpKick1()
    {
        ChangeAnimationState(jumpkick1);
        isInAnimation = true;
    }

    public void StartJumpKick2()
    {
        ChangeAnimationState(jumpkick2);
        isInAnimation = true;
    }

    //enable hitboxes
    public void Punch1HitboxActive()
    {
        punch1Hitbox.enabled = true; 
    }
    
    public void Punch2HitboxActive()
    {
        punch2Hitbox.enabled = true; 
    }
    
    public void Kick1HitboxActive()
    {
        kick1Hitbox.enabled = true; 
    }
    
    public void Kick2HitboxActive()
    {
        kick2Hitbox.enabled = true; 
    }

    public void JumpPunch1HitboxActive()
    {
        jumppunch1Hitbox.enabled = true; 
    }
    
    public void JumpPunch2HitboxActive()
    {
        jumppunch2Hitbox.enabled = true; 
    }

    public void JumpKick1HitboxActive()
    {
        jumpkick1Hitbox.enabled = true; 
    }
    
    public void JumpKick2HitboxActive()
    {
        jumpkick2Hitbox.enabled = true; 
    }
    
    //Attack End Logic
    public void EndPunch1()
    {
        isInAnimation = false;
        punch1Hitbox.enabled = false; 
        playerMovement.SetCanMove(true);
    }

    public void EndKick1()
    {
        isInAnimation = false;
        kick1Hitbox.enabled = false; 
        playerMovement.SetCanMove(true);
    }

    public void EndPunch2()
    {
        isInAnimation = false;
        punch2Hitbox.enabled = false; 
        playerMovement.SetCanMove(true);
    }

    public void EndKick2()
    {
        isInAnimation = false;
        kick2Hitbox.enabled = false;
        playerMovement.SetCanMove(true);
    }

    public void EndJumpPunch1()
    {
        isInAnimation = false;
        jumppunch1Hitbox.enabled = false; 
        ChangeAnimationState(idle);
    }

    public void EndJumpPunch2()
    {
        isInAnimation = false;
        jumppunch2Hitbox.enabled = false; 
        ChangeAnimationState(idle);
    }

    public void EndJumpKick1()
    {
        isInAnimation = false;
        jumpkick1Hitbox.enabled = false;
        ChangeAnimationState(idle);
    }

    public void EndJumpKick2()
    {
        isInAnimation = false;
        jumpkick2Hitbox.enabled = false; 
        ChangeAnimationState(idle);
    }

    public void OnAttackInterrupted()
    {
        isInAnimation = false;
        punch1Hitbox.enabled = false;
        kick1Hitbox.enabled = false;
        punch2Hitbox.enabled = false;
        jumppunch1Hitbox.enabled = false;
        jumppunch2Hitbox.enabled = false;
        jumpkick1Hitbox.enabled = false;
        jumpkick2Hitbox.enabled = false;
        kick2Hitbox.enabled = false;
    }

}

