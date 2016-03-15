using UnityEngine;

class MoveController : MonoBehaviour
{
    private NavMeshAgent Agent;

    //private AnimationController AnimationController;

    void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        //AnimationController = GetComponent<AnimationController>();
    }

    public void Move(Vector3 point)
    {
        //AnimationController.Walk();
        Agent.SetDestination(point);
    }

    public void Update()
    {
        //if (Agent.hasPath && Agent.remainingDistance <= .5f && !Agent.pathPending)
        //    AnimationController.Idle();
    }
}

