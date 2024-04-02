using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Worker : MonoBehaviour
{
    public float speed = 5f;
    private Transform currentTarget;
    private bool reachedTarget;
    private bool actualTarget = true;
    private Transform nearestInhibitor = null;
    private float HP = 150;
    private GameObject ownTeam;
    private GameObject enemyParent;
    private GameObject[] enemies;
    public float detectionRadius = 0.001f;
    void Start()
    {
        currentTarget = null;
        reachedTarget = false;
        Help();
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
        Damage();
        if (HP <= 0)
        {
            Destroy(gameObject, 0f);
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
                    Debug.Log("Reached nearest Inhibitor");
                }
                reachedTarget = true;
                actualTarget = !actualTarget;
            }
        }
    }
    void FindNearestTarget()
    {
        GameObject[] minerals = GameObject.FindGameObjectsWithTag("Mineral");
        GameObject[] inhibitors = GetInhibitorsInTeam(ownTeam);
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
    private void Damage()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        if (colliders != null && colliders.Length > 0)
        {
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Marine") && collider.transform.parent != null && collider.transform.parent.CompareTag(enemyParent.tag))
                {
                    HP -= 0.1f;
                    Debug.Log("Worker HP: " + HP);
                }
                if (collider.CompareTag("Worker") && collider.transform.parent != null && collider.transform.parent.CompareTag(enemyParent.tag))
                {
                    HP -= 0.01f;
                    Debug.Log("Worker HP: " + HP);
                }
                if (collider.CompareTag("Inhibitor") && collider.transform.parent != null && collider.transform.parent.CompareTag(enemyParent.tag))
                {
                    HP -= 0.03f;
                    Debug.Log("Worker HP: " + HP);
                }
                if (collider.CompareTag("Barracks") && collider.transform.parent != null && collider.transform.parent.CompareTag(enemyParent.tag))
                {
                    HP -= 0.03f;
                    Debug.Log("Worker HP: " + HP);
                }
            }
        }
    }
    private void Help()
    {
        ownTeam = transform.parent.gameObject;
        enemyParent = (ownTeam.CompareTag("player1")) ? GameObject.Find("player2") : GameObject.Find("player1");
        if (enemyParent == null)
        {
            Debug.LogError("Nepodaøilo se najít nepøátelského rodièe.");
            return;
        }
        enemies = GetChildObjects(enemyParent);
    }
    private GameObject[] GetChildObjects(GameObject parent)
    {
        List<GameObject> childObjects = new List<GameObject>();
        foreach (Transform child in parent.transform)
        {
            childObjects.Add(child.gameObject);
        }
        return childObjects.ToArray();
    }
    private GameObject[] GetInhibitorsInTeam(GameObject ownTeam)
    {
        List<GameObject> inhibitorsInTeam = new List<GameObject>();
        if (ownTeam == null)
        {
            Debug.LogError("Vlastní tým není nastaven.");
            return null;
        }
        foreach (Transform child in ownTeam.transform)
        {
            GameObject childGameObject = child.gameObject;
            if (childGameObject.CompareTag("Inhibitor"))
            {
                inhibitorsInTeam.Add(childGameObject);
            }
        }
        if (inhibitorsInTeam.Count == 0)
        {
            Debug.LogWarning("V týmu nebyly nalezeny žádné inhibitory.");
        }
        return inhibitorsInTeam.ToArray();
    }
}
/*using System.Collections;
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
    private GameObject ownTeam;
    private GameObject enemyParent;
    private GameObject[] enemies;
    public float detectionRadius = 0.001f;
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
        Damage();
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
    private void Damage()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        if (colliders != null && colliders.Length > 0)
        {
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Marine") && collider.transform.parent != null && collider.transform.parent.CompareTag(enemyParent.tag))
                {
                    HP -= 0.1f;
                    Debug.Log("Inhibitor HP: " + HP);
                }
                if (collider.CompareTag("Worker") && collider.transform.parent != null && collider.transform.parent.CompareTag(enemyParent.tag))
                {
                    HP -= 0.01f;
                    Debug.Log("Inhibitor HP: " + HP);
                }
                if (collider.CompareTag("Inhibitor") && collider.transform.parent != null && collider.transform.parent.CompareTag(enemyParent.tag))
                {
                    HP -= 0.03f;
                    Debug.Log("Inhibitor HP: " + HP);
                }
                if (collider.CompareTag("Barracks") && collider.transform.parent != null && collider.transform.parent.CompareTag(enemyParent.tag))
                {
                    HP -= 0.03f;
                    Debug.Log("Inhibitor HP: " + HP);
                }
            }
        }
    }
    private void Help()
    {
        ownTeam = transform.parent.gameObject;
        enemyParent = (ownTeam.CompareTag("player1")) ? GameObject.Find("player2") : GameObject.Find("player1");
        if (enemyParent == null)
        {
            Debug.LogError("Nepodaøilo se najít nepøátelského rodièe.");
            return;
        }
        enemies = GetChildObjects(enemyParent);
    }
    private GameObject[] GetChildObjects(GameObject parent)
    {
        List<GameObject> childObjects = new List<GameObject>();
        foreach (Transform child in parent.transform)
        {
            childObjects.Add(child.gameObject);
        }
        return childObjects.ToArray();
    }
}*/