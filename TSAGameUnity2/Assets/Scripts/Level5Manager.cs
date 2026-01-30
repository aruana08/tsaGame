using UnityEngine;
using System.Collections;

public class Level5Manager : MonoBehaviour
{
    public GameObject player;
    public Transform playerSpawnPoint;
    public GameObject pathArea;
    public GameObject gateArea;
    public FadeTransition fadeTransition;
    public float delayBeforeFade = 0.3f;

    void Start()
    {
        // Spawn player at starting position
        player.transform.position = playerSpawnPoint.position;
        player.SetActive(true);
        
        // Make sure correct areas are active
        pathArea.SetActive(true);
        gateArea.SetActive(false);
    }

    public void OnBridgeEndReached()
    {
        StartCoroutine(TransitionToGateArea());
    }
    
    private IEnumerator TransitionToGateArea()
    {
        // Disable player movement
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }
        
        // Small delay
        yield return new WaitForSeconds(delayBeforeFade);
        
        // Fade to black
        yield return StartCoroutine(fadeTransition.FadeToBlack());
        
        // Hide player
        player.SetActive(false);
        
        // Switch backgrounds
        pathArea.SetActive(false);
        gateArea.SetActive(true);
        
        // Fade from black
        yield return StartCoroutine(fadeTransition.FadeFromBlack());
    }
}