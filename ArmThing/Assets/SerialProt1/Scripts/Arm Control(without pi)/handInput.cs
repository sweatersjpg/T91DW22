using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class handInput : MonoBehaviour
{
    public KeyCode buttonPress;

    public SpriteRenderer handSprite;
    public GameObject handPivot;

    [SerializeField]
    Sprite openHand, closedHand;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(buttonPress))
        {
            //handObject.color = new Color(1, 0, 0, 1);
            handSprite.sprite = closedHand;

            if(!hasCollided)
            {
                Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 0.5f, LayerMask.GetMask("Default"));

                GameObject bestHit = null;
                foreach (Collider2D hit in hits)
                {
                    if (hit.transform.GetComponent<Rigidbody2D>() != null) bestHit = hit.gameObject;
                    else if (bestHit == null) bestHit = hit.gameObject;
                }

                if (bestHit != null)
                {
                    hasCollided = true;

                    AddPivot(bestHit);
                }
            }

        }
        else
        {
            handSprite.sprite = openHand;
            hasCollided = false;
            Destroy(handPivot.GetComponent<FixedJoint2D>());
            handPivot.GetComponent<HingeJoint2D>().useMotor = false;
        }
    }

    bool hasCollided = false;

    private void AddPivot(GameObject collision)
    {

        Rigidbody2D rb = collision.transform.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            FixedJoint2D fj = handPivot.transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
            fj.connectedBody = rb;
            handPivot.GetComponent<HingeJoint2D>().useMotor = true;
        }
        else
        {
            FixedJoint2D fj = handPivot.transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
        }


    }//end of OnCollisionEnter2D
}
