using UnityEngine;

public class BallUISetup : MonoBehaviour
{
    void Start()
    {
        Canvas canvas = GetComponentInChildren<Canvas>();

        if (canvas != null)
        {
            canvas.worldCamera = Camera.main;
        }
    }
}