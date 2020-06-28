using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class supporterText : MonoBehaviour {
    
    private Dictionary<float, string> messages;
    private Text textField;

    float time_up;

    private void Start() 
    {
        messages = new Dictionary<float, string>
        {
            {2.0f, "test message"},
        };

        textField = GetComponent<Text>();

        gameObject.SetActive(false);
    }

    public void SayLine(float timeOfLine)
    {

        print("called at supporterText.cs");
        // Get the line that needs to be said
        string lineToSay = messages[timeOfLine];

        print(lineToSay);

        textField.text = lineToSay;

        gameObject.SetActive(true);

        time_up = 3.0f;

        while (time_up > 0.0f)
        {
            time_up -= Time.deltaTime;
        }

        gameObject.SetActive(false);


    }
}