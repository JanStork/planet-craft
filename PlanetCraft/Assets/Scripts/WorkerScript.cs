using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*public class Worker : MonoBehaviour
{
    public float speed = 5f;
    private Transform currentTarget;
    private bool reachedTarget;
    private bool actualTarget = true;
    void Start()
    {
        currentTarget = null;
        reachedTarget = false;
    }
    void Update()
    {
        if (reachedTarget || currentTarget == null)
        {
            Debug.Log("hleda             hleda                hleda               hleda              hleda");
            FindNearestTarget();
        }
        else
        {
            Debug.Log("hybe se");
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
        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        if (other.gameObject.CompareTag("Mineral") || other.gameObject.CompareTag("Inhibitor"))
        {
            Debug.Log("Worker se dotkl objektu: " + other.gameObject.tag);
        }
        if (other.gameObject.CompareTag("Mineral"))
        {
            Player.Minerals += 5;
        }
    }
}*/
public class Worker : MonoBehaviour
{
    public float speed = 5f;
    private Transform currentTarget;
    private bool reachedTarget;
    private bool actualTarget = true;
    private bool haveMineral = false;
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
    }
    void MoveTowardsTarget()
    {
        if (currentTarget != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, Time.deltaTime * speed);
            if (Vector2.Distance(transform.position, currentTarget.position) < 1f)
            {
                if (actualTarget)
                {
                    haveMineral = true;
                }
                if (haveMineral || !actualTarget)
                {
                    Player.Minerals += 25;
                    haveMineral = false;
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
        Transform nearestInhibitor = null;
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