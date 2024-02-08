using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerSpawner : MonoBehaviour
{
    public GameObject workerPrefab;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void SpawnWorker()
    {
        Instantiate(workerPrefab, transform.position, Quaternion.identity);
    }
}