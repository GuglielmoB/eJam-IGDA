using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public bool isColliding;
    public float countdown = 3.0f;

    [SerializeField] Transform supporterTextObject;
    supporterText supporterTextClass;

    // A list of times that the support character will say things. These timings should be in descending order for 
    //     the sake of neatness and to ensure things don't break.
    private List<float> messageTimings = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        supporterTextClass = supporterTextObject.GetComponent<supporterText>();

        // ADD ALL MESSAGE TIMES HERE, DESCENDING ORDER
        messageTimings.Add(2.0f);
        messageTimings.Add(-100.0f);
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

            // Determines if a message should be sent
            if (countdown <= messageTimings[0])
            {

                print("called at Goal.cs");

                // Call the support character text box to say a line
                supporterTextClass.StartCoroutine(supporterTextClass.SayLine(messageTimings[0]));

                // remove that item from the list
                messageTimings.RemoveAt(0);
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
