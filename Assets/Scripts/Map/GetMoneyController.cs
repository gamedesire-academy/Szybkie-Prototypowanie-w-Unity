using UnityEngine;

public class GetMoneyController : MonoBehaviour
{
    private LootDropController LootDropController;

    public int AmountMin = 100;
    public int AmountMax = 100;

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
        int Amount = Random.Range(AmountMin, AmountMax);

        MyDispatcher.Dispatch(GameEvents.CHANGE_MONEY, Amount);
        MyDispatcher.Dispatch(GameEvents.CREATE_HIGHLIGHTER, new HighligtData(transform.position, "Money +" + Amount));
    }
}