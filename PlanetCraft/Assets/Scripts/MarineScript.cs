using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MarineScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    private GameObject ownTeam;
    private GameObject enemyParent;
    private GameObject[] enemies;
    GameObject closestEnemy = null;
    private double HP = 350;
    public float detectionRadius = 0.001f;
    private void Start()
    {
        Help();
    }
    private void Update()
    {
        Help();
        MoveToNearestEnemy();
        Damage();
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
                    Debug.Log("Merine HP: " + HP);
                }
                if (collider.CompareTag("Worker") && collider.transform.parent != null && collider.transform.parent.CompareTag(enemyParent.tag))
                {
                    HP -= 0.01f;
                    Debug.Log("Marine HP: " + HP);
                }
                if (collider.CompareTag("Inhibitor") && collider.transform.parent != null && collider.transform.parent.CompareTag(enemyParent.tag))
                {
                    HP -= 0.03f;
                    Debug.Log("Marine HP: " + HP);
                }
                if (collider.CompareTag("Barracks") && collider.transform.parent != null && collider.transform.parent.CompareTag(enemyParent.tag))
                {
                    HP -= 0.03f;
                    Debug.Log("Marine HP: " + HP);
                }
            }
        }
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