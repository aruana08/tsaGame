using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverUI;   // GAME OVER
    public GameObject winUI;        // YOU WIN

    public Button returnBtn;
    private bool gameEnded = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // 🔥 Player touched lava
    public void GameOver()
    {
        if (gameEnded) return;
        gameEnded = true;

        Time.timeScale = 0f;
        gameOverUI.SetActive(true);

        if (returnBtn != null)
            returnBtn.interactable = false;

        ReturnToMap();
    }

    // 🏆 Player collected ruby (WIN)
    public void WinGame()
    {
        if (gameEnded) return;
        gameEnded = true;

        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        if (player != null)
        {
            player.DisableMovement();
        }

        winUI.SetActive(true);

        // ✅ SAVE PROGRESS
        if (GameProgress.Instance != null && !GameProgress.Instance.FireStone)
        {
            GameProgress.Instance.FireStone = true;
            Debug.Log("Fire Stone unlocked!");
        }

        // ⏱ Optional delay so player sees win screen
        Invoke(nameof(LoadWinScene), 2f);
    }

    void LoadWinScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("fireLevelCompleted");
    }

    // 🔁 Button function
    public void ReturnToMap()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("03_MainMap");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}