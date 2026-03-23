using UnityEngine;

public class FallingNote : MonoBehaviour
{
    public KeyCode keyToPress;  // What key should be pressed
    public float fallSpeed = 5f;
    
    private bool canBePressed = false;
    private bool hasBeenHit = false;
    
    private BattleManager battleManager;
    
    void Start()
    {
        battleManager = FindObjectOfType<BattleManager>();
    }
    
    void Update()
    {
        // Move note downward
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        
        // Check if note is in hit zone and player presses key
        if (canBePressed && !hasBeenHit)
        {
            if (Input.GetKeyDown(keyToPress))
            {
                Hit();
            }
        }
        
        // Destroy if goes off screen
        if (transform.position.y < -10f)
        {
            if (!hasBeenHit)
            {
                Miss();
            }
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HitLine"))
        {
            canBePressed = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("HitLine"))
        {
            canBePressed = false;
            if (!hasBeenHit)
            {
                Miss();
            }
        }
    }
    
    void Hit()
    {
        hasBeenHit = true;
        battleManager.OnNoteHit();
        
        // Visual feedback
        GetComponent<SpriteRenderer>().color = Color.green;
        
        Destroy(gameObject, 0.1f);
    }
    
    void Miss()
    {
        battleManager.OnNoteMiss();
    }
}