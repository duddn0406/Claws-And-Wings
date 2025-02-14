using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    private const string VolumeKey = "GameVolume"; // PlayerPrefs 저장 키

    private void Start()
    {
        if (volumeSlider == null)
        {
            Debug.LogError("VolumeController: Slider is missing! Assign it in the Inspector.");
            return;
        }

        if (SoundManager.Instance == null)
        {
            Debug.LogError("VolumeController: SoundManager.Instance is null!");
            return;
        }

        // 슬라이더 범위를 0 ~ 1로 설정
        volumeSlider.minValue = 0f;
        volumeSlider.maxValue = 1f;

        // 기존에 저장된 볼륨 값 불러오기 (없으면 0.1 사용)
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 0.1f);
        SoundManager.Instance.SetVolume(savedVolume);

        // 슬라이더 값 동기화
        volumeSlider.value = savedVolume;

        Debug.Log("불러온 볼륨 값: " + savedVolume);

        // 슬라이더 값 변경 이벤트 등록
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    public void OnVolumeChanged(float value)
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.SetVolume(value);
            PlayerPrefs.SetFloat(VolumeKey, value);
            PlayerPrefs.Save();
            Debug.Log("볼륨 변경됨: " + value);
        }
    }
}
