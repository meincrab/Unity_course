using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {
    
    private Rigidbody2D enemyBody;
    //private float moveHorizontal;
    public float speed;
    public int basic = 0;
    // Use this for initialization
    private bool noCollision = true;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "player")
        {
            //Not the best idea to use Euler... hard to get them turn each time.
            // transform.localRotation = Quaternion.Euler(0, basic+180, 0);
            //Have to remember, how to properly use vectors.
            transform.Rotate(Vector3.up * 180);
            noCollision = false;
        }
    }

    void Start () {
		enemyBody = GetComponent<Rigidbody2D>();
        givingForceToBody();
    }

    void Update()
    {
       if (noCollision == false)
        {
            //-2 Hours of life, cause didnt now how "LocalRotation" works...
            //Tried to fix values, as result = ships didnt move after collision, 10/10 expirience XD
           // speed *= -1;
            givingForceToBody();
            noCollision = true;
        }   
    }
    // Update is called once per frame

    void givingForceToBody()
    {
        enemyBody.AddForce(transform.right * speed);
    }
}
