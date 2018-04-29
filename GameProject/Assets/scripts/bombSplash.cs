using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            //For some reason, same piece of code like in the killingPlayer, doesn't work.
            StartCoroutine(Delay());
            SceneManager.LoadScene("mainScene");
        }
    }
    // Use this for initialization
    void Start () {
         bombz = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    //Delay before restarting the level
    IEnumerator Delay()
    {
        print(Time.time);
        //This is called...
        Debug.Log("hell world");
        //Black Hole -____-
        yield return new WaitForSecondsRealtime(2);
        //this isn't
        Debug.Log("test");
        print(Time.time);
        SceneManager.LoadScene("mainScene");


    }

}
