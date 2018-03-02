using UnityEngine;

public class BlastScript : MonoBehaviour 
{
    public int damage = 1;
    public bool isEnemyBlast = false;
    public float lifeTime = 1;
	HealthManager healthMngr; 
	public GameObject Ship;

	void Start () 
    {
		healthMngr = Ship.GetComponent<HealthManager> (); // Récupération du script du vaisseau
        Destroy(gameObject, lifeTime);
	}

    void Update()
    {
		if (healthMngr.healthPoint > 0) // Debug du NullRefException à l'explosion du vaisseau
		{
			Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, 10);
			foreach (Collider2D col in colliders) 
			{
				if (col.transform.name == GameObject.Find ("Ship").transform.name)
				{
					healthMngr.healthPoint -= 1; //Diminution du nombre de PV du joueur
				}  
			}
		}
    }
}
