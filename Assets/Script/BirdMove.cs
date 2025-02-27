using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    Rigidbody2D Rigidbody;

    new SpriteRenderer renderer;

    Animator animator;

    Vector2 Direction;

    public float movePower = 1f;

    public float MaxSpeed = 1f;

    public float jumpPower = 1f;

    public float glideDrag = 1f;

    //private bool isGround = false;

    public bool hold = false;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Direction = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        Hold();
        UpDown();
        Move();
    }
    private void FixedUpdate()
    {

    }
    private void Move()
    {
        //if (isGround)
        //    return;

        //if (Input.GetButtonDown("Horizontal2"))
        //    Rigidbody.drag = glideDrag;

        //if (Input.GetButtonUp("Horizontal2"))
        //    Rigidbody.drag = 0;
        Rigidbody.AddForce(Direction * movePower, ForceMode2D.Impulse);
        //if (Input.GetButtonDown("Horizontal2"))
        //{
        //    Vector3 vel = Rigidbody.velocity;
        //    vel.x = 0;
        //    Rigidbody.velocity = vel;
        //}
        if (Input.GetAxisRaw("Horizontal2") < 0)
        {
            //Rigidbody.AddForce(Vector2.left * movePower, ForceMode2D.Impulse);
            Direction = Vector2.left;

            renderer.flipX = true;
            //animator.SetBool("isMoving", true);
        }
        else if (Input.GetAxisRaw("Horizontal2") > 0)
        {
            //Rigidbody.AddForce(Vector2.right * movePower, ForceMode2D.Impulse);
            Direction = Vector2.right;

            renderer.flipX = false;
            //animator.SetBool("isMoving", true);
        }
        //else
        //{
        //    Vector3 vel = Rigidbody.velocity;
        //    vel.x = 0;
        //    Rigidbody.velocity = vel;
        //    //animator.SetBool("isMoving", false);
        //}

    }
    private void UpDown()
    {
        if (Input.GetAxisRaw("Vertical2") < 0)
        {
            //Rigidbody.velocity = Vector2.zero;

            //Vector2 jumpVelocity = new Vector2(0, jumpPower);
            Rigidbody.AddForce(Vector2.down * jumpPower, ForceMode2D.Impulse);

            //isGround = false;
        }
        else if(Input.GetAxisRaw("Vertical2") > 0)
        {
            Rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

    }
    private void Hold()
    {
        if (Input.GetButtonDown("Hold2"))
        {
            if (hold)
            {
                hold = false;
            }
            else if (!hold)
            {
                hold = true;
            }
                
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //isGround = true;

        //Rigidbody.drag = 0;
        //if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Stone"))
        //{
        //    collision.rigidbody.bodyType = RigidbodyType2D.Kinematic;
        //}
        //if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        //{
        //    isGround = true;
        //    Rigidbody.drag = 0;
        //}
        if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Stone"))
        {
            collision.rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Stone"))
        {
            collision.rigidbody.constraints = RigidbodyConstraints2D.None;
        }
    }
}
