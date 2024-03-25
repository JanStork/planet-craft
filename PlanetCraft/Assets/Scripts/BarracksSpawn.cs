using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksSpawn : MonoBehaviour
{
    public GameObject barracksPrefab;
    private double HP = 1000;
    void Update()
    {
        if (Player.barracksActive && Input.GetMouseButtonDown(0))
        {
            InstantiateBarracksAtCursor();
            Debug.Log("Barracks spawned");
            Player.barracksActive = false;
            Player.Minerals -= 250;
        }
        if (Player.barracksActive && Input.GetMouseButtonDown(1))
        {
            Player.barracksActive = false;
        }
        if (HP <= 0)
        {
            Destroy(gameObject, 0f);
        }
    }
    private void InstantiateBarracksAtCursor()
    {
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = 0f;
        Instantiate(barracksPrefab, cursorPosition, Quaternion.identity);
    }
}