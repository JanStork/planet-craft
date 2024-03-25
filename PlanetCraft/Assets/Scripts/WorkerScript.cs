using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Worker : MonoBehaviour
{
    public float speed = 5f;
    private Transform currentTarget;
    private bool reachedTarget;
    private bool actualTarget = true;
    Transform nearestInhibitor = null;
    private double HP = 150;
    void Start()
    {
        currentTarget = null;
        reachedTarget = false;
    }
    void Update()
    {
        if (reachedTarget || currentTarget == null)
        {
            Debug.Log("Searching for target...");
            FindNearestTarget();
        }
        else
        {
            Debug.Log("Moving...");
            MoveTowardsTarget();
        }
        if (HP <= 0)
        {
            Destroy(gameObject ,0f);
        }
    }
    void MoveTowardsTarget()
    {
        if (currentTarget != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, Time.deltaTime * speed);
            if (Vector2.Distance(transform.position, currentTarget.position) < 1f)
            {
                if (currentTarget == nearestInhibitor)
                {
                    Player.Minerals += 2;
                }
                reachedTarget = true;
                actualTarget = !actualTarget;
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
        nearestInhibitor = null;
        if (actualTarget)
        {
            foreach (GameObject mineral in minerals)
            {
                float distance = Vector2.Distance(transform.position, mineral.transform.position);
                if (distance < nearestMineralDistance)
                {
                    nearestMineralDistance = distance;
                    nearestMineral = mineral.transform;
                }
            }
            currentTarget = nearestMineral;
        }
        else
        {
            foreach (GameObject inhibitor in inhibitors)
            {
                float distance = Vector2.Distance(transform.position, inhibitor.transform.position);
                if (distance < nearestInhibitorDistance)
                {
                    nearestInhibitorDistance = distance;
                    nearestInhibitor = inhibitor.transform;
                }
            }
            currentTarget = nearestInhibitor;
        }
        reachedTarget = false;
    }
}