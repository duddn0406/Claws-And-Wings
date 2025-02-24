using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushableObject : MonoBehaviour
{
    public float crushThreshold = 5f;  // ���� �� �̻��� �ջ�(����)�� �Ǹ� ũ�⸦ ����
    public float shrinkRate = 0.1f;    // �� �� ũ�Ⱑ �پ��� ��
    public float minScale = 0.1f;      // x�� �������� �� �� ���ϰ� �Ǹ� ������Ʈ ����

    private float damageAccumulated = 0f;  // ������ �ջ� ��

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

            // ���� ���� ���� �̻��̸� �ջ� ���� (�ð��� ���� ����)
            if (force > crushThreshold * 0.2f) // ���� ���� ������ �� �ֵ��� �Ϻ� ���� ���� (���� ����)
            {
                float damage = force * Time.deltaTime;  // �ð��� ���� �ջ�
                damageAccumulated += damage;

                // ���� �ջ��� crushThreshold �̻��̸� ������Ʈ ũ�⸦ ����
                if (damageAccumulated >= crushThreshold)
                {
                    damageAccumulated = 0f; // ����ġ ����
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
