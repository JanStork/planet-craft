using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksSpawn : MonoBehaviour
{
    public GameObject barracksPrefab;
    public GameObject player1;
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
        GameObject inhibitorInstance = Instantiate(barracksPrefab, cursorPosition, Quaternion.identity);
        inhibitorInstance.transform.parent = GameObject.Find("player1"/*parent.tag*/).transform;
    }
    /*private void PlayerTeam()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            playerCamera = Camera.main.gameObject;
            if (playerCamera != null)
            {
                parent = playerCamera.transform.parent;
            }
        }
    }*/
}