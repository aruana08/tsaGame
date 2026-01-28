using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tornado : MonoBehaviour
{
    [Header("References")]
    public GameObject whirlwind;
    public Text missText;

    [Header("Timing")]
    public float minSpawnDelay = 1.5f;
    public float maxSpawnDelay = 3.5f;
    public float visibleTime = 2.5f;

    private int missCount = 0;
    private bool isActive = false;

    void Start()
    {
        whirlwind.SetActive(false);
        UpdateMissText();
        StartCoroutine(TornadoLoop());
    }

    IEnumerator TornadoLoop()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(waitTime);

            ShowTornado();
            yield return new WaitForSeconds(visibleTime);

            if (isActive)
            {
                missCount++;
                UpdateMissText();
                HideTornado();
            }
        }
    }

    void ShowTornado()
    {
        isActive = true;
        whirlwind.SetActive(true);
    }

    void HideTornado()
    {
        isActive = false;
        whirlwind.SetActive(false);
    }

    void UpdateMissText()
    {
        missText.text = "Misses: " + missCount;
    }

    // Called by whirlwind when clicked
    public void TornadoClicked()
    {
        if (!isActive) return;
        HideTornado();
    }
}
