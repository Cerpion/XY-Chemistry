using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private List<GameObject> clientsPrefabs = new List<GameObject>();
    ClientMovement client;
    private GameObject spawnPoint;
    private Vector3 spawnPosition;
    void Start()
    {
        spawnPoint = GameObject.Find("PointToSpawnClient");
        spawnPosition = spawnPoint.transform.position;
        SpawnClient();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnClient()
    {
        int clientIndex = Random.Range(0, clientsPrefabs.Count);
        Instantiate(clientsPrefabs[clientIndex], spawnPosition, Quaternion.identity);
    }
}
