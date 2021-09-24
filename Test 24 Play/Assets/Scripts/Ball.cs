using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float boundBallX = 11f;
    private float boundBallZ = 20f;
    private Goalkeeper goalkeeper;
    private RunBall runBall;
    void Update()
    {
        BallBound();
        FindGoalkeeper();
        runBall = GameObject.Find("RunBall").GetComponent<RunBall>();
        runBall.findBall = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goalkeeper"))
        {
            runBall.findBall = false;
            goalkeeper.findBall = false;
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            runBall.findBall = false;
            goalkeeper.findBall = false;
            Destroy(gameObject);
        }
    }

    void BallBound()
    {
        if (transform.position.x > boundBallX || transform.position.x < -boundBallX)
        {
            Destroy(gameObject);
        }

        if(transform.position.z > boundBallZ || transform.position.z < -boundBallZ)
        {
            Destroy(gameObject);
        }
    }

    void FindGoalkeeper()
    {
        goalkeeper = GameObject.Find("Goalkeeper").GetComponent<Goalkeeper>();
        goalkeeper.findBall = true;
    }

}
