using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed = 10;
    public float jumpSpeed = 15;

    public float speedMultiplier;
    public float speedMilestone;
    public float speedMilestoneCounter;

    public float jumpTimeCounter;
    public float jumpTime = 0.25f;

    private Rigidbody2D rb;

    private bool grounded;
    public LayerMask groundLayer;

    private bool stoppedJumping;
    private bool canDoubleJump;

    public float checkRadius;
    public Transform groundCheckObj;

    private Animator animator;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        rb = GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
        speedMilestoneCounter = speedMilestone;

        stoppedJumping = true;
    }

    void Update()
    {
   
        grounded = Physics2D.OverlapCircle(groundCheckObj.position, checkRadius, groundLayer);

        if (transform.position.x > speedMilestoneCounter)
        {
            speedMilestoneCounter += speedMilestone;
            runningSpeed *= speedMultiplier;
            speedMilestone *= speedMultiplier;
        }

        rb.velocity = new Vector2(runningSpeed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            if (grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                stoppedJumping = false;
            }

            if(!grounded && canDoubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                jumpTimeCounter = jumpTime;
                stoppedJumping = false;
                canDoubleJump = false;
            }
        }

        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }

        animator.SetFloat("Speed", rb.velocity.x);
        animator.SetBool("Grounded", grounded);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeathBox")
        {
            gameManager.Restart();
        }
    }
}
