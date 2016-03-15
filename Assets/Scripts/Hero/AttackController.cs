using UnityEngine;

public class AttackController : MonoBehaviour
{
    private GameObject Enemy;
    private NavMeshAgent Agent;
    private CharacterWeapons CharacterWeapons;
    private float LastAttackTime;

    //private AnimationController AnimationController;

    void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        CharacterWeapons = GetComponent<CharacterWeapons>();
        //AnimationController = GetComponent<AnimationController>();
    }

    public void Attack(GameObject obj)
    {
        Enemy = obj;
        if (CanAttack())
        {
            //AnimationController.Attack();
            Enemy.GetComponent<LifeController>().Minus(CharacterWeapons);
            LastAttackTime = Time.time;
        }
    }

    public void Stop()
    {
        Enemy = null;
    }

    void Update()
    {
        if (Enemy != null && !EnemyIsNear())
        {
            //AnimationController.Walk();
            Agent.SetDestination(Enemy.transform.position);
        }else if(Enemy != null)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Enemy.transform.position - transform.position, Vector3.up), 5);
        }
    }

    bool CanAttack()
    {
        return Enemy != null && EnemyIsNear() && LastAttackTime + CharacterWeapons.CurrentWeapon.Speed < Time.time;
    }

    bool EnemyIsNear()
    {
        return Vector3.Distance(Enemy.transform.position, transform.position) <= 3.5f;
    }
}
