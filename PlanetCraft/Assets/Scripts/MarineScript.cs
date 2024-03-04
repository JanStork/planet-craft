using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarineScript : MonoBehaviour
{
    public float speed = 5f;
    private Transform currentTarget;
    private bool reachedTarget;
    void Start()
    {
        currentTarget = null;
        reachedTarget = false;
    }
    void Update()
    {
        if (reachedTarget || currentTarget == null)
        {
            FindNearestTarget();
        }
        else
        {
            MoveTowardsTarget();
        }
    }
    void MoveTowardsTarget()
    {
        if (currentTarget != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, Time.deltaTime * speed);
            if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
            {
                reachedTarget = true;
            }
        }
    }
    void FindNearestTarget()
    {
        GameObject[] minerals = GameObject.FindGameObjectsWithTag("Mineral");
        GameObject[] inhibitors = GameObject.FindGameObjectsWithTag("Inhibitor");
        float nearestMineralDistance = Mathf.Infinity;
        float nearestInhibitorDistance = Mathf.Infinity;
        Transform nearestMineral = null;
        Transform nearestInhibitor = null;
        foreach (GameObject mineral in minerals)
        {
            float distance = Vector2.Distance(transform.position, mineral.transform.position);
            if (distance < nearestMineralDistance)
            {
                nearestMineralDistance = distance;
                nearestMineral = mineral.transform;
            }
        }
        foreach (GameObject inhibitor in inhibitors)
        {
            float distance = Vector2.Distance(transform.position, inhibitor.transform.position);
            if (distance < nearestInhibitorDistance)
            {
                nearestInhibitorDistance = distance;
                nearestInhibitor = inhibitor.transform;
            }
        }
        if (nearestInhibitor != null)
        {
            currentTarget = nearestInhibitor;
            reachedTarget = false;
        }
        else if (nearestMineral != null)
        {
            currentTarget = nearestMineral;
            reachedTarget = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mineral") || other.CompareTag("Inhibitor"))
        {
            Debug.Log("Worker se dotkl objektu: " + other.tag);
        }
    }
}