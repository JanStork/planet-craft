using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhibitorScript : MonoBehaviour
{
    private double HP = 1500;
    public float detectionRange = 0.00001f;
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
        if (closestEnemy != null && Vector2.Distance(transform.position, closestEnemy.transform.position) < 0.00001f)
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
        return parentName;
    }
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