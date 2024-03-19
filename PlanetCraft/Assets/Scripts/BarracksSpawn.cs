using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksSpawn : MonoBehaviour
{
    public GameObject barracksPrefab;
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
    }
    private void InstantiateBarracksAtCursor()
    {
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = 0f;
        Instantiate(barracksPrefab, cursorPosition, Quaternion.identity);
    }
}