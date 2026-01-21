using UnityEngine;

public class RisingLava : MonoBehaviour
{
    public float riseSpeed = 1f;

    void Update()
    {
        transform.position += Vector3.up * riseSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player burned!");
            // restart level
        }
    }
}
