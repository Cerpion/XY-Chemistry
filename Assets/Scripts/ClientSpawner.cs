using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private List<ClientMovement> clientsPrefabs;

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _deliveryStage;
    [SerializeField] private Transform _exitStage;

    public ClientMovement CurrentClient { get; private set; }

    void Start()
    {
        SpawnClient();
    }

    public void SpawnClient()
    {
        int clientIndex = Random.Range(0, clientsPrefabs.Count);
        CurrentClient = Instantiate(clientsPrefabs[clientIndex], _spawnPoint.transform.position, Quaternion.identity);
        CurrentClient.Initialized(_deliveryStage, _exitStage);
    }
}
