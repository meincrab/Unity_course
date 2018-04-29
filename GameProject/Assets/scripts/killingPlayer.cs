using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class killingPlayer : MonoBehaviour {

    public Transform bombSpawn;
    public GameObject bomb;
    //By X axis
    public float bombSpeed;


    private float nextDrop;
    public float selfDestruction;


    public float dropReloading = 10f;
    private Transform uboat = null;
    
    //Waiting for player to trigger circle collider
    //1.5 hours to understand what I forgot to use 2D trigger with 2D collider... Learning thing the hard way :D


    void OnTriggerEnter2D(Collider2D detector)
    {
        if (detector.name == "player")
        {
            uboat = detector.transform;
           
        }
    }

    void OnTriggerExit2D(Collider2D detector)
    {
        if (detector.name == "player")
        {
            uboat = null;
            
        }
    }
    //Destroing player on collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            Destroy(collision.gameObject);
            //Pause before reloading a level
            StartCoroutine(Delay());     
        }
    }

    void Start()
        {
        }

        void Update()
        {
        if (uboat != null)
        {
            kaboom();
        }
    }
    //Timer + bomb dropping
    void kaboom()
    {
        if (Time.time > nextDrop)
        {
            nextDrop = Time.time + dropReloading;
            dropTheBomb();
        }
    }

    void dropTheBomb()
        {
        GameObject newBomb = Instantiate(bomb, bombSpawn.position, bombSpawn.rotation);
        newBomb.GetComponent<Rigidbody2D>().velocity = new Vector2(bombSpeed, 0);
        Destroy(newBomb, selfDestruction);

    }

    IEnumerator Delay()
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(2);
        Debug.Log("test");
        print(Time.time);
        SceneManager.LoadScene("mainScene");
    }

}
