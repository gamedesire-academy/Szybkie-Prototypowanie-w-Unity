using UnityEngine;

public class PotionDrinker : MonoBehaviour
{
    private LifeController lifeController;

    void Awake()
    {
        lifeController = GetComponent<LifeController>();
        MyDispatcher.AddListener(GameEvents.DRINK_POTION, onDrinkPotion);
    }

    public void OnDestroy()
    {
        MyDispatcher.RemoveListener(GameEvents.DRINK_POTION, onDrinkPotion);
    }

    private void onDrinkPotion(object iEvent)
    {
        lifeController.Heal();
    }
}