using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushableObject : MonoBehaviour
{
    public float crushThreshold = 5f;  // 일정 힘 이상의 손상(누적)이 되면 크기를 줄임
    public float shrinkRate = 0.1f;    // 한 번 크기가 줄어드는 양
    public float minScale = 0.1f;      // x축 스케일이 이 값 이하가 되면 오브젝트 삭제

    private float damageAccumulated = 0f;  // 누적된 손상 값

    private Rigidbody2D rb;
    private Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Rigidbody2D otherRb = collision.collider.GetComponent<Rigidbody2D>();
        if (otherRb != null)
        {
            float force = otherRb.mass * collision.relativeVelocity.magnitude * 10000000000f;

            // 만약 힘이 일정 이상이면 손상 누적 (시간에 따라 누적)
            if (force > crushThreshold * 0.2f) // 낮은 힘도 누적될 수 있도록 일부 비율 적용 (조정 가능)
            {
                float damage = force * Time.deltaTime;  // 시간당 누적 손상량
                damageAccumulated += damage;

                // 누적 손상이 crushThreshold 이상이면 오브젝트 크기를 줄임
                if (damageAccumulated >= crushThreshold)
                {
                    damageAccumulated = 0f; // 누적치 리셋
                    Vector3 newScale = transform.localScale;
                    newScale.x -= shrinkRate; 
                    transform.localScale = newScale;

                    if (newScale.x <= minScale)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
