using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalkeeper : MonoBehaviour
{
    public float speed = 1f;
    public Transform ball;
    private float xPos;
    private float boundPos = 8;
    private Vector3 startPos;
    public bool findBall;


    void Start()
    {
        startPos = transform.position;

    }

    void Update()
    {
        if (findBall == true)
        {
            BallIdentify();

            xPos = (ball.transform.position.x - transform.position.x);
            if (xPos > 0.5f || xPos < -0.5f)
            {
                transform.Translate(new Vector3(xPos, 0, 0).normalized * speed * Time.deltaTime);
            }
        }
        

        BoundGoalkeeper();
    }

    void BallIdentify()
    {
        ball = FindObjectOfType<Ball>().GetComponent<Transform>();
        if(findBall == false)
        {
            transform.position = startPos;
        }
    }

    void BoundGoalkeeper()
    {
        if (transform.position.x > boundPos)
        {
            transform.position = new Vector3(boundPos, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -boundPos)
        {
            transform.position = new Vector3(-boundPos, transform.position.y, transform.position.z);
        }
    }
}
