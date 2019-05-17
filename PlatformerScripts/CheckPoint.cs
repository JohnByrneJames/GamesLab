using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision) // Collider variable | something has collided with me, write that object as collision to tell you what it is
    {

        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Info>().UpdatecheckPoint();

        }
    }
}
