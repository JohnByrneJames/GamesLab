using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instadeath : MonoBehaviour {

    //Set the collider to be a trigger more than a collider, so when a collision happens is going to trigger this script
	private void OnTriggerEnter2D(Collider2D collision) // Collider variable | something has collided with me, write that object as collision to tell you what it is
    {
        /* If an object collides or triggers
         * and is tagged player then find that collision object
         * access the game component "Info" and trigger the function
         * DeathReset.
         * */

        if(collision.tag == "Player")                                   
        {
            collision.gameObject.GetComponent<Info>().DeathReset();

        }
    }
}
