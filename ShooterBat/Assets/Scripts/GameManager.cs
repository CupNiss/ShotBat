using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject bat;
    public float limitX;
    public Transform spawnPoint;
    public float spwanRate;

    bool gameStarted = false;
   

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartSpawning();

            gameStarted = true;
        }
    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnBat", 0.5f, spwanRate);
    }

    private void SpawnBat()
    {
        Vector3 spawnPos = spawnPoint.position;

        spawnPos.x = Random.Range(-limitX, limitX);

        Instantiate(bat, spawnPos, Quaternion.identity);
    }
}
