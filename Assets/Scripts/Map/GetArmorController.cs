using UnityEngine;

public class GetArmorController : MonoBehaviour
{
    private LootDropController LootDropController;

    [SerializeField]
    private float DefenseMin = 5;
    [SerializeField]
    private float DefenseMax = 15;

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
        var Armor = new Armor();
        Armor.Defense = Random.Range(DefenseMin, DefenseMax);

        MyDispatcher.Dispatch(GameEvents.CHANGE_ARMORY, Armor);
        MyDispatcher.Dispatch(GameEvents.CREATE_HIGHLIGHTER, new HighligtData(transform.position, "New armor"));
    }
}

