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

        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Input.mousePosition;
            Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));
            if (hitCollider != null && hitCollider.name == collider.name)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(pos);
                moveObject(mousePos);
            }
        }

        // If the object's y is lower than the minimum allowed
        if (trans.position.y <= balanceMinY)
        {
            print("failed");
        }

        // Lower the object's y position
        trans.position = new Vector3(trans.position.x, trans.position.y - 0.005f, trans.position.z);
    }


    // NOTE: this code doesn't really give a smooth push, but it's workable for now so it'll have to do
    private void moveObject(Vector3 mousePosition)
    {
        // get the difference in x and y between the object centre and the mouse
        float x_diff = trans.position.x - mousePosition.x;
        float y_diff = trans.position.y - mousePosition.y;

        // flip that to get the difference between the object's edge and the mouse
        //float x_from_edge = collider.radius - x_diff;
        //float y_from_edge = collider.radius - y_diff;

        print("x movement is " + x_diff);
        print("y movement is " + y_diff);

        // push the object
        trans.position = new Vector3(trans.position.x + x_diff, trans.position.y + y_diff, trans.position.z);
    }
}
