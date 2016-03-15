using UnityEngine;
using UnityEngine.UI;

public class PotionsDisplay : MonoBehaviour
{
    private Text text;

    [SerializeField]
    private PotionsManager PotionsManager = null;

    public void Start()
    {
        text = GetComponent<Text>();
        Update();
    }

    public void Update()
    {
        text.text = "Potions: " + PotionsManager.CurrentPotions.ToString();
    }
}