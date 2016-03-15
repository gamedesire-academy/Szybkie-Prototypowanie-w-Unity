using System;
using UnityEngine;

public class PotionsManager : MonoBehaviour
{
    public int CurrentPotions { get; set; }

    public PotionsManager()
    {
        CurrentPotions = 5;
    }

    public void Start()
    {
        MyDispatcher.AddListener(GameEvents.DRINK_POTION, onDrinkPotion);
        MyDispatcher.AddListener(GameEvents.ADD_POTION, OnAddPotion);
    }

    public void OnDestroy()
    {
        MyDispatcher.RemoveListener(GameEvents.DRINK_POTION, onDrinkPotion);
        MyDispatcher.RemoveListener(GameEvents.ADD_POTION, OnAddPotion);
    }

    private void onDrinkPotion(object iEvent)
    {
        if (CurrentPotions > 0)
        {
            CurrentPotions -= 1;
        }
    }

    private void OnAddPotion(object e)
    {
        CurrentPotions += 1;
    }
}