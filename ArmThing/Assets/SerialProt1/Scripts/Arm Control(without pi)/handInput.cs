using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handInput : MonoBehaviour
{
    private bool hold;

    public KeyCode buttonPress;


    public SpriteRenderer handObject;    
    public GameObject handPivot;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(buttonPress))
        {
            handObject.color = new Color(1,0,0,1);
            hold = true;
        }
        else
        {
            handObject.color = new Color(1, 1, 1, 1);
            hold = false;
            hasCollided = false;
            Destroy(handPivot.GetComponent<FixedJoint2D>());
        }

    }//end of Update

    bool hasCollided = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hold) 
        {
            //make sure that the player does not grab its own pivot and gets stuck
            if (!hasCollided)
            {
                hasCollided = true;

                Rigidbody2D rb = collision.transform.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    FixedJoint2D fj = handPivot.transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
                    fj.connectedBody = rb;

                }
                else
                {
                    FixedJoint2D fj = handPivot.transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
                }

            }

        }


    }//end of OnCollisionEnter2D
}
