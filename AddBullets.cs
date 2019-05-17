﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBullets : MonoBehaviour {

    public int bulletAmount = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Info>().UpdateBullets(bulletAmount);
            Destroy(gameObject);
        }
    }
}
