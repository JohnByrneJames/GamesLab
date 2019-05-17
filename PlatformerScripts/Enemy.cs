using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Transform leftCheck, rightCheck;     // Right Check position and left check position

    public float speed = 2f;                    // Variable that changes the speed at which an enemy moves
    public int points = 100;                     // Points rewarded for killing an enemy
    int groundLayer;

    RaycastHit2D leftGrounded, rightGrounded;
    
    Vector2 cDir;
    Rigidbody2D cRB;

    // Use this for initialization
    void Start ()
    {
        groundLayer = LayerMask.GetMask("Ground");

        cRB = GetComponent<Rigidbody2D>();
        cDir = new Vector2(speed, 0f);
    }

    private void FixedUpdate()
    {
        // Very reuseable piece of code
        leftGrounded = Physics2D.CircleCast(leftCheck.position, 0.1f, Vector2.down, 0f, groundLayer);   // Checks whether left part of enemy is in contact with platform
        rightGrounded = Physics2D.CircleCast(rightCheck.position, 0.1f, Vector2.down, 0f, groundLayer); // Checks whether right part of enemy is in contact with platform

        if (!leftGrounded || !rightGrounded) // If left grounded or right ground is false
        {
            // Multiplying vectors Here the first number becomes the direction it changes to and the second remains 0 as it doesnt need to go up or down
            cDir = Vector2.Scale(cDir, new Vector2(-1f, 0f));    // Used to change the direction | A positive times a negative becomes a negative and a negative times a negative is a positive
        }
        cRB.velocity = cDir;
    }

    public void BeenHit()
    {
        // Find a game object with the tag "Player" then get the component from the info script and send through the amount of points this enemy is worth
        GameObject.FindGameObjectWithTag("Player").GetComponent<Info>().UpdateScore(points);
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	//void Update () {
	//	
	//}
}
