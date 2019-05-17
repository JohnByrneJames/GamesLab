using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winscript : MonoBehaviour {

    public GameObject house;
    public GameObject messageRemover, messageRemover2;

    Renderer messageRend;

    void Start()
    {
        messageRend = messageRemover.GetComponent<Renderer>();
        messageRend.enabled = false;

        messageRend = messageRemover2.GetComponent<Renderer>();
        messageRend.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) // Collider variable | something has collided with me, write that object as collision to tell you what it is
    {

        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Info>().Victory();

        }
    }
}
