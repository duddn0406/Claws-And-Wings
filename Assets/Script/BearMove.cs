using UnityEngine;

public class BearMove : MonoBehaviour
{
    Rigidbody2D Rigidbody;

    new SpriteRenderer renderer;

    Animator animator;

    public float movePower = 1f;

    public float jumpPower = 1f;

    private bool isGround = false;

    public bool attack = false;

    //private bool isPushing = false;

    GameObject BearHand;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        BearHand = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Break();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetAxisRaw("Horizontal1") < 0)
        {
            Rigidbody.AddForce(Vector2.left * movePower, ForceMode2D.Impulse);
            Rigidbody.velocity = new Vector2(Mathf.Max(Rigidbody.velocity.x, -movePower), Rigidbody.velocity.y);

            renderer.flipX = true;
            animator.SetBool("isMoving", true);
        }
        else if (Input.GetAxisRaw("Horizontal1") > 0)
        {
            Rigidbody.AddForce(Vector2.right * movePower, ForceMode2D.Impulse);
            Rigidbody.velocity = new Vector2(Mathf.Min(Rigidbody.velocity.x, movePower), Rigidbody.velocity.y);

            renderer.flipX = false;
            animator.SetBool("isMoving", true);
        }
        else
        {
            Vector3 vel = Rigidbody.velocity;
            vel.x = 0;
            Rigidbody.velocity = vel;
            animator.SetBool("isMoving", false);
        }

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
    private void Break()
    {
        if (Input.GetButtonDown("Break1"))
        {
            attack = true;
            animator.SetTrigger("doBreak");
            Invoke("EndAttack", 0.5f);
        }
        else if (Input.GetButtonUp("Break1"))
        {
            attack = false;
        }
    }
    void EndAttack()
    {
        attack = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
        //if (collision.gameObject.CompareTag("Ground"))
        //{
        //    isGround = true;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        animator.SetBool("isJumping", false);

        //if (collision.gameObject.CompareTag("Ground"))
        //{
        //    animator.SetBool("isJumping", false);
        //}

    }
}
