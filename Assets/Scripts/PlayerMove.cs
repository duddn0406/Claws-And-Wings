using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject Player1; // ù ��° ������Ʈ
    public GameObject Player2; // �� ��° ������Ʈ
    public float moveDistance = 1.0f; // �̵��� �Ÿ�
    public float moveSpeed = 2.0f; // �̵� �ӵ�

    private Vector2 targetPositionA;
    private Vector2 targetPositionB;

    void Start()
    {
        // �ʱ� ��ġ ����
        targetPositionA = Player1.transform.position;
        targetPositionB = Player2.transform.position;
    }

    void Update()
    {
        // ���� ȭ��ǥ Ű �Է� - X������ ���� �־�����
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            targetPositionA += new Vector2(moveDistance, 0);
            targetPositionB += new Vector2(-moveDistance, 0);
        }

        // �Ʒ��� ȭ��ǥ Ű �Է� - X������ ���� ���������
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // ���� X �Ÿ� ���
            float currentXDistance = Mathf.Abs(targetPositionA.x - targetPositionB.x);

            // �ּ� �Ÿ����� Ŭ ��쿡�� �����������
            if (currentXDistance - moveDistance >= 0)
            {
                targetPositionA += new Vector2(-moveDistance, 0);
                targetPositionB += new Vector2(moveDistance, 0);
            }
            else
            {
                // �ּ� �Ÿ� ���Ϸ� ��������� �ʵ��� ����
                float adjustment = currentXDistance;
                targetPositionA += new Vector2(-adjustment, 0);
                targetPositionB += new Vector2(adjustment, 0);
            }
        }

        // ������Ʈ A�� ��ǥ ��ġ�� �ε巴�� �̵�
        Player1.transform.position = Vector2.MoveTowards(Player1.transform.position, targetPositionA, moveSpeed * Time.deltaTime);
        // ������Ʈ B�� ��ǥ ��ġ�� �ε巴�� �̵�
        Player2.transform.position = Vector2.MoveTowards(Player2.transform.position, targetPositionB, moveSpeed * Time.deltaTime);
    }
}
