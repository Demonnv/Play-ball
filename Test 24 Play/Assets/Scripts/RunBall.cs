using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBall : MonoBehaviour
{
    public Rigidbody ballRb;
    private float speedBall = 5f;
    private float boundRB = 7f;
    private float boundZmin = -2f;
    private float boundZmax = -14f;
    private Touch touch;
    private float speedModifier;
    private Vector3 startPoint;
    private GameObject arrow;
    public bool findBall;

    private void Start()
    {
        speedModifier = 0.02f;
        startPoint = transform.position;
        arrow = GameObject.Find("Arrow");

    }
    void Update()
    {
        if (findBall == true)
        {
            FindBallRb();
        }


        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            
            if(touch.phase == TouchPhase.Moved)
            {
                arrow.SetActive(true);
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier, 0.25f,
                    transform.position.z + touch.deltaPosition.y * speedModifier);
            }
            else if(touch.phase == TouchPhase.Stationary)
            {
                arrow.SetActive(true);
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                arrow.SetActive(false);
                Vector3 distanceForce = transform.position - startPoint;
                ballRb.AddForce(distanceForce * speedBall, ForceMode.Impulse);
                transform.position = startPoint;
            }
        }

        Bounds();
    }

    void Bounds()
    {
        if(transform.position.x > boundRB)
        {
            transform.position = new Vector3(boundRB, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < -boundRB)
        {
            transform.position = new Vector3(-boundRB, transform.position.y, transform.position.z);
        }

        if(transform.position.z > boundZmin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, boundZmin);
        }
        else if(transform.position.z < boundZmax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, boundZmax);
        }
        
    }

    void FindBallRb()
    {
        ballRb = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody>();
    }
}
