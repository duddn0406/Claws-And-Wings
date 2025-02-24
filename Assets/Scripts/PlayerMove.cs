using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject Player1; // 첫 번째 오브젝트
    public GameObject Player2; // 두 번째 오브젝트
    public float moveDistance = 1.0f; // 이동할 거리
    public float moveSpeed = 2.0f; // 이동 속도

    private Vector2 targetPositionA;
    private Vector2 targetPositionB;

    void Start()
    {
        // 초기 위치 설정
        targetPositionA = Player1.transform.position;
        targetPositionB = Player2.transform.position;
    }

    void Update()
    {
        // 위쪽 화살표 키 입력 - X축으로 서로 멀어지기
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            targetPositionA += new Vector2(moveDistance, 0);
            targetPositionB += new Vector2(-moveDistance, 0);
        }

        // 아래쪽 화살표 키 입력 - X축으로 서로 가까워지기
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // 현재 X 거리 계산
            float currentXDistance = Mathf.Abs(targetPositionA.x - targetPositionB.x);

            // 최소 거리보다 클 경우에만 가까워지도록
            if (currentXDistance - moveDistance >= 0)
            {
                targetPositionA += new Vector2(-moveDistance, 0);
                targetPositionB += new Vector2(moveDistance, 0);
            }
            else
            {
                // 최소 거리 이하로 가까워지지 않도록 조정
                float adjustment = currentXDistance;
                targetPositionA += new Vector2(-adjustment, 0);
                targetPositionB += new Vector2(adjustment, 0);
            }
        }

        // 오브젝트 A를 목표 위치로 부드럽게 이동
        Player1.transform.position = Vector2.MoveTowards(Player1.transform.position, targetPositionA, moveSpeed * Time.deltaTime);
        // 오브젝트 B를 목표 위치로 부드럽게 이동
        Player2.transform.position = Vector2.MoveTowards(Player2.transform.position, targetPositionB, moveSpeed * Time.deltaTime);
    }
}
