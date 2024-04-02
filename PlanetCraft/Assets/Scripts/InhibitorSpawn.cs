using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhibitorSpawn : MonoBehaviour
{
    public GameObject inhibitorPrefab;
    public GameObject player1;
    private GameObject playerCamera;
    private Transform parent;
    private void Start()
    {
        //PlayerTeam();
    }
    void Update()
    {
        if (Player.inhibitorActive && Input.GetMouseButtonDown(0))
        {
            InstantiateInhibitorAtCursor();
            Debug.Log("Inhibitor spawned");
            Player.inhibitorActive = false;
            Player.Minerals -= 500;
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
        GameObject inhibitorInstance = Instantiate(inhibitorPrefab, cursorPosition, Quaternion.identity);
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