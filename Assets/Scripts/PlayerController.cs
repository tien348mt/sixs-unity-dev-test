using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6f;

    CharacterController controller;
    Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);

        if (move.magnitude > 0.1f)
        {
            transform.forward = move;
            anim.Play("a_Running");
        }
        else
        {
            anim.Play("a_Idle");
        }

        controller.Move(move * speed * Time.deltaTime);
    }
}