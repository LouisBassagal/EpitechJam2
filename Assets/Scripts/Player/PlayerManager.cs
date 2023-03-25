using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed = 5f;
    public GameObject Simili;
    public GameObject GroundCheck;
    public Animator PlayerAnimator;
    public Animator SimiliAnimator;
    [SerializeField] int JumpPower = 20;
    public LayerMask GroundLayer;

    private SpriteRenderer PlayerRenderer;
    private SpriteRenderer SimiliRenderer;
    private Rigidbody2D PlayerRb;
    private Rigidbody2D SimiliRb;

    // Start is called before the first frame update
    void Start()
    {
        SimiliRenderer = Simili.GetComponent<SpriteRenderer>();
        PlayerRenderer = this.GetComponent<SpriteRenderer>();
        PlayerRb = this.GetComponent<Rigidbody2D>();
        SimiliRb = Simili.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");

        this.AnimationManager(movement);
        this.JumpManagement();
        PlayerRb.velocity = new Vector2(movement * speed, PlayerRb.velocity.y);
        SimiliRb.velocity = new Vector2(movement * speed, SimiliRb.velocity.y);
    }

    private void AnimationManager(float movement)
    {
        if (movement != 0)
        {
            SimiliAnimator.SetBool("IsMoving", true);
            PlayerAnimator.SetBool("IsMoving", true);
        }
        else
        {
            SimiliAnimator.SetBool("IsMoving", false);
            PlayerAnimator.SetBool("IsMoving", false);
        }
        if (movement < 0)
        {
            PlayerRenderer.flipX = true;
            SimiliRenderer.flipX = true;
        }
        if (movement > 0)
        {
            PlayerRenderer.flipX = false;
            SimiliRenderer.flipX = false;
        }
    }

    private void JumpManagement()
    {
        Collider2D GroundCollider = GroundCheck.GetComponent<CapsuleCollider2D> ();
        bool isGrounded = Physics2D.IsTouchingLayers(GroundCollider, GroundLayer);


        if (isGrounded == true)
        {
            PlayerAnimator.SetBool("IsJumping", false);
            SimiliAnimator.SetBool("IsJumping", false);
        } else
        {
            PlayerAnimator.SetBool("IsJumping", true);
            SimiliAnimator.SetBool("IsJumping", true);
        }

        if (Input.GetAxis("Jump") > 0 && isGrounded == true)
        {
            PlayerRb.velocity = new Vector2(PlayerRb.velocity.x, JumpPower);
            SimiliRb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }
    }
}
