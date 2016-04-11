using UnityEngine;

public class AttackBehaviour : AIBehaviour
{
    [SerializeField]
    private NavMeshAgent NavMeshAgent;
    [SerializeField]
    private CharacterWeapons CharacterWeapons;

    private GameObject Player;
    private float LastAttack;

    [SerializeField]
    private AnimationController AnimationController;

    [SerializeField]
    private AlianceController AlianceController;

    public override bool CanPerform()
    {
        return Player;
    }

    public override void Perform()
    {
        NavMeshAgent.SetDestination(Player.transform.position);

        transform.LookAt(Player.transform, Vector3.up);
        AnimationController.Attack();
        if (LastAttack + CharacterWeapons.CurrentWeapon.Speed < Time.time)
        {
            Player.GetComponent<LifeController>().Minus(CharacterWeapons);
            LastAttack = Time.time;
        }
    }

    
    void OnTriggerEnter(Collider collider)
    {
        if (Player != null)
            return;

        var CharacterType = collider.GetComponent<CharacterTypeController>();
        var LifeController = collider.GetComponent<LifeController>();

        if (CharacterType != null && LifeController != null && AlianceController.IsMyEnemy(CharacterType.CharacterType))
        {
            LastAttack = Time.time;
            Player = collider.gameObject;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (Player != null && collider.gameObject == Player)
        {
            Player = null;
        }
    }
}

