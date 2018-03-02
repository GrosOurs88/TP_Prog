using UnityEngine;

public class EnemyScript : MonoBehaviour 
{
    private WeaponScript[] weapons;

	void Awake()
    {
        weapons = GetComponentsInChildren<WeaponScript>();
	}
	
	void Update() 
    {
	    foreach(WeaponScript weapon in weapons)
        {
            if (weapon.CanAttack)
            {
                weapon.Attack(true); //true: it's en enemy
            }
        }
	}
}
