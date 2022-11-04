using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //float[] targetAngles;

    [SerializeField]
    GameObject[] listeners;

    [SerializeField]
    float inputScale = 18;

    //int nInputs;

    private void Start()
    {

    }

    /// <summary>
    /// rotation should work with manual/keyboard presses(currently just 1 player)
    /// Comment out once arduino is in place
    /// </summary>
    void Update()
    {

        //right
        if (Input.GetAxisRaw("Horizontal") > 0.1f)
        {
            //targetAngles[0] += 1;
            //Debug.Log("right");
            listeners[0].SendMessage("ChangeAngle", 1);
        }
        //left
        if (Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            //targetAngles[0] -= 1;
            //Debug.Log("left");
            listeners[0].SendMessage("ChangeAngle", -1);
        }

        //listeners[0].SendMessage("ChangeAngle", targetAngles[0]);

        if (listeners[1] != null)
        {
            //up
            if (Input.GetAxisRaw("Vertical") > 0.1f)
            {
                //targetAngles[1] += 1;
                //Debug.Log("right");
                listeners[1].SendMessage("ChangeAngle", 1);
            }
            //down
            if (Input.GetAxisRaw("Vertical") < -0.1f)
            {
                //targetAngles[1] -= 1;
                //Debug.Log("left");
                listeners[1].SendMessage("ChangeAngle", -1);
            }

            //listeners[1].SendMessage("ChangeAngle", targetAngles[1]);
        }


    }

    void OnMessageArrived(string msg)
    {
        //Debug.Log(msg);

        string[] input = msg.Split("-");
        int index = int.Parse(input[0]);
        string dir = input[1];

        if (dir == "l")
        {
            listeners[index].SendMessage("ChangeAngle", inputScale);
        }
        else if (dir == "r")
        {
            listeners[index].SendMessage("ChangeAngle", -inputScale);
        }
        else if (dir == "b")
        {
            listeners[index].SendMessage("ButtonPressed");
        }

    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}
