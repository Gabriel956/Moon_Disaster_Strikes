using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform player;
    
    [Header("Offset")]
    public float offsetX = 0f;
    public float offsetY = 2f;
    public float offsetZ = -10f;
    
    [Header("Smoothing")]
    public float smoothSpeed = 5f;
    
    [Header("Bounds (Optional)")]
    public bool useBounds = false;
    public float minX = -10f;
    public float maxX = 10f;
    
    void LateUpdate()
    {
        if (player == null) return;
        
        // Calculate target position
        Vector3 targetPos = new Vector3(
            player.position.x + offsetX,
            player.position.y + offsetY,
            offsetZ
        );
        
        // Apply bounds if enabled
        if (useBounds)
        {
            targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
        }
        
        // Smoothly move camera
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);
    }
}
