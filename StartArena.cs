using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartArena : MonoBehaviour {

    public GameObject[] enemies;
    public GameObject[] hiddenGround;

    Renderer enemyRend;


    void Start ()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyRend = enemies[i].GetComponent<Renderer>();
            enemyRend.enabled = false;
        }
    }

    void Update ()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null)
            {

                Destroy(hiddenGround[i]);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) // Collider variable | something has collided with me, write that object as collision to tell you what it is
    {

        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Info>().UpdatecheckPoint();

            for (int i = 0; i < enemies.Length; i++)
            {
                enemyRend = enemies[i].GetComponent<Renderer>();
                enemyRend.enabled = true;
            }

        }
    }
}
