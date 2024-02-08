using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public Transform mineralTarget; // Cíl pracovníka - objekt "mineral"
    public Transform inhibitorTarget; // Druhý cíl pracovníka - objekt "Inhibitor"
    private Transform currentTarget; // Aktuální cíl pracovníka
    private bool reachedTarget; // Flag pro kontrolu, zda pracovník dosáhl cíle
    public float speed = 5f;
    void Start()
    {
        // Nastavení poèáteèního cíle pracovníka
        currentTarget = mineralTarget;
        reachedTarget = false;
    }
    void Update()
    {
        // Pokud pracovník dosáhl aktuálního cíle
        if (reachedTarget)
        {
            // Nastavíme další cíl pracovníka
            SetNextTarget();
        }
        else
        {
            // Pokud pracovník ještì nedosáhl cíle, pokraèuje ve smìru k nìmu
            MoveTowardsTarget();
        }
    }
    void MoveTowardsTarget()
    {
        // Pohyb pracovníka smìrem k aktuálnímu cíli
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, Time.deltaTime * speed);
        // Pokud pracovník dosáhne cíle
        if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            reachedTarget = true;
        }
    }
    void SetNextTarget()
    {
        // Pokud aktuální cíl je objekt "mineral", nastavíme další cíl na objekt "Inhibitor" a naopak
        if (currentTarget == mineralTarget)
        {
            currentTarget = inhibitorTarget;
        }
        else
        {
            currentTarget = mineralTarget;
        }
        reachedTarget = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Pokud pracovník se dotkne objektu s tagem "Mineral" nebo "Inhibitor"
        if (other.CompareTag("Mineral") || other.CompareTag("Inhibitor"))
        {
            // Reagovat zde na dotyk s objektem
            // Napøíklad zastavit pracovníka nebo provést jinou akci
            // Tato èást kódu mùže být upravena podle potøeby
            Debug.Log("Worker se dotkl objektu: " + other.tag);
        }
    }
}