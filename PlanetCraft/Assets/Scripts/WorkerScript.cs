using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public Transform mineralTarget; // C�l pracovn�ka - objekt "mineral"
    public Transform inhibitorTarget; // Druh� c�l pracovn�ka - objekt "Inhibitor"
    private Transform currentTarget; // Aktu�ln� c�l pracovn�ka
    private bool reachedTarget; // Flag pro kontrolu, zda pracovn�k dos�hl c�le
    public float speed = 5f;
    void Start()
    {
        // Nastaven� po��te�n�ho c�le pracovn�ka
        currentTarget = mineralTarget;
        reachedTarget = false;
    }
    void Update()
    {
        // Pokud pracovn�k dos�hl aktu�ln�ho c�le
        if (reachedTarget)
        {
            // Nastav�me dal�� c�l pracovn�ka
            SetNextTarget();
        }
        else
        {
            // Pokud pracovn�k je�t� nedos�hl c�le, pokra�uje ve sm�ru k n�mu
            MoveTowardsTarget();
        }
    }
    void MoveTowardsTarget()
    {
        // Pohyb pracovn�ka sm�rem k aktu�ln�mu c�li
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, Time.deltaTime * speed);
        // Pokud pracovn�k dos�hne c�le
        if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            reachedTarget = true;
        }
    }
    void SetNextTarget()
    {
        // Pokud aktu�ln� c�l je objekt "mineral", nastav�me dal�� c�l na objekt "Inhibitor" a naopak
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
        // Pokud pracovn�k se dotkne objektu s tagem "Mineral" nebo "Inhibitor"
        if (other.CompareTag("Mineral") || other.CompareTag("Inhibitor"))
        {
            // Reagovat zde na dotyk s objektem
            // Nap��klad zastavit pracovn�ka nebo prov�st jinou akci
            // Tato ��st k�du m��e b�t upravena podle pot�eby
            Debug.Log("Worker se dotkl objektu: " + other.tag);
        }
    }
}