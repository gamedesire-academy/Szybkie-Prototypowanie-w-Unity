using System.Collections.Generic;
using UnityEngine;

public class CanGroupMoveToBehaviour : AIBehaviour
{
    [SerializeField]
    private AlianceController AlianceController;
    [SerializeField]
    private int NumberOfAllies = 5;
    [SerializeField]
    private int Cooldown = 15;
    [SerializeField]
    private AbstractDestinationProvider Destinations;

    private List<GameObject> Allies = new List<GameObject>();

    private float lastUseTime;
    private SphereCollider sphereCollider;
    
    void Awake()
    {
        lastUseTime = Time.time;
        sphereCollider = GetComponent<SphereCollider>();
    }

    public override bool CanPerform()
    {
        Allies.Clear();
        var colliders = Physics.OverlapSphere(transform.position, sphereCollider.radius);
        foreach (var collided in colliders)
        {
            var CharacterType = collided.GetComponent<CharacterTypeController>();
            var LifeController = collided.GetComponent<LifeController>();

            if (CharacterType != null && LifeController != null && AlianceController.IsMyFriend(CharacterType.CharacterType))
            {
                Allies.Add(collided.gameObject);
            }
        }

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
                patrol.StartPosition = destination;
            }
        }
    }
}

