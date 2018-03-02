using UnityEngine;

public class BlastScript : MonoBehaviour {
    public int damage = 1;
    public bool isEnemyBlast = false;
    public float lifeTime = 1;

	void Start () 
    {
        Destroy(gameObject, lifeTime);
	}

    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 10);
        foreach (Collider2D col in colliders)
        {
            if(col.transform.name == GameObject.Find("Ship").transform.name)
            {
                GameObject.Find("Ship").GetComponent<HealthManager>().healthPoint--;
            }
        }
    }
}
