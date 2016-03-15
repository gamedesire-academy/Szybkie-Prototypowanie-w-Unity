using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField]
    private MoneyManager MoneyManager;
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
        Update();
    }

    void Update()
    {
        text.text = "Money: " + MoneyManager.CurrentMoney.ToString();
    }
}