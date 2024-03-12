using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class Worker : MonoBehaviour
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
        if (nearestMineral != null && nearestInhibitor != null)
        {
            if (nearestMineralDistance <= nearestInhibitorDistance)
            {
                currentTarget = nearestMineral;
            }
            else
            {
                currentTarget = nearestInhibitor;
            }

            reachedTarget = false;
        }
        else if (nearestMineral != null)
        {
            currentTarget = nearestMineral;
            reachedTarget = false;
        }
        else if (nearestInhibitor != null)
        {
            currentTarget = nearestInhibitor;
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
}*/
public class Worker : MonoBehaviour
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
    private void OnCollisionEnter2D(Collision2D other)
    {
        /*if (other.CompareTag("Mineral") || other.CompareTag("Inhibitor"))
        {
            Debug.Log("Worker se dotkl objektu: " + other.tag);
        }
        if (other.CompareTag("Mineral"))
        {
            Player.Minerals += 5;
        }*/
        if (other.gameObject.CompareTag("Mineral") || other.gameObject.CompareTag("Inhibitor"))
        {
            Debug.Log("Worker se dotkl objektu: " + other.gameObject.tag);
        }
        if (other.gameObject.CompareTag("Mineral"))
        {
            Player.Minerals += 5;
        }
    }
}