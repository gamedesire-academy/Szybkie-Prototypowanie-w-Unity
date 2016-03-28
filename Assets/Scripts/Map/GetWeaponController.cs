using UnityEngine;

public class GetWeaponController : MonoBehaviour
{
    private LootDropController LootDropController;

    [SerializeField]
    private float DamageMin = 15;
    [SerializeField]
    private float DamageMax = 50;
    [SerializeField]
    private float SpeedMin = 0.1f;
    [SerializeField]
    private float SpeedMax = 1;

    public void Awake()
    {
        LootDropController = GetComponent<LootDropController>();
        LootDropController.LootCollected += Action;
    }

    public void OnDestroy()
    {
        LootDropController.LootCollected -= Action;
    }

    private void Action()
    {
        var Weapon = new Weapon();
        Weapon.Power = Random.Range(DamageMin, DamageMax);
        Weapon.Speed = Random.Range(SpeedMin, SpeedMax);

        MyDispatcher.Dispatch(GameEvents.CHANGE_WEAPON, Weapon);
        //MyDispatcher.Dispatch(GameEvents.CREATE_HIGHLIGHTER, new HighligtData(transform.position, "New weapon"));
    }
}

