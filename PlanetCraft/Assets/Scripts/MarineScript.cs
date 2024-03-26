using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarineScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    private GameObject ownTeam;
    private GameObject enemyParent;
    private GameObject[] enemies;
    GameObject closestEnemy = null;
    private double HP = 350;
    private void Start()
    {
        Help();
    }
    private void Update()
    {
        Help();
        MoveToNearestEnemy();
        if (Vector2.Distance(transform.position, closestEnemy.transform.position) < 0.001f)
        {
            if (closestEnemy.CompareTag("Inhibitor") || closestEnemy.CompareTag("Barracks"))
            {
                HP -= 1;
                Debug.Log("-HP - Inhibitor or barracks");
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
        }
        if (HP <= 0)
        {
            Destroy(gameObject, 0f);
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
    private void MoveToNearestEnemy()
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
        if (closestEnemy != null)
        {
            Vector3 direction = closestEnemy.transform.position - transform.position;
            direction.Normalize();
            transform.Translate(direction * moveSpeed * Time.deltaTime);
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
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarineScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    private GameObject ownTeam;
    private GameObject enemyParent;
    private GameObject[] enemies; // Seznam všech nepøátelských jednotek

    private void Start()
    {
        // Pøiøadíme rodièovský objekt
        ownTeam = transform.parent.gameObject;
        // Nastavíme nepøátelského rodièe podle jména vlastního týmu
        enemyParent = (ownTeam.CompareTag("player1")) ? GameObject.Find("player2") : GameObject.Find("player1");
        // Pokud se nepodaøí najít nepøátelského rodièe, vypíšeme chybovou hlášku
        if (enemyParent == null)
        {
            Debug.LogError("Nepodaøilo se najít nepøátelského rodièe.");
            return;
        }
        // Na zaèátku najdeme všechny nepøátelské jednotky a uložíme je do pole
        enemies = GetChildObjects(enemyParent);
    }

    private void Update()
    {
        MoveToNearestEnemy();
    }

    private void MoveToNearestEnemy()
    {
        // Zkontrolujeme, zda máme nepøátele
        if (enemies == null || enemies.Length == 0)
        {
            Debug.LogWarning("Nejsou k dispozici žádní nepøátelé.");
            return;
        }
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;
        // Procházíme všechny nepøátelské jednotky a hledáme nejbližší
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
        if (closestEnemy != null)
        {
            Vector3 direction = closestEnemy.transform.position - transform.position;
            direction.Normalize();
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

    // Pomocná metoda pro nalezení všech potomkù
    private GameObject[] GetChildObjects(GameObject parent)
    {
        List<GameObject> childObjects = new List<GameObject>();
        foreach (Transform child in parent.transform)
        {
            childObjects.Add(child.gameObject);
        }
        return childObjects.ToArray();
    }
}
*/