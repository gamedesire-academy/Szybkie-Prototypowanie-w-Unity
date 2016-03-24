using UnityEngine;
using UnityEngine.UI;

public class QuestDisplay : MonoBehaviour
{
    [SerializeField]
    private QuestManager QuestManager;

    private Text Description;

    void Awake()
    {
        Description = GetComponent<Text>();
    }

    void Update()
    {
        if(QuestManager.CurrentQuest != null)
        {
            Description.text = QuestManager.CurrentQuest.EndConditions();
        }
        else
        {
            Description.text = "No quest";
        }
    }
}
