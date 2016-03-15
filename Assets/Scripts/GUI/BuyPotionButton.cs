using UnityEngine;
using UnityEngine.UI;

public class BuyPotionButton : MonoBehaviour
{
    [SerializeField]
    private MoneyManager MoneyManager;

    private Button button;

    [SerializeField]
    private int cost = 100;

    public void Start()
    {
        button = GetComponent<Button>();
        Update();
    }

    public void Update()
    {
        button.interactable = MoneyManager.CurrentMoney >= cost;
    }

    public void Buy()
    {
        if (MoneyManager.CurrentMoney >= cost)
        {
            MyDispatcher.Dispatch(GameEvents.CHANGE_MONEY, -cost);
            MyDispatcher.Dispatch(GameEvents.ADD_POTION);
        }
    }
}
