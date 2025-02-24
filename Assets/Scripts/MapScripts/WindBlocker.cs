using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBlocker : MonoBehaviour
{
    public GameObject windWall; // �ٶ� �� ������Ʈ

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rock")) // ������ ������
        {
            Debug.Log("���� ����");
            windWall.SetActive(false); // �ٶ� �� ��Ȱ��ȭ
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Rock")) // ������ ������
        {
            windWall.SetActive(true); // �ٶ� �� Ȱ��ȭ
        }
    }
}
