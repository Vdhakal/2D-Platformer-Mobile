using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    private float dirX = 0f;
    private int jumpCounter = 0;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 9f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jump;
    private enum MovementState { idle, running, jumping, falling }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX*moveSpeed, rb.velocity.y);
        if (IsGrounded()) 
        {
            jumpCounter = 0;
        }
        if (Input.GetButtonDown("Jump") && (IsGrounded()||jumpCounter==1))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCounter++;
            jump.Play();
        }
        UpdateAnimationState();
    }
    public void MoveLeft()
    {
        rb.velocity = new Vector2(-1 * moveSpeed, rb.velocity.y);
        UpdateAnimationState(MovementState.running, true);

    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(1 * moveSpeed, rb.velocity.y);
        UpdateAnimationState(MovementState.running, false);
    }
    public void Jump() 
    {
        if (IsGrounded())
        {
            jumpCounter = 0;
        }
        if (IsGrounded() || jumpCounter == 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCounter++;
            jump.Play();
        }
        MovementState state = MovementState.idle;
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
    private void UpdateAnimationState() 
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
    private void UpdateAnimationState(MovementState state, bool flipX)
    {
        sprite.flipX = flipX;
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down,.1f, jumpableGround);
    }
    
}
