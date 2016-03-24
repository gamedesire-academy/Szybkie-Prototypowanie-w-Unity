using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomDestinitionProvider : AbstractDestinationProvider
{
    private List<ControlableArea> Points;

    void Awake()
    {
        Points = FindObjectsOfType<ControlableArea>().ToList();
    }

    public override Vector3 GetDestination()
    {
        ControlableArea area = Points[Random.Range(0, Points.Count)];
        return area.transform.position;
    }
}

