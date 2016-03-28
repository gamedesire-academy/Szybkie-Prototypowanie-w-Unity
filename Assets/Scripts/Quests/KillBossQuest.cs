using System;
using UnityEngine;

public class KillBossQuest : QuestBase
{
    private Transform Player;
    private LifeController LifeController;
    private bool IsDone;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        LifeController = GetComponent<LifeController>();
        LifeController.Died += OnDied;
    }

    public void OnDestroy()
    {
        LifeController.Died -= OnDied;
    }

    void OnDied()
    {
        IsDone = true;
    }

    public override bool Done()
    {
        return IsDone;
    }

    public override string EndConditions()
    {
        return String.Format("Kill\nDistance: {0:N2}", Vector3.Distance(transform.position, Player.position));
    }
}
