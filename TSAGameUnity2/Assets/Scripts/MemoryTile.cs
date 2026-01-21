using UnityEngine;
using System.Collections;

public class MemoryTile : MonoBehaviour
{
    public int tileID;

    private MemoryPuzzleManager manager;
    private SpriteRenderer sr;
    private Color originalColor;

    void Start()
    {
        manager = FindObjectOfType<MemoryPuzzleManager>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    void OnMouseDown()
    {
        manager.PlayerClickedTile(tileID);
    }

    public void Flash(Color color)
    {
        StartCoroutine(FlashRoutine(color));
    }

    IEnumerator FlashRoutine(Color color)
    {
        sr.color = color;
        yield return new WaitForSeconds(0.3f);
        sr.color = originalColor;
    }
}
