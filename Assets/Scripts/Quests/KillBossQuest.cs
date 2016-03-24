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
        return "Kill\nDistance: " + Vector3.Distance(transform.position, Player.position);
    }
}
