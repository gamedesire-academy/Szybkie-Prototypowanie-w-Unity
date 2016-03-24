using UnityEngine;

public class LookAtCameraController : MonoBehaviour
{
    void Start()
    {
        Update();
    }

	void Update ()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
