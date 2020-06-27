using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class balance : MonoBehaviour
{
    // The minimum threshold of the balance object's y for it to be in balance
    public float balanceMinY = -5.0f;

    private float startingY;

    private Transform trans;
    private CircleCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        // Get the transform of the object
        trans = GetComponent<Transform>();
        collider = GetComponent<CircleCollider2D>();

        startingY = trans.position.y;

        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));
            if (hitCollider != null && hitCollider.name == collider.name)
            {
                trans.position = new Vector3(trans.position.x, startingY, trans.position.z);
            }
        }

        // If the object's y is lower than the minimum allowed
        if (trans.position.y <= balanceMinY)
        {
            print("failed");
        }

        // Lower the object's y position
        trans.position = new Vector3(trans.position.x, trans.position.y - 0.01f, trans.position.z);
    }
}
