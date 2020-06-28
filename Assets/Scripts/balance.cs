using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class balance : MonoBehaviour
{
    // The distance from the target object that this object can go before the character loses balance
    public float failDistance = 2.0f;

    // the target object
    [SerializeField] Transform targetObject;

    private Transform trans;
    private CircleCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        // Get the transform of the object
        trans = GetComponent<Transform>();
        collider = GetComponent<CircleCollider2D>();

        trans.position = new Vector3(targetObject.position.x, targetObject.position.y - 0.001f, targetObject.position.z);

        
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

        // if the distance between this object and the target > the limit, we fail
        if (Vector3.Distance(trans.position, targetObject.position) > failDistance)
        {
            print("Balance lost");
        }

        // move away from the target
        Vector3 dir = trans.position - targetObject.position;
        dir.Normalize();
        trans.Translate(dir * 0.5f * Time.deltaTime);
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

        Vector3 movement = new Vector3(x_diff, y_diff, 0f);

        // push the object
        // trans.position = new Vector3(trans.position.x + x_diff, trans.position.y + y_diff, trans.position.z);
        trans.Translate(movement * 10 * Time.deltaTime);
    }
}
