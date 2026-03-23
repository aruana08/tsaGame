using UnityEngine;
using System.Collections;

public class Level5Manager : MonoBehaviour
{
    public GameObject player;
    public Transform playerSpawnPoint;
    public GameObject pathArea;
    public GameObject gateArea;
    public GameObject battleArea;
    public FadeTransition fadeTransition;
    public float delayBeforeFade = 0.3f;
    public float gateDisplayTime = 2f;

    void Start()
    {
        player.transform.position = playerSpawnPoint.position;
        player.SetActive(true);
        
        pathArea.SetActive(true);
        gateArea.SetActive(false);
        battleArea.SetActive(false);
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
        
        yield return new WaitForSeconds(delayBeforeFade);
        
        // Fade to black
        yield return StartCoroutine(fadeTransition.FadeToBlack());
        
        player.SetActive(false);
        pathArea.SetActive(false);
        gateArea.SetActive(true);
        
        // Fade from black
        yield return StartCoroutine(fadeTransition.FadeFromBlack());
        
        // Wait at gate for 2 seconds
        yield return new WaitForSeconds(gateDisplayTime);
        
        // Transition to battle
        StartCoroutine(TransitionToBattleArea());
    }
    
    private IEnumerator TransitionToBattleArea()
    {
        // Fade to black
        yield return StartCoroutine(fadeTransition.FadeToBlack());
        
        // Switch to battle area
        gateArea.SetActive(false);
        battleArea.SetActive(true);
        
        // Fade from black
        yield return StartCoroutine(fadeTransition.FadeFromBlack());
    }
}
