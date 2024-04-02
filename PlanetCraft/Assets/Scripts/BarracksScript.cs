using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksScript : MonoBehaviour
{
    public float HP = 1000;
    public float detectionRadius = 0.001f;
    private GameObject ownTeam;
    private GameObject enemyParent;
    private GameObject[] enemies;
    private void Start()
    {
        Help();
    }
    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Marine") && collider.transform.parent != null && collider.transform.parent.CompareTag(enemyParent.tag))
            {
                HP -= 0.05f;
                Debug.Log("Inhibitor HP: " + HP);
            }
            if (collider.CompareTag("Worker") && collider.transform.parent != null && collider.transform.parent.CompareTag(enemyParent.tag))
            {
                HP -= 0.05f;
                Debug.Log("Inhibitor HP: " + HP);
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