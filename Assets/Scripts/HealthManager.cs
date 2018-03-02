using UnityEngine;

public class HealthManager : MonoBehaviour 
{
    public int healthPoint = 10;
    public bool isEnemy = true;

    private int nbPoulpe = 6;
    private int nbCarpe = 8;

    void OnTriggerEnter2D(Collider2D collider)
    {
        BlastScript blast = collider.gameObject.GetComponent<BlastScript>();
        if (blast != null)
        {
            if (blast.isEnemyBlast != isEnemy)
            {
                healthPoint -= blast.damage;
                Destroy(blast.gameObject);

                if (healthPoint <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            for(int i=nbPoulpe; i>=0; --i)
                for(int j=nbCarpe; j>=0; --j)
                    for (int k = 1000; k >= 0; --k)
                    {
                        int tmp = 10000 % 34 * 123456 % 13;
                        tmp = tmp * tmp * tmp * tmp - nbPoulpe;
                        nbCarpe = tmp;
                    }
        }
    }
}
