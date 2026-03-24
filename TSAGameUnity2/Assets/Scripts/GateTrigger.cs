using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    public GameObject skeletonBoss;
    public GameObject gate;
    public AudioSource bossSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something entered gate: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered gate trigger");

            if (skeletonBoss != null)
                skeletonBoss.SetActive(true);

            if (gate != null)
                gate.SetActive(false);
            if (bossSound != null)
                bossSound.Play();
        }
    }
    
}