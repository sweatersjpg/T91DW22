using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithSerial : MonoBehaviour
{
    [SerializeField]
    float angleScale = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMessageArrived(string msg)
    {
        Debug.Log(msg);

        if (msg == "left")
        {
            transform.Rotate(new Vector3(0, 0, 1), 1 * angleScale);
        } else if(msg == "right")
        {
            transform.Rotate(new Vector3(0, 0, 1), -1 * angleScale);
        }
    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}
