using UnityEngine;

public class GateFadeIn : MonoBehaviour
{
    public float fadeInDuration = 2f;
    private SpriteRenderer spriteRenderer;
    private float elapsedTime = 0f;
    private bool isFading = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Start fully transparent
        Color c = spriteRenderer.color;
        c.a = 0f;
        spriteRenderer.color = c;
    }

    void Update()
    {
        if (isFading)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);
            
            Color c = spriteRenderer.color;
            c.a = alpha;
            spriteRenderer.color = c;
            
            if (elapsedTime >= fadeInDuration)
            {
                isFading = false;
                c.a = 1f;
                spriteRenderer.color = c;
            }
        }
    }
}