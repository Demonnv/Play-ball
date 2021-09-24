using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] goals;
    public GameObject player;
    public Ball ballsc;
    public bool ballLive;
    public int countGoals;
    public Goal goalSc;
    public Goalkeeper goalkeeperSc;
    private int levelGame = 1;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        FindBall();
        ballLive = true;
        goalSc = FindObjectOfType<Goal>().GetComponent<Goal>();
        goalkeeperSc = GameObject.Find("Goalkeeper").GetComponent<Goalkeeper>();
        scoreText.text = "Level: " + levelGame;
    }

    // Update is called once per frame
    void Update()
    {
        FindBall();

        if (ballsc == null)
        {
            ballLive = false; 
        }

        if (ballsc == null && ballLive == false)
        {
            Instantiate(player, new Vector3(0, 0.75f, -17), player.transform.rotation);
            ballLive = true;
        }

        GoalsDetected();
        
    }

    void FindBall()
    {
        ballsc = FindObjectOfType<Ball>();
    }

    void GoalsDetected()
    {
        if(countGoals == 3)
        {
            for(int i = 0; i < goals.Length; i++)
            {
                goals[i].SetActive(true);
            }

            levelGame++;
            scoreText.text = "Level: " + levelGame;
            goalkeeperSc.speed++;
            countGoals = 0;
            Debug.Log("Game Level is " + levelGame + " Speed goalkeeper is " + goalkeeperSc.speed);
        }
    }
}
