using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // 게임 시작 시 혹은 해상도 변경 시 뷰포트를 조정하고 싶을 때 호출
    void Start()
    {
        AdjustCameraViewport();
    }

    // 해상도가 변경될 때마다 호출하려면 Update()나 해상도 변경 이벤트에서 호출할 수 있습니다.
    void Update()
    {
        // 예시: 매 프레임마다 조정 (필요에 따라 최적화)
        // AdjustCameraViewport();
    }

    // 카메라의 Viewport를 조정하는 함수
    void AdjustCameraViewport()
    {
        // 목표 비율 (예: 16:10)
        float targetAspect = 16f / 10f;
        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        Camera camera = Camera.main;
        if (camera == null)
        {
            Debug.LogError("CameraManager: Main Camera가 없습니다. MainCamera 태그가 설정되어 있는지 확인하세요.");
            return;
        }

        if (scaleHeight < 1.0f)
        {
            // 화면의 높이가 좁은 경우 (상하 레터박스)
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            camera.rect = rect;
        }
        else
        {
            // 화면의 폭이 좁은 경우 (좌우 필러박스)
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = camera.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            camera.rect = rect;
        }
    }
}
