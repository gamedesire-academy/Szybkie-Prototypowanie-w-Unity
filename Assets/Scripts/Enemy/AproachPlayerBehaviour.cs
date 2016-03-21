using UnityEngine;

public class AproachPlayerBehaviour : AIBehaviour
{
    [SerializeField]
    private NavMeshAgent NavMeshAgent;

    [SerializeField]
    private AnimationController AnimationController;

    public override bool CanPerform()
    {
        return true;
    }

    public override void Perform()
    {
        AnimationController.Walk();
        GameObject PlayerObject = GameObject.FindGameObjectWithTag("Player"); // to remove
        NavMeshAgent.SetDestination(PlayerObject.transform.position);
    }
}
