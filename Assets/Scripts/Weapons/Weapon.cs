[System.Serializable]
public class Weapon
{
    //public string Name;
    //public int ID;
    //public Sprite Avatar;
    public float Power;
    public float Speed;

    public static bool operator <(Weapon a, Weapon b)
    {
        return (a.Power * a.Speed) < (b.Power * b.Speed);
    }

    public static bool operator >(Weapon a, Weapon b)
    {
        return (a.Power * a.Speed) > (b.Power * b.Speed);
    }
}

