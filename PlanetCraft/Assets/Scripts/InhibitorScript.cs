using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhibitorScript : MonoBehaviour
{
    public float HP = 1500;
    public float detectionRadius = 5f;
    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Marine") && collider.transform.parent != null && collider.transform.parent.CompareTag("player1"))
            {
                HP -= 10f;
                Debug.Log("Inhibitor HP: " + HP);
            }
            if (collider.CompareTag("Worker") && collider.transform.parent != null && collider.transform.parent.CompareTag("player1"))
            {
                HP -= 2f;
                Debug.Log("Inhibitor HP: " + HP);
            }
        }
        if (HP <= 0)
        {
            Destroy(gameObject, 0f);
        }
    }
    /*public float moveSpeed = 5f;
    private GameObject ownTeam;
    private GameObject enemyParent;
    private GameObject[] enemies;
    GameObject closestEnemy = null;
    private double HP = 350;
    private void Start()
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
    private void Update()
    {
        NearestEnemy();
        if (Vector2.Distance(transform.position, closestEnemy.transform.position) < 10f)
        {
            if (closestEnemy.CompareTag("Inhibitor") || closestEnemy.CompareTag("Barracks"))
            {
                HP -= 1;
                Debug.Log("-HP - Inhibitor or barracks  aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            }
            else if (closestEnemy.CompareTag("Worker"))
            {
                HP -= 2.5;
                Debug.Log("-HP - Worker");
            }
            else if (closestEnemy.CompareTag("Marine"))
            {
                HP -= 5;
                Debug.Log("-HP - Marine");
            }
            else
            {
                Debug.Log("ccccccccccccccccccccccccccccccccccc");
            }
        }
        if (HP <= 0)
        {
            Destroy(gameObject, 0f);
        }
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
    private void NearestEnemy()
    {
        if (enemies == null || enemies.Length == 0)
        {
            Debug.LogWarning("Nejsou k dispozici žádní nepøátelé.");
            return;
        }
        float closestDistance = Mathf.Infinity;
        closestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
    }*/
    /*public double HP = 1500;
    private GameObject enemyParent;
    private GameObject[] enemies;
    private GameObject closestEnemy = null;
    void Start()
    {
        if (GetParentName() == "player1")
        {
            enemyParent = (transform.CompareTag("player1")) ? GameObject.Find("player1") : GameObject.Find("player2");
        }
        else if (GetParentName() == "player2")
        {
            enemyParent = (transform.CompareTag("player1")) ? GameObject.Find("player2") : GameObject.Find("player1");
        }
        if (enemyParent == null)
        {
            Debug.LogError("Nepodaøilo se najít nepøátelského rodièe.");
            return;
        }
        enemies = GetChildObjects(enemyParent);
    }
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject, 0f);
        }
        FindNearestEnemy();
        if (closestEnemy != null && Vector2.Distance(transform.position, closestEnemy.transform.position) < 1f)
        {
            if (closestEnemy.CompareTag("Marine"))
            {
                Debug.Log("MarineAttack    aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                HP -= 10;
            }
            if (closestEnemy.CompareTag("Inhibitor") || closestEnemy.CompareTag("Barracks"))
            {
                Debug.Log("Kolize             bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");
                HP -= 1000;
            }
        }
        Debug.Log("HP: " + HP.ToString() + "ccccccccccccccccccccccccccccccccccccccccccccccccccc");
    }
    void FindNearestEnemy()
    {
        if (enemies == null || enemies.Length == 0)
        {
            Debug.LogWarning("Nejsou k dispozici žádní nepøátelé.");
            return;
        }
        float closestDistance = Mathf.Infinity;
        closestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            if (enemy == null) continue;
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
        Debug.Log("Nejblizsi nepritel: " + closestEnemy.tag.ToString());
    }
    GameObject[] GetChildObjects(GameObject parent)
    {
        List<GameObject> childObjects = new List<GameObject>();
        foreach (Transform child in parent.transform)
        {
            childObjects.Add(child.gameObject);
        }
        return childObjects.ToArray();
    }
    string GetParentName()
    {
        Transform parentTransform = transform.parent;
        if (parentTransform == null)
        {
            Debug.LogWarning("Objekt nemá žádného rodièe.");
            return "";
        }
        string parentName = parentTransform.gameObject.name;
        Debug.Log("Jmeno rodice je: " + parentName);
        return parentName;
    }
}*/
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhibitorScript : MonoBehaviour
{
    private double HP = 1500;
    public float detectionRange = 5f;
    private GameObject enemyParent;
    private GameObject[] enemies;
    private GameObject closestEnemy = null;

    void Start()
    {
        enemyParent = (transform.CompareTag("player1")) ? GameObject.Find("player2") : GameObject.Find("player1");
        if (enemyParent == null)
        {
            Debug.LogError("Nepodaøilo se najít nepøátelského rodièe.");
            return;
        }
        enemies = GetChildObjects(enemyParent);
    }
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject, 0f);
        }
        FindNearestEnemy();
        if (closestEnemy != null && Vector2.Distance(transform.position, closestEnemy.transform.position) < 1f)
        {
            if (closestEnemy.CompareTag("Marine"))
            {
                Debug.Log("MarineAttack");
                HP -= 10;
            }
            if (closestEnemy.CompareTag("Inhibitor") || closestEnemy.CompareTag("Barracks"))
            {
                Debug.Log("Kolize");
                HP -= 1000;
            }
        }
    }
    void FindNearestEnemy()
    {
        if (enemies == null || enemies.Length == 0)
        {
            Debug.LogWarning("Nejsou k dispozici žádní nepøátelé.");
            return;
        }
        float closestDistance = Mathf.Infinity;
        closestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            if (enemy == null) continue; // Check if the enemy object is not null

            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
    }
    GameObject[] GetChildObjects(GameObject parent)
    {
        List<GameObject> childObjects = new List<GameObject>();
        foreach (Transform child in parent.transform)
        {
            childObjects.Add(child.gameObject);
        }
        return childObjects.ToArray();
    }
}*/