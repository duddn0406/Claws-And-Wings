using UnityEngine;

public class EnsureSingleAudioListener : MonoBehaviour
{
    private void Start()
    {
        AudioListener[] listeners = FindObjectsOfType<AudioListener>();
        if (listeners.Length > 1)
        {
            for (int i = 1; i < listeners.Length; i++) // 첫 번째만 남기고 나머지는 비활성화
            {
                listeners[i].enabled = false;
            }
        }
    }
}
