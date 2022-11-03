using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class ArmControl : MonoBehaviour
{
    float targetAngle = 0;
    float currentAngle = 0;

    public bool takeParentsRotation = false;

    Rigidbody2D rb;
    [SerializeField]
    bool hasClaw = false;
    AnchoredJoint2D anchor;

    [SerializeField]
    Rigidbody2D parent;

    //[SerializeField]
    //float torque = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(hasClaw) anchor = GetComponent<AnchoredJoint2D>();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        float angle = (targetAngle + parent.rotation);
        if (!takeParentsRotation) angle = targetAngle;

        Vector2 ray = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));

        Debug.DrawRay(transform.position, ray * 3);

        currentAngle += Mathf.DeltaAngle(currentAngle, angle) / 8;

        //transform.localEulerAngles = new Vector3(0, 0, currentAngle);

        rb.MoveRotation(currentAngle);
    }

    public void ChangeAngle(float deltaAngle)
    {
        targetAngle += deltaAngle;
        if (targetAngle > 180) targetAngle -= 360;
        if (targetAngle < -180) targetAngle += 360;
    }
}
