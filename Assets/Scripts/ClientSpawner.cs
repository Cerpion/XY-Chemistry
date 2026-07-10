using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _deliveryStage;
    [SerializeField] private Transform _exitStage;

    public ClientMovement CurrentClient { get; private set; }

    public void SpawnClient(ClientDay clientDay)
    {
        CurrentClient = Instantiate(clientDay.ClientStats.Prefab, _spawnPoint.transform.position, Quaternion.identity);
        CurrentClient.Initialized(_deliveryStage, _exitStage, clientDay.Order, clientDay.ClientTime, clientDay.ClientStats);
    }
}
