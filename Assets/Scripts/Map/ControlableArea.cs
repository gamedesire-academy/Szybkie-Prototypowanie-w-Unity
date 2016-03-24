using System.Linq;
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
            AlianceController AlianceController = collided.GetComponent<AlianceController>();
            if (AlianceController != null)
            {
                if (AlianceController.GetCharacterType() == CharacterType.SKELETON)
                {
                    NumberOfSkeleton++;
                }
                else if (AlianceController.GetCharacterType() == CharacterType.RED_SKELETON)
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

