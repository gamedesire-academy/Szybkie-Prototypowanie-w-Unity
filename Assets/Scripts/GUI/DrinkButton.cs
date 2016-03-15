using UnityEngine;
using UnityEngine.UI;

public class DrinkButton : MonoBehaviour
{
    private Button button;

    [SerializeField]
    private PotionsManager PotionsManager = null;

    public void Start()
    {
        button = GetComponent<Button>();
        Update();
    }

    public void Update()
    {
        button.interactable = PotionsManager.CurrentPotions > 0;
    }

    public void Drink()
    {
        MyDispatcher.Dispatch(GameEvents.DRINK_POTION);
    }
}