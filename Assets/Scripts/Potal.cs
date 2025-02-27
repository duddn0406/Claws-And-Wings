using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string nextSceneName;
    public GameObject gameClearUI; // 게임 클리어 UI

    private bool bearEntered = false;
    private bool birdEntered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Enter: " + other.gameObject.name + " with tag " + other.tag);

        if (other.CompareTag("Bear"))
        {
            bearEntered = true;
            Debug.Log("Bear entered the portal.");
        }
        else if (other.CompareTag("Bird"))
        {
            birdEntered = true;
            Debug.Log("Bird entered the portal.");
        }

        Debug.Log("Current status => Bear: " + bearEntered + ", Bird: " + birdEntered);

        if (bearEntered && birdEntered)
        {
            Debug.Log("Both Bear and Bird are inside. Showing game clear UI.");

            if (SceneManager.GetActiveScene().name == "Stage3") // 현재 씬이 Stage 3인지 확인
            {
                if (gameClearUI != null)
                {
                    gameClearUI.SetActive(true); // 게임 클리어 UI 활성화
                    Time.timeScale = 0f; // 게임 정지
                }
                else
                {
                    Debug.LogWarning("Game Clear UI is not assigned!");
                }
            }
            else
            {
                SceneManager.LoadScene(nextSceneName); // 다음 씬으로 이동
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger Exit: " + other.gameObject.name + " with tag " + other.tag);

        if (other.CompareTag("Bear"))
        {
            bearEntered = false;
            Debug.Log("Bear exited the portal.");
        }
        else if (other.CompareTag("Bird"))
        {
            birdEntered = false;
            Debug.Log("Bird exited the portal.");
        }
        Debug.Log("After exit => Bear: " + bearEntered + ", Bird: " + birdEntered);
    }
}
