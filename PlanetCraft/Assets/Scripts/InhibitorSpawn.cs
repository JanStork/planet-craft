using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhibitorSpawn : MonoBehaviour
{
    public GameObject inhibitorPrefab;
    void Update()
    {
        if (Player.inhibitorActive && Input.GetMouseButtonDown(0))
        {
            InstantiateInhibitorAtCursor();
            Debug.Log("Inhibitor spawned");
            Player.inhibitorActive = false;
        }
        if (Player.inhibitorActive && Input.GetMouseButtonDown(1))
        {
            Player.inhibitorActive = false;
        }
    }
    private void InstantiateInhibitorAtCursor()
    {
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = 0f;
        Instantiate(inhibitorPrefab, cursorPosition, Quaternion.identity);
    }
}