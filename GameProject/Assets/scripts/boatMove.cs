using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatMove : MonoBehaviour {

    public float speed;           

    public Rigidbody2D body2d;

    public float zRotation = 0;          //Submarine rotation angle on diving;

    public float maxSpeed = 25f;        //Limitating going up speed

    private float gravityTemp = 0f;
    private float gravityBase = 0.025f;
    //delay before drawning
    public float drowningDelay = 0.5f;

    private float maxHeight = 2.1f;

    void Start()
    {
     
        body2d = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        //Manipulating Gravity
        gravityOnOff();
        //Rotating
        RotateTheBoat();
        //HeightLimiter
        restrictTressPass();

    }

    void FixedUpdate()
    {
        
        //Moving

        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        body2d.AddForce(movement * speed);



    }

   
    void RotateTheBoat()
    {
        
        //Changing angle of boat by modifying Z value here.
        if (Input.GetAxis("Vertical") < 0 &&  Input.GetAxis("Horizontal") > 0  || Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") < 0) 
        {
            if (zRotation >= -20)
            {
                zRotation -= 0.5f;
                transform.eulerAngles = new Vector3(0, 0, zRotation);
            }

        }
        //Changing angle of boat by modifying Z value There
        if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") > 0  || Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") < 0)
        {

            if (zRotation <= 15)
            {
                zRotation += 0.25f;
                transform.eulerAngles = new Vector3(0, 0, zRotation);
            }
           
           
        }

        else //if (Input.GetAxis("Vertical") == 0)
        {
            if (zRotation < 0 )
            {
                zRotation += 0.3f;
                transform.eulerAngles = new Vector3(0, 0, zRotation);
            }

            if (zRotation > 0)
            {
                zRotation -= 0.3f;
                transform.eulerAngles = new Vector3(0, 0, zRotation);
            }
        }
    }
   
    //Limiting the height where player can go, simulating out of the water.Can't add invisible block cause I will have enemy up there on the same Layer
    void restrictTressPass()
    {

        Vector2 currentPosition = transform.position;
        
        if (currentPosition.y > maxHeight)
        {
            currentPosition.y = maxHeight;
            transform.position = currentPosition;
        }

    }
    //Attempt to make submarine float for few second, before starting to drown... Didnt work out
    void gravityOnOff()
    {
        if (Input.anyKeyDown == false)
        {
            body2d.gravityScale = gravityTemp;
            if (Time.time > drowningDelay)
            {
                body2d.gravityScale = gravityBase;
            }
        }
    }
}


