using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedEnemy : MonoBehaviour {

    public Transform bulletSpawn;
    public GameObject bulletPreFab;

    Rigidbody2D cRB;
    Vector2 cDir;

    public float timeTillShot = 5f;
    public float bulletSpeed = 10f;
    public float jumpForce = 300f;
    //float countDown;


    // Use this for initialization
    void Start () {

        cRB = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        timeTillShot -= Time.deltaTime;
        
        if (timeTillShot > 2.5 && timeTillShot < 5)
        {
            
        }
        else if (timeTillShot > 0 && timeTillShot < 2.4)
        {
           
        }
        else
        {
            cRB.AddForce(new Vector2(0f, jumpForce));
            timeTillShot = 5f;
            
            GameObject newBullet = Instantiate(bulletPreFab, bulletSpawn.position, Quaternion.identity);
        }

        

        

    }
}
