using System;
using UnityEngine;

public class OnOffLightOnQuest : MonoBehaviour
{
    [SerializeField]
    private QuestBase QuestBase;

    private Light Light;

    void Awake()
    {
        Light = GetComponent<Light>();
        QuestBase.OnStart += OnStart;
        QuestBase.OnDone += OnEnd;
    }

    public void OnDestroy()
    {
        QuestBase.OnStart -= OnStart;
        QuestBase.OnDone -= OnEnd;
    }

    private void OnStart()
    {
        Light.enabled = true;
    }

    private void OnEnd()
    {
        Light.enabled = false;
    }
}
