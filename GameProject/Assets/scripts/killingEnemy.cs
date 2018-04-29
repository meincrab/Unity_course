using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class killingEnemy : MonoBehaviour {
    //Destorying both, enemy and torpedo
    public Rigidbody2D torpedz;
    //Out of the water height limiter
    public float maxHeight = 2.1f;
    private shooting shootingscript;
    public float maxTorpedoSpeed;
    void Start()
    { 
        torpedz = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        restrictTressPass();
    }

    private void FixedUpdate()
    {
        if(torpedz.velocity.magnitude > maxTorpedoSpeed)
        {
            torpedz.velocity = torpedz.velocity.normalized * maxTorpedoSpeed;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "enemy" || collision.gameObject.name == "enemy1" || collision.gameObject.name == "enemy2" || collision.gameObject.name == "enemy3")
        {

            
            Destroy(collision.gameObject);
            Destroy(torpedz.gameObject);
            GameObject.Find("player").GetComponent<shooting>().enemyKilled();

        }


    }
    //Torpedo Flight Heigh Limiter
    void restrictTressPass()
    {

        Vector2 currentPosition = transform.position;

        if (currentPosition.y > maxHeight)
        {
            currentPosition.y = maxHeight;
            transform.position = currentPosition;
        }

    }

   
}
