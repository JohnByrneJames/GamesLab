using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public Vector2 dir; // Direction of bullet

    Rigidbody2D rb;     // rigidbody bullet

    public bool harmPlayer, harmEnemy;

    // Use this for initialization
    void Start ()
    {
       
        rb = GetComponent<Rigidbody2D>();   // Gets the Rigidbody for the bullet
        Destroy(gameObject, 5f);            // Destroys the bullet after 5 seconds, so loads of bullets don't get fired off and take up memory
	}
	
	// Update is called once per frame
	private void FixedUpdate ()
    {
        rb.velocity = dir;                  // Whatever direction this velocity is in, thats where the bullet will travel from

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && harmEnemy)
        {
            collision.gameObject.GetComponent<Enemy>().BeenHit();   // Uses the been hit function from the enemy script which destroys gameobjects on collision
            Destroy(gameObject);                                    // Also destroy bullet
        }
        else if (collision.gameObject.tag == "Player" && harmPlayer)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Info>().DeathReset(); // Find in the scene a object tagged with player, get its component and access death reset script to reset position
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
