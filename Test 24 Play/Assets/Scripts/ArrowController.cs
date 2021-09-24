using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private Transform ball;
    private Transform runBall;
    private Quaternion arrowRot;

    void Start()
    {
        FindGameObjects();
    }

    void Update()
    {
            FindGameObjects();

        transform.position = (runBall.transform.position + ball.transform.position)/2;
        transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        Vector3 relativePos = runBall.position - transform.position;
        Vector3 scaleX = new Vector3(relativePos.x/3, -relativePos.y, relativePos.z);
        arrowRot = Quaternion.LookRotation(relativePos, Vector3.up) * Quaternion.Euler(90, 0, transform.rotation.z);
        transform.LookAt(runBall);
        transform.rotation = arrowRot;
        transform.localScale = scaleX;
    }

    void FindGameObjects()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Transform>();
        runBall = GameObject.Find("RunBall").GetComponent<Transform>();
    }
}
