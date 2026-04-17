using UnityEngine;

public class PlayerBallDetector : MonoBehaviour
{
    public float detectRange = 2f;

    void Update()
    {
        Ball[] balls = FindObjectsOfType<Ball>();

        foreach (Ball ball in balls)
        {
            float dist = Vector3.Distance(transform.position, ball.transform.position);

            if (dist < detectRange)
                ball.ShowKickButton(true);
            else
                ball.ShowKickButton(false);
        }
    }
}