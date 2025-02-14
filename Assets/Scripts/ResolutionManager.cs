using UnityEngine;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{
    public Toggle fullscreenToggle;     // 전체 화면 토글
    public Dropdown resolutionDropdown; // 해상도 선택 드롭다운

    private const string ResolutionKey = "ResolutionIndex"; // 해상도 저장 키
    private const string FullscreenKey = "Fullscreen";      // 전체 화면 저장 키
    private readonly Resolution[] resolutions = new Resolution[]
    {
        new Resolution(1600, 1000),
        new Resolution(1280, 800),
        new Resolution(1920, 1200),
        new Resolution(1440, 900),
        new Resolution(1680, 1050)
    };

    private void Start()
    {
        if (fullscreenToggle == null || resolutionDropdown == null)
        {
            Debug.LogError("ResolutionManager: UI 컴포넌트가 할당되지 않았습니다.");
            return;
        }

        // 초기 해상도 및 옵션 설정
        InitializeSettings();

        // 전체 화면 토글 이벤트 등록
        fullscreenToggle.onValueChanged.AddListener(ToggleFullScreen);

        // 해상도 드롭다운 변경 이벤트 등록
        resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
    }

    private void InitializeSettings()
    {
        resolutionDropdown.ClearOptions();
        foreach (Resolution res in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData($"{res.width}x{res.height}"));
        }

        // 저장된 해상도와 전체 화면 모드 불러오기 (없으면 기본값 사용)
        int savedResolutionIndex = PlayerPrefs.GetInt(ResolutionKey, 0);
        bool isFullscreen = PlayerPrefs.GetInt(FullscreenKey, 0) == 1;

        // UI 상태 업데이트
        fullscreenToggle.SetIsOnWithoutNotify(isFullscreen);
        resolutionDropdown.value = savedResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // 설정 적용
        ApplyResolution(savedResolutionIndex, isFullscreen);
    }

    private void OnResolutionChanged(int index)
    {
        if (Screen.fullScreen)
        {
            fullscreenToggle.SetIsOnWithoutNotify(false);
            resolutionDropdown.interactable = true;
        }

        ApplyResolution(index, false);
    }

    private void ToggleFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        resolutionDropdown.interactable = !isFullScreen;

        if (!isFullScreen)
        {
            ApplyResolution(resolutionDropdown.value, false);
        }

        PlayerPrefs.SetInt(FullscreenKey, isFullScreen ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void ApplyResolution(int index, bool isFullScreen)
    {
        Resolution res = resolutions[index];
        Screen.SetResolution(res.width, res.height, isFullScreen);
        Debug.Log($"해상도 설정: {res.width}x{res.height}, 전체 화면: {isFullScreen}");

        // 설정 저장
        PlayerPrefs.SetInt(ResolutionKey, index);
        PlayerPrefs.SetInt(FullscreenKey, isFullScreen ? 1 : 0);
        PlayerPrefs.Save();
    }

    private struct Resolution
    {
        public int width;
        public int height;

        public Resolution(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }
}
