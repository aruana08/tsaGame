using UnityEngine;

public class GemPickup : MonoBehaviour
{
    public enum GemType { Water, Forest, Air, Fire }
    public GemType gemType;

    void OnMouseDown()
    {
        if (GameProgress.Instance == null)
        {
            Debug.LogError("GameProgress not found!");
            return;
        }

        // Save progress
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

        // Hide gem
        gameObject.SetActive(false);

        // Find and show return UI
        GameObject returnPanel = GameObject.Find("ReturnPanel");
        if (returnPanel != null)
        {
            returnPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("ReturnPanel not found in scene!");
        }
    }
}
