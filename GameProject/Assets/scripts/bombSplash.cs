using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombSplash : MonoBehaviour {

    public float splashRadius = 1f;
    private Rigidbody2D bombz;
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroying player, destroying itself
        if (collision.gameObject.name == "player")
        {
            Destroy(collision.gameObject);
            Destroy(bombz.gameObject);
        }
    }
    // Use this for initialization
    void Start () {
         bombz = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    //Search for object in radius, destoroyes them.
   
}
