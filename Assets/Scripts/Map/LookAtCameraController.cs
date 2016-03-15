using UnityEngine;

public class LookAtCameraController : MonoBehaviour
{
	void Update ()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
