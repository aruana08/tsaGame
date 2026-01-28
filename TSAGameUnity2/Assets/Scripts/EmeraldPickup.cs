using UnityEngine;

public class EmeraldPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Add emerald to crown system
            GameProgress.Instance.AddEmerald();

            // Destroy emerald in scene
            Destroy(gameObject);
        }
    }
}
