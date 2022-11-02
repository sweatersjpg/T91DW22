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
