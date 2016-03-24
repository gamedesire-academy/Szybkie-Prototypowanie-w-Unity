using UnityEngine;

public class PatrolBehaviour : AIBehaviour
{
    [SerializeField]
    private NavMeshAgent NavMeshAgent;
    [SerializeField]
    private AnimationController AnimationController;
    [SerializeField]
    private float MaxPatrolDistance = 10f;

    private Vector3 startPosition;
    public Vector3 StartPosition
    {
        get
        {
            return startPosition;
        }
        set
        {
            startPosition = value;
            NextPosition = CalculateNewPatrolPosition();
        }
    }
    private Vector3 NextPosition;

    void Start()
    {
        StartPosition = transform.position;
        NextPosition = CalculateNewPatrolPosition();
    }

    public override bool CanPerform()
    {
        return true;
    }

    public override void Perform()
    {
        AnimationController.Walk();
        NavMeshAgent.SetDestination(NextPosition);

        if (!NavMeshAgent.pathPending)
        {
            if (!NavMeshAgent.hasPath || NavMeshAgent.remainingDistance <= .5f)
            {
                NextPosition = CalculateNewPatrolPosition();
            }
        }
    }

    private Vector3 CalculateNewPatrolPosition()
    {
        Vector2 rand = Random.insideUnitCircle * MaxPatrolDistance;
        return new Vector3(rand.x, 0f, rand.y) + StartPosition;
    }
}

