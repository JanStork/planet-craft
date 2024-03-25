using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarineScript : MonoBehaviour
{
    public float moveSpeed = 5f; // Rychlost pohybu jednotky

    private GameObject ownTeam; // Reference na tým, ke kterému tato jednotka patøí
    private GameObject enemyTeam; // Reference na nepøátelský tým

    private void Start()
    {
        // Pøi spuštìní hry získáváme referenci na tým, ke kterému tato jednotka patøí,
        // a nepøátelský tým na základì názvu tohoto týmu
        ownTeam = transform.parent.gameObject;
        enemyTeam = (ownTeam.name == "player1") ? GameObject.Find("player2") : GameObject.Find("player1");

        // Zahajujeme pohyb k nejbližšímu nepøátelskému objektu
        MoveToNearestEnemy();
    }

    private void MoveToNearestEnemy()
    {
        // Získání všech colliderù v okruhu 10 jednotek od pozice této jednotky
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 10f);

        // Inicializace promìnných pro uchování nejbližšího nepøátelského objektu a vzdálenosti k nìmu
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        // Procházení všech colliderù v okruhu
        foreach (Collider2D col in hitColliders)
        {
            // Kontrola, zda nalezený collider patøí nepøátelskému týmu
            if (col.gameObject.transform.parent == enemyTeam.transform)
            {
                // Vypoètení vzdálenosti mezi touto jednotkou a nalezeným nepøátelským objektem
                float distance = Vector2.Distance(transform.position, col.gameObject.transform.position);

                // Aktualizace nejbližšího nepøátelského objektu, pokud je vzdálenost menší než dosavadní nejbližší objekt
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = col.gameObject;
                }
            }
        }

        // Pokud byl nalezen nejbližší nepøátelský objekt
        if (closestEnemy != null)
        {
            // Urèení smìru k nejbližšímu nepøátelskému objektu a pohyb v tomto smìru s danou rychlostí
            Vector3 direction = closestEnemy.transform.position - transform.position;
            direction.Normalize();
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}
