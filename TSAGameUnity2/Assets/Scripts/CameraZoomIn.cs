using UnityEngine;

public class CameraZoomIn : MonoBehaviour
{
    public float startSize = 10f;
    public float endSize = 5f;
    public float zoomDuration = 2f;
    public float delayBeforeZoom = 1f;  // NEW: Wait for fade to finish
    
    private Camera cam;
    private float currentTime = 0f;
    private float delayTimer = 0f;
    private bool isZooming = false;
    private bool delayComplete = false;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographicSize = startSize;
    }

    void Update()
    {
        if (!delayComplete)
        {
            delayTimer += Time.deltaTime;
            if (delayTimer >= delayBeforeZoom)
            {
                delayComplete = true;
                isZooming = true;
            }
            return;
        }
        
        if (isZooming)
        {
            currentTime += Time.deltaTime;
            float progress = currentTime / zoomDuration;
            
            cam.orthographicSize = Mathf.Lerp(startSize, endSize, progress);
            
            if (progress >= 1f)
            {
                isZooming = false;
                cam.orthographicSize = endSize;
            }
        }
    }
}