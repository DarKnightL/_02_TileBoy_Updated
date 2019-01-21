using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float runSpeed = 10f;
    [SerializeField]
    private float jumpSpeed = 28f;
    [SerializeField]
    private float climbSpeed = 10f;

    private Rigidbody2D rigidbody;
    private Animator animator;
    private CapsuleCollider2D collider;
    private BoxCollider2D feetCollider;

    private float gravityScaleAtStart;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = rigidbody.gravityScale;
        feetCollider = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        Run();
        FlipSprite();
        Jump();
        ClimbLadder();
    }


    void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(controlThrow * runSpeed, rigidbody.velocity.y);
        bool playerHasHorizontalSpeed = Mathf.Abs(rigidbody.velocity.x) > Mathf.Epsilon;
        animator.SetBool("Running", playerHasHorizontalSpeed);

    }


    void Jump()
    {
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0, jumpSpeed);
            rigidbody.velocity += jumpVelocityToAdd;
        }
    }


    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidbody.velocity.x), 1f);
        }
    }


    void ClimbLadder()
    {
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            animator.SetBool("Climbing", false);
            rigidbody.gravityScale = gravityScaleAtStart;
            return;
        }
        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, controlThrow * climbSpeed);
        bool playerHasVerticalSpeed = Mathf.Abs(rigidbody.velocity.y) > Mathf.Epsilon;
        animator.SetBool("Climbing", playerHasVerticalSpeed);
        rigidbody.gravityScale = 0f;

    }
}
