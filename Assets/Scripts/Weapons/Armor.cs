[System.Serializable]
public class Armor
{
    //public string Name;
    //public int ID;
    //public Sprite Avatar;
    public float Defense;

    public static bool operator <(Armor a, Armor b)
    {
        return a.Defense < b.Defense;
    }

    public static bool operator >(Armor a, Armor b)
    {
        return a.Defense > b.Defense;
    }
}

