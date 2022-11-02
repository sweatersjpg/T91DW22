using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmControl : MonoBehaviour
{
    [SerializeField]
    float targetAngle = 0;
    Rigidbody2D rb;

    [SerializeField]
    float torque = 1;

    float inputScale = 18;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Vector2 target = new Vector2(Mathf.Cos(Mathf.Deg2Rad * targetAngle), Mathf.Sin(Mathf.Deg2Rad * targetAngle));

        //float angle = Vector2.SignedAngle(transform.up, target);
        //Debug.Log(angle);

        //Debug.DrawRay(transform.position, target * 3);
        //Debug.DrawRay(transform.position, transform.up * 3);

        //if (angle < -3f)
        //{
        //    //rb.AddTorque(torque, ForceMode2D.Impulse);
        //    rb.MoveRotation(1);
        //} else if(angle > 3f)
        //{
        //    //rb.AddTorque(-torque, ForceMode2D.Impulse);
        //    rb.MoveRotation(-1);
        //}

        rb.MoveRotation(targetAngle);
    }

    public void ChangeAngle(float angle)
    {
        targetAngle = angle;
    }

    //void OnMessageArrived(string msg)
    //{
    //    Debug.Log(msg);

    //    if (msg == "left")
    //    {
    //        targetAngle += 1 * inputScale;
    //    }
    //    else if (msg == "right")
    //    {
    //        targetAngle -= 1 * inputScale;
    //    }

    //    if (targetAngle > 180) targetAngle -= 360;
    //    if (targetAngle < -180) targetAngle += 360;
    //}

    //void OnConnectionEvent(bool success)
    //{
    //    //Debug.Log(success ? "Device connected" : "Device disconnected");
    //}
}
