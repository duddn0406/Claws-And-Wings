using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearHandMotion : MonoBehaviour
{
    public BearMove player1;

    public BirdMove player2;

    private FixedJoint2D joint;

    private float NormalMass;

    // Start is called before the first frame update
    void Start()
    {
        NormalMass = gameObject.GetComponent<Rigidbody2D>().mass;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        //if (GetComponent<Rigidbody2D>().velocity.magnitude < 0.1f)
        //{
        //    {
        //        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        //    }
        //}
        if (player2.hold == false)
        {
            gameObject.GetComponent<Rigidbody2D>().mass = NormalMass;
            Destroy(joint);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Bearhand") && player1.attack == true)
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Birdhand"))
        {
            if (player2.hold == true)
            {
                gameObject.GetComponent<Rigidbody2D>().mass = 0.2f;
                joint = gameObject.AddComponent<FixedJoint2D>();
                joint.connectedBody = player2.GetComponent<Rigidbody2D>();
            }
        }
        
    }
}
