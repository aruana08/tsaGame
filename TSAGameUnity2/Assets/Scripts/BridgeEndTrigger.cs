using UnityEngine;

public class BridgeEndTrigger : MonoBehaviour
{
    private Level5Manager sceneManager;

    void Start()
    {
        sceneManager = FindObjectOfType<Level5Manager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sceneManager.OnBridgeEndReached();
        }
    }
}