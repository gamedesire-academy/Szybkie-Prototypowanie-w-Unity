using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    [SerializeField]
    private Transform Target = null;
    [SerializeField]
    private float Distance = 0;
    [SerializeField]
    private Vector3 Vector;

    void Update()
    {
        transform.position = Target.position + transform.TransformVector(Vector) * Distance;
    }
}
