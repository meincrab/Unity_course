using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killingEnemy : MonoBehaviour {
    //Destorying both, enemy and torpedo
    public Rigidbody2D torpedz;
    //Out of the water height limiter
    public float maxHeight = 2.1f;

    void Start()
    {

        torpedz = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        restrictTressPass();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "enemy")
        {
            Destroy(collision.gameObject);
            Destroy(torpedz.gameObject);
        }

        if (collision.gameObject.name == "enemy1")
        {
            Destroy(collision.gameObject);
            Destroy(torpedz.gameObject);
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
