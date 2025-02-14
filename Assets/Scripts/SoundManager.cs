using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // 씬 전환 시 파괴되지 않음
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Start()
    {
        // 🔹 볼륨 설정 불러오기 (저장된 값이 없으면 0.1)
        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.1f);
        audioSource.volume = savedVolume;
        Debug.Log("불러온 볼륨 값: " + savedVolume);
    }

    public void SetVolume(float volume)
    {
        if (audioSource == null)
        {
            Debug.LogError("SoundManager: AudioSource is missing!");
            return;
        }

        audioSource.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);  // 🔹 값 저장
        PlayerPrefs.Save();  // 🔹 즉시 저장
    }

    public float GetVolume()
    {
        return audioSource != null ? audioSource.volume : 1f;
    }
}
