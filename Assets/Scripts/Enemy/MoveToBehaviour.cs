using UnityEngine;

public class MoveToBehaviour : AIBehaviour
{
    [SerializeField]
    private NavMeshAgent NavMeshAgent;
    [SerializeField]
    private AnimationController AnimationController;

    private bool IsActive;
    private Vector3 Destinition;

    public override bool CanPerform()
    {
        return IsActive;
    }

    public override void Perform()
    {
        AnimationController.Walk();
        NavMeshAgent.SetDestination(Destinition);
        if (NavMeshAgent.hasPath && NavMeshAgent.remainingDistance <= .5f && !NavMeshAgent.pathPending)
        {
            IsActive = false;
            AnimationController.Idle();
        }
    }

    public void SetDestination(Vector3 pos)
    {
        Destinition = pos;
        IsActive = true;
    }
}

