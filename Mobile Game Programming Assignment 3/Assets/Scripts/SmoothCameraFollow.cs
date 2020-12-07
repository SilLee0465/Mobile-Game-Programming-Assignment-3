using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(player.position.x, 4.45f, player.position.z - 12f);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
