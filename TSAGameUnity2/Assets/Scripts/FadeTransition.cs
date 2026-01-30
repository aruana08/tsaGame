using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeTransition : MonoBehaviour
{
    public Image fadePanel;
    public float fadeDuration = 1f;
    
    private void Start()
    {
        // Start fully transparent
        Color c = fadePanel.color;
        c.a = 0f;
        fadePanel.color = c;
    }
    
    public IEnumerator FadeToBlack()
    {
        float elapsedTime = 0f;
        Color c = fadePanel.color;
        
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            fadePanel.color = c;
            yield return null;
        }
        
        c.a = 1f;
        fadePanel.color = c;
    }
    
    public IEnumerator FadeFromBlack()
    {
        float elapsedTime = 0f;
        Color c = fadePanel.color;
        
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            fadePanel.color = c;
            yield return null;
        }
        
        c.a = 0f;
        fadePanel.color = c;
    }
}