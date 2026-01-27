using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverUI;   // GAME OVER
    public GameObject winUI;        // YOU WIN

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
    }

    // 🏆 Player collected ruby
    public void WinGame()
    {
        if (gameEnded) return;
        gameEnded = true;

        // Freeze player only
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        if (player != null)
        {
            player.DisableMovement();
        }

        winUI.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
