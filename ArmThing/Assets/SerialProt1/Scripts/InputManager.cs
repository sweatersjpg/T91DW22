using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    float[] targetAngles;

    [SerializeField]
    ArmControl[] listeners;

    [SerializeField]
    float inputScale = 18;

    int nInputs;

    private void Start()
    {
        targetAngles = new float[listeners.Length];
        for (int i = 0; i < targetAngles.Length; i++) targetAngles[i] = 0;

        nInputs = listeners.Length;
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
            targetAngles[0] += 1;
            Debug.Log("right");

        }
        //left
        if (Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            targetAngles[0] -= 1; 
            Debug.Log("left");
        }

        listeners[0].SendMessage("ChangeAngle", targetAngles[0]);

        if (targetAngles[1] != null) 
        { 
            //up
            if (Input.GetAxisRaw("Vertical") > 0.1f)
            {
                targetAngles[1] += 1;
                Debug.Log("right");

            }
            //down
            if (Input.GetAxisRaw("Vertical") < -0.1f)
            {
                targetAngles[1] -= 1;
                Debug.Log("left");
            }

            listeners[1].SendMessage("ChangeAngle", targetAngles[1]);
        }


    }

    void OnMessageArrived(string msg)
    {
        //Debug.Log(msg);

        string[] input = msg.Split("-");
        int index = int.Parse(input[0]);
        string dir = input[1];

        if (dir == "left")
        {
            targetAngles[index] += 1 * inputScale;
        }
        else if (dir == "right")
        {
            targetAngles[index] -= 1 * inputScale;
        }

        if (targetAngles[index] > 180) targetAngles[index] -= 360;
        if (targetAngles[index] < -180) targetAngles[index] += 360;

        if (listeners[index] != null) listeners[index].SendMessage("ChangeAngle", targetAngles[index]);
    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}
