using UnityEngine;

public class RetreatBehaviour : AIBehaviour
{
    [SerializeField]
    private NavMeshAgent NavMeshAgent;
    [SerializeField]
    private AnimationController AnimationController;

    [SerializeField]
    private LifeController LifeController;
    [SerializeField]
    private float RetreatThreshold = .3f;

    private Vector3 RetreatPosition;

    void Start()
    {
        RetreatPosition = transform.position;
    }

    public override bool CanPerform()
    {
        return LifeController.PercentLife <= RetreatThreshold;
    }

    public override void Perform()
    {
        NavMeshAgent.SetDestination(RetreatPosition);

        if (NavMeshAgent.remainingDistance <= 2)
        {
            AnimationController.Idle();
        }else
        {
            AnimationController.Walk();
        }
    }
}

