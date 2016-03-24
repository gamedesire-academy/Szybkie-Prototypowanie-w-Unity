using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    private List<QuestBase> QuestList;

    private QuestBase currentQuest;
    public QuestBase CurrentQuest
    {
        get
        {
            return currentQuest;
        }
    }

    void Start()
    {
        SetNextQuest();
    }

    void Update()
    {
        if (CurrentQuest != null && CurrentQuest.Done())
        {
            if (CurrentQuest.OnDone != null)
                CurrentQuest.OnDone();

            QuestList.RemoveAt(0);
            SetNextQuest();
        }
    }

    private void SetNextQuest()
    {
        QuestList = QuestList.Where((x) => x != null).ToList();
        if (QuestList.Count > 0)
        {
            currentQuest = QuestList[0];
            if (CurrentQuest.OnStart != null)
                CurrentQuest.OnStart();
        }
        else
        {
            currentQuest = null;
        }
    }
}
