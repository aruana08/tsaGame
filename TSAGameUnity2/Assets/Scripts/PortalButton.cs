using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalButton : MonoBehaviour
{
    public string sceneToLoad;

    // When player touches the portal
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Load the next scene immediately
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
