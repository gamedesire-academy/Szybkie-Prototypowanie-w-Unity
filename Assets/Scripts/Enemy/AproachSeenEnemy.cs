using UnityEngine;

public class AproachSeenEnemy : AIBehaviour
{
    [SerializeField]
    private NavMeshAgent NavMeshAgent;
    [SerializeField]
    private AnimationController AnimationController;
    //[SerializeField]
    //private AlianceController AlianceController;

    private GameObject Player;

    public override bool CanPerform()
    {
        return Player;
    }

    public override void Perform()
    {
        AnimationController.Walk();
        NavMeshAgent.SetDestination(Player.transform.position);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Player = collider.gameObject;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Player = null;
        }
    }

    /*void OnTriggerEnter(Collider collider)
    {
        if (Player != null)
            return;

        var CharacterType = collider.GetComponent<CharacterTypeController>();
        var LifeController = collider.GetComponent<LifeController>();

        if (CharacterType != null && LifeController != null && AlianceController.IsMyEnemy(CharacterType.CharacterType))
        {
            Player = collider.gameObject;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (Player != null && collider.gameObject == Player)
        {
            Player = null;
        }
    }*/
}

