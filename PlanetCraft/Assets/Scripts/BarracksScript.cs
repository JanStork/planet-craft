using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksScript : MonoBehaviour
{
    public float HP = 1000;
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
}