using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public bool isColliding;
    public float countdown = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding == true)
        {
            countdown -= Time.deltaTime;
            if (countdown < 0)
            {
                countdown = 0;
            }

            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Balancer")
        {
            print("Player Entered");
            isColliding = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (isColliding == true)
        {
            if (countdown <= 0)
            {
                SceneManager.LoadScene("EndScreen");
            }

        }
       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Balancer")
        {
            print("Player Exited");
            isColliding = false;
            countdown = 3.0f;
        }
    }
}
