using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    public Transform player;

    Transform target;

    public Vector3 offset = new Vector3(0, 15, -8);

    void Awake()
    {
        Instance = this;
        target = player;
    }

    void LateUpdate()
    {
        if (target == null) return;

        transform.position = target.position + offset;

        transform.LookAt(target);
    }

    public void FollowBall(Ball ball)
    {
        target = ball.transform;
    }

    public void FollowPlayer()
    {
        target = player;
    }
}