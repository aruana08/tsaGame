using UnityEngine;

public class RisingLava : MonoBehaviour
{
    public float riseSpeed = 1f;
    public float delayAfterPlayerMoves = 10f;

    private bool isRising = false;
    private bool riseScheduled = false;

    void Update()
    {
        if (!isRising) return;

        transform.Translate(Vector2.up * riseSpeed * Time.deltaTime);
    }

    // Called once when player first moves
    public void StartRising()
    {
        if (riseScheduled) return;

        riseScheduled = true;
        Invoke(nameof(EnableRising), delayAfterPlayerMoves);
    }

    void EnableRising()
    {
        isRising = true;
    }

    // Stop lava when player wins
    public void StopRising()
    {
        isRising = false;
    }

    // 🔥 Lava kills player
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
