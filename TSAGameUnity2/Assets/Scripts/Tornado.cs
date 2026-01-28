using UnityEngine;
using TMPro;
using System.Collections;

public class Tornado : MonoBehaviour
{
    [Header("References")]
    public GameObject whirlwind;
    public TMP_Text missText;

    [Header("Timing")]
    public float minSpawnDelay = 1.5f;
    public float maxSpawnDelay = 3.5f;
    public float visibleTime = 2.5f;

    [Header("Spawn Area Padding")]
    public float paddingX = 0.5f;
    public float paddingY = 0.5f;

    private int missCount = 0;
    private bool clicked = false;

    void Start()
    {
        whirlwind.SetActive(false);
        UpdateMissText();
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
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
        missText.text = "Misses: " + missCount;
    }

    // Called when tornado is clicked
    public void OnTornadoClicked()
    {
        clicked = true;
        whirlwind.SetActive(false);
    }
}

