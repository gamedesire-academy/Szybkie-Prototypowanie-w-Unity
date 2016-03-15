using UnityEngine;

public class AttackBehaviour : AIBehaviour
{
    [SerializeField]
    private CharacterWeapons CharacterWeapons;

    private GameObject Player;
    private float LastAttack;

    //[SerializeField]
    //private AnimationController AnimationController;

    public override bool CanPerform()
    {
        return Player;
    }

    public override void Perform()
    {
        transform.LookAt(Player.transform, Vector3.up);
        //AnimationController.Attack();
        if (LastAttack + CharacterWeapons.CurrentWeapon.Speed < Time.time)
        {
            Player.GetComponent<LifeController>().Minus(CharacterWeapons);
            LastAttack = Time.time;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            LastAttack = Time.time;
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
}

