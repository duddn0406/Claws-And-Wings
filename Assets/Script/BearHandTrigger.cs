using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearHandTrigger : MonoBehaviour
{
    public bool isStone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stone"))
            Debug.Log("��");
            isStone = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isStone = false;
    }
}
