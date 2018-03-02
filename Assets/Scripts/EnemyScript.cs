using UnityEngine;

public class EnemyScript : MonoBehaviour 
{
    private WeaponScript[] weapons;
	private GameObject poolMgr;
	private PoolManager poolMgrScript;

	void Awake()
    {
		poolMgr = GameObject.Find ("PoolManager");
		poolMgrScript = poolMgr.GetComponent<PoolManager> ();
        weapons = GetComponentsInChildren<WeaponScript>();
	}
	
	void Update() 
	{
	    foreach(WeaponScript weapon in weapons)
        {
			if (poolMgrScript.canFire == true) // Si le booléen du Script PoolManager qui permet de tirer est set à true
            {
                weapon.Attack(true); //true: it's en enemy
            }
        }
	}
}
