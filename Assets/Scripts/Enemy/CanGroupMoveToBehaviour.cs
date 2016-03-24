using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CanGroupMoveToBehaviour : AIBehaviour
{
    [SerializeField]
    private AlianceController AlianceController;
    [SerializeField]
    private int NumberOfAllies = 1;
    [SerializeField]
    private int Cooldown = 15;
    [SerializeField]
    private AbstractDestinationProvider Destinations;

    private List<GameObject> Allies = new List<GameObject>();

    private float lastUseTime;

    void Awake()
    {
        lastUseTime = Time.time;
    }

    public override bool CanPerform()
    {
        Allies = Allies.Where((x) => x != null).ToList();
        return lastUseTime + Cooldown < Time.time && Allies.Count > NumberOfAllies;
    }

    public override void Perform()
    {
        lastUseTime = Time.time;
        foreach (GameObject obj in Allies)
        {
            var destination = Destinations.GetDestination();
            var moveTo = obj.GetComponentInChildren<MoveToBehaviour>();
            if(moveTo != null)
            {
                moveTo.SetDestination(destination);
            }

            var patrol = obj.GetComponentInChildren<PatrolBehaviour>();
            if(patrol != null)
            {
                Debug.Log("QWEASD");
                patrol.StartPosition = destination;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!Allies.Contains(other.gameObject))
        {
            var CharacterType = other.GetComponent<CharacterTypeController>();
            var LifeController = other.GetComponent<LifeController>();

            if (CharacterType != null && LifeController != null && AlianceController.IsMyFriend(CharacterType.EnemyType))
            {
                Allies.Add(other.gameObject);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (Allies.Contains(other.gameObject))
        {
            Allies.Remove(other.gameObject);
        }
    }
}

