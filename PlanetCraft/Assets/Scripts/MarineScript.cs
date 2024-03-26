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
            Debug.LogError("Nepoda�ilo se naj�t nep��telsk�ho rodi�e.");
            return;
        }
        enemies = GetChildObjects(enemyParent);
    }
    private void MoveToNearestEnemy()
    {
        if (enemies == null || enemies.Length == 0)
        {
            Debug.LogWarning("Nejsou k dispozici ��dn� nep��tel�.");
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
    private GameObject[] enemies; // Seznam v�ech nep��telsk�ch jednotek

    private void Start()
    {
        // P�i�ad�me rodi�ovsk� objekt
        ownTeam = transform.parent.gameObject;
        // Nastav�me nep��telsk�ho rodi�e podle jm�na vlastn�ho t�mu
        enemyParent = (ownTeam.CompareTag("player1")) ? GameObject.Find("player2") : GameObject.Find("player1");
        // Pokud se nepoda�� naj�t nep��telsk�ho rodi�e, vyp�eme chybovou hl�ku
        if (enemyParent == null)
        {
            Debug.LogError("Nepoda�ilo se naj�t nep��telsk�ho rodi�e.");
            return;
        }
        // Na za��tku najdeme v�echny nep��telsk� jednotky a ulo��me je do pole
        enemies = GetChildObjects(enemyParent);
    }

    private void Update()
    {
        MoveToNearestEnemy();
    }

    private void MoveToNearestEnemy()
    {
        // Zkontrolujeme, zda m�me nep��tele
        if (enemies == null || enemies.Length == 0)
        {
            Debug.LogWarning("Nejsou k dispozici ��dn� nep��tel�.");
            return;
        }
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;
        // Proch�z�me v�echny nep��telsk� jednotky a hled�me nejbli���
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

    // Pomocn� metoda pro nalezen� v�ech potomk�
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