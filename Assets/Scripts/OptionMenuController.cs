using UnityEngine;

public class OptionMenuController : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject previousUI;
    [SerializeField] private CanvasGroup canvasGroup; // ✅ 캔버스 투명도 조절

    public void ToggleOptionMenu()
    {
        optionMenu.SetActive(!optionMenu.activeSelf); // 옵션 메뉴 열기/닫기

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
        previousUI.SetActive(true);
    }
}
