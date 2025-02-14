using UnityEngine;
using UnityEngine.UI;  // Add this to use the Toggle component

public class ScreenManager : MonoBehaviour
{
    public Toggle fullscreenToggle;  // Reference to the Toggle component

    // Call this method to set the screen mode based on the toggle state
    public void OnToggleChanged(bool isFullScreen)
    {
        if (isFullScreen)
        {
            // Set full screen mode
            Screen.fullScreen = true;
            Debug.Log("전체 화면 모드로 전환");
        }
        else
        {
            // Set windowed mode and resolution
            Screen.fullScreen = false;
            Screen.SetResolution(1280, 720, false);
            Debug.Log("창 모드로 전환 (해상도: 1600x900)");
        }
    }

    // You can call this to initialize the toggle state
    void Start()
    {
        if (fullscreenToggle == null)
        {
            Debug.LogError("Toggle reference not assigned in the Inspector!");
            return;
        }

        // Ensure the Toggle reflects the current screen mode
        fullscreenToggle.isOn = Screen.fullScreen;

        // Add a listener to handle the toggle state change
        fullscreenToggle.onValueChanged.AddListener(OnToggleChanged);
    }
}
