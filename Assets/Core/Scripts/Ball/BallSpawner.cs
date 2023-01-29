using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private Transform ballSpawnPoint;
   
    private float ballSpawnTime;
    private const int ballSpawnDefaultTime=5;
    
    private void Start()
    {
        SpawnBall();
    }
    private void SpawnBall()
    {
        Instantiate(ball,ballSpawnPoint.position,Quaternion.identity);
    }

    private void Update()
    {
        if (ballSpawnTime>= ballSpawnDefaultTime)
        {
            SpawnBall();
            ballSpawnTime=0;
        }
        else
        {
            ballSpawnTime+=Time.deltaTime;
        }
    }
}
