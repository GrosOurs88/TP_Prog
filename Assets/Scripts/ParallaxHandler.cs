using UnityEngine;

public class ParallaxHandler : MonoBehaviour 
{
    public float speed = 0;
    public bool repeatable = false;
    public bool collidable = false;
    public float repeatDistance = 10;
    public float horizontalDistance;
    public float displaced;
    public float distanceOffScreen;

    void Awake()
    {
        //Computing bounds of the whole layer, then delete every unneaded component
        Bounds layerBounds = GetComponent<BoxCollider2D>().bounds;
        BoxCollider2D[] childs = GetComponentsInChildren<BoxCollider2D>();
        foreach (BoxCollider2D child in childs)
        {
            layerBounds.Encapsulate(child.bounds);
        }
        horizontalDistance = layerBounds.extents.x * 2;
        displaced = 0;

        //Clean unneeded object
        if (!collidable) // then we could clean the source a little
        {
            for (int i = childs.Length - 1; i >= 0; i--)  // /!\ elt0 is the LayerBounds
            {
                Destroy(childs[i]);
            }
        }

        // Get position of top right corner
        Vector3 topRightCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        distanceOffScreen = topRightCorner.x;
        repeatDistance = Mathf.Max(distanceOffScreen, repeatDistance - distanceOffScreen);
    }

	void Update () {
        if (displaced > horizontalDistance + repeatDistance)
        {
            if (repeatable)
            {
                Vector3 oldPos = transform.position;
                transform.position = new Vector3(distanceOffScreen + (horizontalDistance / 2.0f), oldPos.y, oldPos.z);
                displaced = -distanceOffScreen - (horizontalDistance / 2.0f);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            float effectiveSpeed = speed * Time.deltaTime;
            transform.Translate(-effectiveSpeed, 0.0f, 0.0f);
            displaced += effectiveSpeed;
        }    
	}
}
