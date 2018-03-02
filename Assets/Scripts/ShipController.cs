using UnityEngine;

public class ShipController : MonoBehaviour {

    public Vector2 speed = new Vector2(10, 15);
    private Vector2 movement;
    private Rigidbody2D rigidbody2D;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Gathering controller information (keyboard and pad)
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        bool blast = Input.GetButtonDown("Fire1");

        //Calcul movement
        movement = new Vector2(speed.x * inputX, speed.y * inputY);

        //Blast
        if (blast)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                weapon.Attack(false); //false: player is not an enemy
            }
        }
    }

    void FixedUpdate()  // appele a intervalle fix
    {
        rigidbody2D.velocity = movement;
    }

    void OnDestroy()
    {
        Debug.Log("Lost");
    }
}
