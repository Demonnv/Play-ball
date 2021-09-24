using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public SpawnManager spawnSc;

    private void Start()
    {
        spawnSc = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            spawnSc.countGoals++;
            gameObject.SetActive(false);
            
        }
    }
}
