using UnityEngine;

public class GemPickup : MonoBehaviour
{
    public enum GemType { Water, Forest, Air, Fire }
    public GemType gemType;

    void OnMouseDown()
{
    if (GameProgress.Instance != null)
    {
        switch (gemType)
        {
            case GemType.Water:
                GameProgress.Instance.waterStone = true;
                break;
            case GemType.Forest:
                GameProgress.Instance.forestStone = true;
                break;
            case GemType.Air:
                GameProgress.Instance.airStone = true;
                break;
            case GemType.Fire:
                GameProgress.Instance.fireStone = true;
                break;
        }
    }

    // Hide gem
    gameObject.SetActive(false);

    // Show return panel
    Canvas canvas = FindObjectOfType<Canvas>();
    if (canvas != null)
    {
        Transform panel = canvas.transform.Find("ReturnPanel");
        if (panel != null)
        {
            panel.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("ReturnPanel not found under Canvas!");
        }
    }
    else
    {
        Debug.LogError("No Canvas found in scene!");
    }
}

}
