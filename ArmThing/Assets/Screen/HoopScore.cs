using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopScore : MonoBehaviour
{
    [SerializeField]
    GameObject screen;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.position.y < transform.position.y)
        {
            screen.SendMessage("changeScore");
        }
    }
}
