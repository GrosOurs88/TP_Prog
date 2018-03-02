using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject blastPrefab;
    public float blastingRate = 0.25f;
    public float blastSpeed;
    private float blastCooldown;

    void Start()
    {
        blastCooldown = 0f;
    }

    void Update()
    {
        if (blastCooldown > 0)
        {
            blastCooldown -= Time.deltaTime;
        }
    }
    
    public void Attack(bool IsEnemy)
    {
        if (CanAttack)
        {
            blastCooldown = blastingRate;
            Transform blastTransform = Instantiate(blastPrefab, transform.position, transform.rotation).transform;
            blastTransform.position = transform.position;
            if (transform.parent)
            {
                blastTransform.SetParent(transform.parent);
            }
            BlastScript blast = blastTransform.gameObject.GetComponent<BlastScript>();
            if (blast != null)
            {
                blast.isEnemyBlast = IsEnemy;
            }

            // On saisit la direction pour le mouvement
            AutoMoveAndRotate move = blastTransform.gameObject.GetComponent<AutoMoveAndRotate>();
            if (move != null)
            {
                move.moveUnitsPerSecond.value = Vector3.right * blastSpeed;
            }
        }
    }

    public bool CanAttack
    {
        get
        {
            return blastCooldown <= 0f;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + 0.3f * blastSpeed * (transform.rotation * Vector3.right));
    }
}