using System;
using UnityEngine;

public class MoveToQuest : QuestBase
{
    private Transform Player;
    private bool IsDone;
    private bool IsActive;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        base.OnStart += OnStartAction;
        base.OnDone += OnEndAction;
    }

    private void OnStartAction()
    {
        IsActive = true;
    }

    private void OnEndAction()
    {
        IsActive = false;
    }

    public override bool Done()
    {
        return IsDone;
    }

    public override string EndConditions()
    {
        return String.Format("Move to\nDistance: {0:N2}", Vector3.Distance(transform.position, Player.position));
    }

    public void OnTriggerEnter(Collider other)
    {
        if (IsActive)
        {
            if (other.tag == "Player")
            {
                IsDone = true;
            }
        }
    }
}
