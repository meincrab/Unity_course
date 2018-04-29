using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shooting : MonoBehaviour {

    public Transform torpedoSpawn;
    private float nextFire;
    public float torpedoSpeed;
    public float fireLimiter;
    public GameObject torpedo;
    public float destroyAfter;
    Vector3 velocity = new Vector3(0.0f, 1.0f, 0.0f);
    public Quaternion rotation = Quaternion.identity;
    private int enemiesLeft;
    public Text enemiesText;
    public Text victory;



    // Use this for initialization
    void Start () {
        enemiesLeft = 4;
        countEnemies();
        victory.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireLimiter;
            ShootTheTorpedo();
            countEnemies();
        }
    }

    public void ShootTheTorpedo()
    {
        //Torpedo should be shooted at the same direction as player movement
        //Meh... Didnt work out, just killed the time, lets try another variant.
        //Finally got solution to work by dividing value on 2.5f
        GameObject player = GameObject.Find("player");
        boatMove boatMove = player.GetComponent<boatMove>();
        float torpedoDirection = boatMove.zRotation;


        //Here we go , let's just try to get euler angles. 
        GameObject torpedoCreated = Instantiate(torpedo, torpedoSpawn.position, torpedoSpawn.rotation);
        //Divided by 3.5f to make torpedo initiate angle, match submarine nose angle.
        torpedoCreated.GetComponent<Rigidbody2D>().velocity = new Vector2(torpedoSpeed, torpedoDirection/3.5f);
        Destroy(torpedoCreated, destroyAfter);




        



        //Both Make same thing, just was trying to understand better how this works, not needed
        /*var torpedo = (GameObject)Instantiate(
             torpedo,
             torpedoSpawn.position,
             torpedoSpawn.rotation);*/

        //Destroy(torpedo, 10.0f); 
        //Maybe later here will be 2 torpedoes

        /*
        Rigidbody2D torpedo_body;
        torpedo_body = torpedo.GetComponent<Rigidbody2D>();
        torpedo_body.AddForce(transform.forward * torpedoSpeed);
        Destroy(torpedo_body, 15.0f);
         */


    }

   

    void countEnemies()
    {
        enemiesText.text = "Enemies left " + enemiesLeft.ToString();
    }
    public void enemyKilled()
    {
        enemiesLeft -= 1;
        enemiesText.text = "Enemies left " + enemiesLeft.ToString();
        if (enemiesLeft == 0)
        {
            victory.text = "VICTORY!!!";
        }
    }


}
