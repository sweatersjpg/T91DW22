using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class ArmControlTransform : MonoBehaviour
{
    [SerializeField]
    float targetAngle = 0;
    float currentAngle = 0;

    [SerializeField]
    bool takeParentsRotation = false;

    //[SerializeField]
    Transform parent;

    [SerializeField]
    Rigidbody2D rb;

    //[SerializeField]
    //float torque = 1;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        //hinge = GetComponent<HingeJoint2D>();

        parent = transform.parent;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float angle = (targetAngle + transform.parent.localEulerAngles.z);
        if (!takeParentsRotation) angle = targetAngle;

        //Vector2 ray = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));
        //Debug.DrawRay(transform.position, ray * 3);

        currentAngle += Mathf.DeltaAngle(currentAngle, angle) / 8;

        transform.localEulerAngles = new Vector3(0, 0, currentAngle);

    }

    public void ChangeAngle(float deltaAngle)
    {
        targetAngle += deltaAngle;
        if (targetAngle > 180) targetAngle -= 360;
        if (targetAngle < -180) targetAngle += 360;
    }

}
