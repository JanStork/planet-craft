using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarineScript : MonoBehaviour
{
    public float moveSpeed = 5f; // Rychlost pohybu jednotky

    private GameObject ownTeam; // Reference na t�m, ke kter�mu tato jednotka pat��
    private GameObject enemyTeam; // Reference na nep��telsk� t�m

    private void Start()
    {
        // P�i spu�t�n� hry z�sk�v�me referenci na t�m, ke kter�mu tato jednotka pat��,
        // a nep��telsk� t�m na z�klad� n�zvu tohoto t�mu
        ownTeam = transform.parent.gameObject;
        enemyTeam = (ownTeam.name == "player1") ? GameObject.Find("player2") : GameObject.Find("player1");

        // Zahajujeme pohyb k nejbli���mu nep��telsk�mu objektu
        MoveToNearestEnemy();
    }

    private void MoveToNearestEnemy()
    {
        // Z�sk�n� v�ech collider� v okruhu 10 jednotek od pozice t�to jednotky
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 10f);

        // Inicializace prom�nn�ch pro uchov�n� nejbli���ho nep��telsk�ho objektu a vzd�lenosti k n�mu
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        // Proch�zen� v�ech collider� v okruhu
        foreach (Collider2D col in hitColliders)
        {
            // Kontrola, zda nalezen� collider pat�� nep��telsk�mu t�mu
            if (col.gameObject.transform.parent == enemyTeam.transform)
            {
                // Vypo�ten� vzd�lenosti mezi touto jednotkou a nalezen�m nep��telsk�m objektem
                float distance = Vector2.Distance(transform.position, col.gameObject.transform.position);

                // Aktualizace nejbli���ho nep��telsk�ho objektu, pokud je vzd�lenost men�� ne� dosavadn� nejbli��� objekt
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = col.gameObject;
                }
            }
        }

        // Pokud byl nalezen nejbli��� nep��telsk� objekt
        if (closestEnemy != null)
        {
            // Ur�en� sm�ru k nejbli���mu nep��telsk�mu objektu a pohyb v tomto sm�ru s danou rychlost�
            Vector3 direction = closestEnemy.transform.position - transform.position;
            direction.Normalize();
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}
