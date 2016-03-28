using System;
using UnityEngine;

public class CollectMoneyQuest : QuestBase
{
    [SerializeField]
    private int Amount = 500;

    private int Collected;

    void Awake()
    {
        OnStart += () => 
        {
            MyDispatcher.AddListener(GameEvents.CHANGE_MONEY, OnChangeMoney);
        };

        OnDone += () =>
        {
            MyDispatcher.RemoveListener(GameEvents.CHANGE_MONEY, OnChangeMoney);
        };
    }

    private void OnChangeMoney(object e)
    {
        int value = (int)e;
        if(value > 0)
        {
            Collected += value;
        }
    }

    public override bool Done()
    {
        return Collected >= Amount;
    }

    public override string EndConditions()
    {
        return String.Format("Collect Money: {0}", Amount - Collected);
    }
}

