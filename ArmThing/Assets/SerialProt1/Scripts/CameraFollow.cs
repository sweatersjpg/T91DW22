using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    Transform target;

    Vector3 startPos, offset;

    [SerializeField]
    bool lockX, lockY, lockZ;

    [SerializeField]
    float paralax, easing;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 pos = (target.position)/paralax + offset;

        transform.position += (pos - transform.position) / easing;
        transform.position = new Vector3(
            !lockX ? transform.position.x : startPos.x,
            !lockY ? transform.position.y : startPos.y,
            !lockZ ? transform.position.z : startPos.z);

    }
}
