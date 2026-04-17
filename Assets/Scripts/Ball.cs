using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject kickButton;
    public Rigidbody rb;
    public GameObject confettiPrefab;

    public CharacterController playerController;
    public Collider ballCollider;

    bool isFlying = false;

    void Start()
    {
        BallManager.Instance.balls.Add(this);
        playerController = FindObjectOfType<CharacterController>();
    }

    public void Kick()
    {
        Transform goal = BallManager.Instance.GetNearestGoal(transform.position);

        Vector3 dir = (goal.position - transform.position).normalized;

        Physics.IgnoreCollision(playerController, ballCollider, true);

        rb.AddForce(dir * 12f, ForceMode.Impulse);

        isFlying = true;

        CameraController.Instance.FollowBall(this);

        Invoke(nameof(EnableCollision), 0.5f);
    }

    void EnableCollision()
    {
        Physics.IgnoreCollision(playerController, ballCollider, false);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (!isFlying) return;

        if (collision.collider.CompareTag("Goal"))
        {
            GoalHit();
        }
    }

    void GoalHit()
    {
        isFlying = false;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        Vector3 spawnPos = transform.position + Vector3.up * 10f;
        GameObject fx = Instantiate(confettiPrefab, spawnPos, Quaternion.identity);

        ParticleSystem ps = fx.GetComponent<ParticleSystem>();
        ps.Play();

        Invoke(nameof(ReturnCamera), 2f);
        
    }

    void ReturnCamera()
    {
        CameraController.Instance.FollowPlayer();
        Destroy(gameObject);

    }

    public void ShowKickButton(bool show)
    {
        kickButton.SetActive(show);
    }

    void OnDestroy()
    {
        if (BallManager.Instance != null)
        {
            BallManager.Instance.balls.Remove(this);
        }
    }
}