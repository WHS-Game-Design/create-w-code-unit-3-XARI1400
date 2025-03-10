using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float startDelay;
    [SerializeField] private float spawnRate;

    private Vector3 spawnPosition = new(30, 0, 0);


    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>(); 
        InvokeRepeating(nameof(SpawnObstacle), startDelay, spawnRate);
    }


    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
    }
}
