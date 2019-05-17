using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour {

    Vector2 cDir;                               // Vector 2 - Essentially 2 floats [2D] character direction
    Rigidbody2D cRB;                            // RigidBody of the 2D character [Characters Rigidbody]
    RaycastHit2D grounded, enemyDestroy;         // Can contain a lot of information | Can be used as a boolean | If something has been hit it becomes true

    int groundLayer, enemyLayer, messageLayer;                // Unity Stores a number to identify the layer, find layer called ground eliminate everything else | Message layer near house
   
    public Transform groundCheck;               // Draw the information of whats happening from a point in space set to the transform - drag the object in
    public Transform bulletSpawn;               // The spawn point of the bullet
    public GameObject bulletPreFab;             // The bullets pre made object
    public GameObject rifle;                    // Gun the sprite is holding
    public GameObject border;                   // Border - stop players from continuous falling

    public AudioClip gunShot, gunEmpty;

    public float speed = 4f;                    // Speed of the player [Interchangable]
    public float jumpForce = 550f;
    public float bulletSpeed = 5f;              // Speed of bullet for player

    bool jump = false;                          // Detects if jumping [True = Is jumping | false = On ground]
    bool facingRight = true;       

    Info inf;                                   // instead of writing GetComponent<Info> This variable holds the instance of the script Info and all its functions are available much easier

    Renderer borderRend;                        // Rendered border
    Renderer rifleRend;                         // Rendered rifle
    AudioSource source;
    
    // Use this for initialization
    void Start ()
    {
        source = GetComponent<AudioSource>();

        groundLayer = LayerMask.GetMask("Ground"); // Does the calculation for us - Returned 256 when printed the layer
        enemyLayer = LayerMask.GetMask("Enemy");
        messageLayer = LayerMask.GetMask("Message");

        inf = GetComponent<Info>();             // Assigns the variable inf to a getComponent from the Info script
        cRB = GetComponent<Rigidbody2D>();      // Assigns the cRB variable access to the GetComponent command to the Rigidbody

        borderRend = border.GetComponent<Renderer>();
        borderRend.enabled = false;

        rifleRend = rifle.GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        cDir.x = Input.GetAxis("Horizontal") * speed; // Gives the movement of a default speed in direction x using inbuild command then adds own speed variable

        if (cDir.x < 0f && facingRight) // If trying to move right and facing right then do this
        {
            facingRight = false;
            transform.localScale = new Vector3(0.4141661f, 0.3979564f, 1f);
        }
        else if (cDir.x > 0f && !facingRight) // If trying to move right but not facing right do this
        {
            facingRight = true;
            transform.localScale = new Vector3(-0.4141661f, 0.3979564f, 1f);
        }

        if (Input.GetButtonDown("Jump"))    // When the button is down for Jump (Premade)
        {
            jump = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            source.PlayOneShot(gunEmpty, 1f);

            if (inf.bulletsLeft > 0)        //Gets component from info Script and retrieves number of bullets left 
            {
                source.PlayOneShot(gunShot, 1f);

                inf.UpdateBullets(-1);      // This will decrement the value stored in bulletsLeft (meaning the number of bullets the player has will go down by 1 each time)
                                            // Creating a new variable for a new bullet, Instantiate (Creates a new instance of something)
                                            // First it asks what is the original object to clone, then it asks where to place clone of object, Quaternion is telling the rotation | identity is teh standard 0 0 0
                GameObject newBullet = Instantiate(bulletPreFab, bulletSpawn.position, Quaternion.identity);
                

                if (facingRight)            // if the player is facing right then fire the bullet in the opposite direction
                {
                    newBullet.GetComponent<Bullet>().dir = new Vector2(bulletSpeed, 0f);
                }
                else                        // if the player is facing left then fire the bullet in the that direction
                {
                    newBullet.GetComponent<Bullet>().dir = new Vector2(bulletSpeed * -1, 0f);
                }
            }
        }

        if (inf.bulletsLeft <= 0)
        {
            rifleRend.enabled = false;
        }
        else
        {
            rifleRend.enabled = true;
        }
    }

    // Update for Physics objects (RigidBody)
    private void FixedUpdate ()
    {
        // Circle cast starts a circle at this point (circle is 0.2 units on radius), Vector2.down will offset the sphere down by amount (0 units - Center), Only check for objects in the ground layer  
        grounded = Physics2D.CircleCast(groundCheck.position, 0.1f, Vector2.down, 0f, groundLayer); // Collided with it = true | Not collided with it = False

        enemyDestroy = Physics2D.CircleCast(groundCheck.position, 0.1f, Vector2.down, 0f, enemyLayer);

        if (jump)
        {
            if (grounded)
            {
                cRB.AddForce(new Vector2(0f, jumpForce)); // When jump and grounded then apply force 400f on the y axis (Up) 
            }
        }

        if (enemyDestroy)
        {
            cRB.AddForce(new Vector2(0f, jumpForce));     // When destroying an enemy you bounce off a little
            GameObject thisEnemy = enemyDestroy.collider.gameObject;    // Creates a local variable to store the collision
            thisEnemy.GetComponent<Enemy>().BeenHit();                  // Uses the public function from the Enemy script to destroy the enemy
        }
        jump = false;                           // If not grounded but has jumped then set Jump to false.

        
        cDir.y = cRB.velocity.y;                // Stops floating down, will allow player to fall like with gravity
        cRB.velocity = cDir;                    // The velocity of the Rigidbody is going to be a 2-dimensional vector an x and a y
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, 0.1f);
    }

    private void OnCollisionEnter2D(Collision2D collision) // collision returns information about the object that has been collided with
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GetComponent<Info>().DeathReset();
        }
    }

}
