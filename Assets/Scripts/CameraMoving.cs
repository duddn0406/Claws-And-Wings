using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public Transform Player1;
    public Transform Player2;
    public Camera mainCamera;

    public float minDistance = 2f; 
    public float maxDistance = 10f; 
    public float minOrthographicSize = 3f;
    public float maxOrthographicSize = 10f;
    public float zoomSpeed = 2f;

    void Start()
    {
        if (Player1 == null || Player2 == null)
            Debug.Log("플레이어 없음");
    }

    void Update()
    {
        if (Player1 != null && Player2 != null)
        {
            float distance = Vector2.Distance(Player1.position, Player2.position);

            distance = Mathf.Clamp(distance, minDistance, maxDistance);
            float OrthographicSize = Mathf.Lerp(minOrthographicSize, maxOrthographicSize,
            (distance - minDistance) / (maxDistance - minDistance));

            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, OrthographicSize, Time.deltaTime * zoomSpeed);

        }
    }
}
