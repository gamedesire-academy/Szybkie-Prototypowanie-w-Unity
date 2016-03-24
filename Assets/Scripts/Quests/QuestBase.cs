using System;
using UnityEngine;

public abstract class QuestBase : MonoBehaviour
{
    public abstract bool Done();
    public abstract string EndConditions();
    public Action OnStart;
    public Action OnDone;
}
