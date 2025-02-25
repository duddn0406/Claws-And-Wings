using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMove : MonoBehaviour
{
    Rigidbody2D Rigidbody;

    new SpriteRenderer renderer;

    Animator animator;

    public float movePower = 1f;
    
    public float jumpPower = 1f;

    private bool isGround = false;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal1") < 0)
        {
            moveVelocity = Vector3.left;

            renderer.flipX = true;
            animator.SetBool("isMoving",true);
        }
        else if (Input.GetAxisRaw("Horizontal1") > 0)
        {
            moveVelocity = Vector3.right;

            renderer.flipX = false;
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump1") && isGround)
        { 
           // Rigidbody.velocity = Vector2.zero;

            //Vector2 jumpVelocity = new Vector2(0, jumpPower);
            Rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

            animator.SetBool("isJumping", true);
            animator.SetTrigger("doJumping");
            isGround = false;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isJumping", false);
        }
    }
}
