using UnityEngine;

public class CharacterWeapons : MonoBehaviour
{
	[SerializeField]
	public Weapon CurrentWeapon = new Weapon();
	[SerializeField]
	public Armor CurrentArmor = new Armor();

    public void SetWeapon(Weapon weapon)
    {
        CurrentWeapon = weapon;
    }

    public void SetArmor(Armor armor)
    {
        CurrentArmor = armor;
    }
}
