using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ball : MonoBehaviour {

    
    
    public Rigidbody2D rb;
    public Rigidbody2D hook;
    public float releaseTime = .15f;
    public float maxDistance = 2f;
    public GameObject nextBall;

    private bool isPressed = false;

    void Update()
    {
        if (isPressed)
        {
            Vector2 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(posMouse, hook.position) > maxDistance)
            {
                rb.position = hook.position + (posMouse - hook.position).normalized * maxDistance;
            }
            else
            {
                rb.position = posMouse;
            }

        }
    }

    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;


        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds(2f);

        if(nextBall != null) { 
        nextBall.SetActive(true);
        } else
        {
            EnemyScript.EnemiesAlive = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
