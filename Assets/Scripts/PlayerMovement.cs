using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D collider;
    private Animator animator;

    enum MovementState { standing = 0, running = 1, falling = 2, jumping = 3}
    [SerializeField] private LayerMask jumpGround;
    [SerializeField] private float movespeed = 7f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private Joystick _joystick;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); 
    }

    private void Update()
    {
        
        float dirX = Input.GetAxisRaw("Horizontal");
        if (_joystick.Horizontal == 0)
        {
            UpdateAnimation(dirX,false);
        }
        else if (_joystick.Horizontal != 0)
        {
            UpdateAnimation(dirX, true);
        }
    }
    public void Moving(float dirX, bool jump)
    {
        rb.velocity = new Vector2(dirX * movespeed, rb.velocity.y);

        if (jump && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    public void UpdateAnimation(float dirX, bool isJoystick)
    {
        MovementState state;
        if (isJoystick)
        {
            if (_joystick.Horizontal > 0f)
            {
                state = MovementState.running;
                sprite.flipX = false;
            }
            else if (_joystick.Horizontal < 0f)
            {
                state = MovementState.running;
                sprite.flipX = true;
            }
            else
            {
                state = MovementState.standing;
            }
        }
        else
        {
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
                state = MovementState.standing;
            }

            if (rb.velocity.y > .1f)
            {
                state = MovementState.jumping;
            }
            else if (rb.velocity.y < -.1f)
            {
                state = MovementState.falling;
            }
        }
        animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }
}
