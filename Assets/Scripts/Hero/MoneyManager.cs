using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int CurrentMoney { get; set; }

    void Awake()
    {
        CurrentMoney = 200;

        MyDispatcher.AddListener(GameEvents.CHANGE_MONEY, OnChangeMoney);
    }

    private void OnChangeMoney(object e)
    {
        int add = (int)e;
        CurrentMoney += add;
    }
}