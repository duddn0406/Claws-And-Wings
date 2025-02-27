using UnityEditor;
using UnityEngine;

public class OptionMenuController : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject previousUI;
    [SerializeField] private CanvasGroup canvasGroup; // ✅ 캔버스 투명도 조절

    public void OnOptionButtonPressed()
    {
        optionMenu.SetActive(true);
        // 게임 시간을 멈춤 (0이면 정지, 1이면 정상 진행)
        Time.timeScale = 0f;
        Debug.Log("옵션 메뉴 열림, 게임 정지");

        if (canvasGroup != null)
        {
            canvasGroup.alpha = optionMenu.activeSelf ? 1 : 0; // 활성화 상태에 따라 투명도 변경
            canvasGroup.interactable = optionMenu.activeSelf;
            canvasGroup.blocksRaycasts = optionMenu.activeSelf;
        }
    }

    public void SaveSetting()
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0; // 옵션 창 숨김
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        optionMenu.SetActive(false); // ✅ 세이브 버튼을 눌러야 옵션 메뉴가 꺼짐

        if (previousUI != null)
        {
            previousUI.SetActive(true);
        }
        else
        {
            Debug.LogWarning("previousUI가 할당되지 않음!");
        }

        Time.timeScale = 1f;
        Debug.Log("옵션 메뉴 닫힘, 게임 재개");
    }

}
