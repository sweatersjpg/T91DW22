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
