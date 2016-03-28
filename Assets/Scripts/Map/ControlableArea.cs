using UnityEngine;

public class ControlableArea : MonoBehaviour
{
    [SerializeField]
    private Light Light;
    [SerializeField]
    private Color SkeletonColor;
    [SerializeField]
    private Color RedSkeletonColor;

    private SphereCollider sphereCollider;

    void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    public void Update()
    {
        int NumberOfRedSkeleton = 0;
        int NumberOfSkeleton = 0;

        var colliders = Physics.OverlapSphere(transform.position, sphereCollider.radius);
        foreach(var collided in colliders)
        {
            CharacterTypeController typeController = collided.GetComponent<CharacterTypeController>();
            if (typeController != null)
            {
                if (typeController.CharacterType == CharacterType.SKELETON)
                {
                    NumberOfSkeleton++;
                }
                else if (typeController.CharacterType == CharacterType.RED_SKELETON)
                {
                    NumberOfRedSkeleton++;
                }
            }
        }

        UpdateView(NumberOfSkeleton, NumberOfRedSkeleton);
    }

    private void UpdateView(int NumberOfSkeleton, int NumberOfRedSkeleton)
    {
        if(NumberOfSkeleton > NumberOfRedSkeleton)
        {
            Light.color = SkeletonColor;
        }
        else if (NumberOfSkeleton < NumberOfRedSkeleton)
        {
            Light.color = RedSkeletonColor;
        }else
        {
            Light.color = Color.white;
        }
    }
}

