using UnityEngine;
using TMPro;
using System.Collections;

public class Tornado : MonoBehaviour
{
    [Header("References")]
    public GameObject whirlwind;
    public TMP_Text missText;
    public TMP_Text winText;

    [Header("Timing (Easy Mode)")]
    public float minSpawnDelay = 2.5f;
    public float maxSpawnDelay = 4f;
    public float visibleTime = 3.5f;

    [Header("Spawn Area Padding")]
    public float paddingX = 0.5f;
    public float paddingY = 0.5f;

    [Header("Win Settings")]
    public int hitsToWin = 5;   // EASY WIN

    private int missCount = 0;
    private int hitCount = 0;
    private bool clicked = false;
    private bool gameWon = false;

    void Start()
    {
        whirlwind.SetActive(false);
        UpdateMissText();

        if (winText != null)
            winText.gameObject.SetActive(false);

        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (!gameWon)
        {
            float wait = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(wait);

            PlaceAtRandomPosition();

            clicked = false;
            whirlwind.SetActive(true);

            yield return new WaitForSeconds(visibleTime);

            if (!clicked)
            {
                missCount++;
                UpdateMissText();
            }

            whirlwind.SetActive(false);
        }
    }

    void PlaceAtRandomPosition()
    {
        Camera cam = Camera.main;

        float camHeight = cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        float randomX = Random.Range(
            cam.transform.position.x - camWidth + paddingX,
            cam.transform.position.x + camWidth - paddingX
        );

        float randomY = Random.Range(
            cam.transform.position.y - camHeight + paddingY,
            cam.transform.position.y + camHeight - paddingY
        );

        whirlwind.transform.position = new Vector3(randomX, randomY, 0f);
    }

    void UpdateMissText()
    {
        if (missText != null)
            missText.text = "Misses: " + missCount + " | Hits: " + hitCount + "/" + hitsToWin;
    }

    // Called when tornado is clicked
    public void OnTornadoClicked()
    {
        if (gameWon) return;

        clicked = true;
        hitCount++;
        whirlwind.SetActive(false);
        UpdateMissText();

        if (hitCount >= hitsToWin)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        gameWon = true;
        StopAllCoroutines();
        whirlwind.SetActive(false);

        if (winText != null)
        {
            winText.gameObject.SetActive(true);
            winText.text = "PUZZLE COMPLETE!";
        }

        Debug.Log("AIR PUZZLE COMPLETE!");

        // ✅ SAVE TO MAIN GAME PROGRESS
        if (GameProgress.Instance != null && !GameProgress.Instance.AirStone)
        {
            GameProgress.Instance.AirStone = true;
            Debug.Log("Air Stone unlocked!");
        }
    }
}
