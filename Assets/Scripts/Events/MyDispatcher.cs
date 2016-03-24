using System.Collections.Generic;

public delegate void MyEvent(object e);

public class MyDispatcher
{
    private static Dictionary<string, MyEvent> Map = new Dictionary<string, MyEvent>();

    public static void AddListener(string nameEvent, MyEvent func)
    {
        if (!Map.ContainsKey(nameEvent))
        {
            Map.Add(nameEvent, func);
        }
        else
        {
            Map[nameEvent] += func;
        }
    }

    public static void RemoveListener(string nameEvent, MyEvent func)
    {
        if (Map.ContainsKey(nameEvent))
        {
            Map[nameEvent] -= func;
        }
    }

    public static void Dispatch(string nameEvent, object e = null)
    {
        if (Map.ContainsKey(nameEvent) && Map[nameEvent] != null)
            Map[nameEvent](e);
    }
}
