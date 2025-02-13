using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    private Rigidbody2D Rigidbody;

    public float movePower = 1f;

    public float jumpPower = 1f;

    public float glideDrag = 1f;

    private bool isGround = false;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();
    }
    private void FixedUpdate()
    {

    }
    private void Move()
    {
        if (isGround)
            return;

        if (Input.GetButtonDown("Horizontal2"))
            Rigidbody.drag = glideDrag;

        if (Input.GetButtonUp("Horizontal2"))
            Rigidbody.drag = 0;

        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal2") < 0)
        {
            moveVelocity = Vector3.left;
        }
        else if (Input.GetAxisRaw("Horizontal2") > 0)
        {
            moveVelocity = Vector3.right;
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump2") && isGround)
        {
            //Rigidbody.velocity = Vector2.zero;

            //Vector2 jumpVelocity = new Vector2(0, jumpPower);
            Rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

            isGround = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            Rigidbody.drag = 0;
        }
    }
}
