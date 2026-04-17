using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager Instance;

    public List<Ball> balls = new List<Ball>();

    public Transform goalLeft;
    public Transform goalRight;

    public Transform player;

    void Awake()
    {
        Instance = this;
    }

    public Transform GetNearestGoal(Vector3 ballPos)
    {
        float d1 = Vector3.Distance(ballPos, goalLeft.position);
        float d2 = Vector3.Distance(ballPos, goalRight.position);

        return d1 < d2 ? goalLeft : goalRight;
    }

    public Ball GetFarthestBall()
    {
        Ball farthest = null;
        float maxDist = 0;

        foreach (Ball ball in balls)
        {
            float d = Vector3.Distance(player.position, ball.transform.position);

            if (d > maxDist)
            {
                maxDist = d;
                farthest = ball;
            }
        }

        return farthest;
    }

    public void AutoKick()
    {
        Ball farthest = GetFarthestBall();

        if (farthest != null)
        {
            farthest.Kick();
        }
    }


}