using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBlocker : MonoBehaviour
{
    public GameObject windWall; // 바람 벽 오브젝트

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rock")) // 바위가 들어오면
        {
            Debug.Log("바위 들어옴");
            windWall.SetActive(false); // 바람 벽 비활성화
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Rock")) // 바위가 나가면
        {
            windWall.SetActive(true); // 바람 벽 활성화
        }
    }
}
