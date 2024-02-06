using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    /*public GameObject WorkerButton;
    public GameObject MarineButton;*/
    /*private void OnMouseDown()
    {
        if (gameObject.CompareTag("Inhibitor"))
        {
            WorkerButton.SetActive(true);
        }
        else if (gameObject.CompareTag("Barracks"))
        {
            MarineButton.SetActive(true);
        }
        else if (gameObject.CompareTag("Map"))
        {
            WorkerButton.SetActive(false);
            MarineButton.SetActive(false);
        }
    }*/
    /*void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;
            }
        }
    }*/
    private Camera cam;
    public LayerMask mask;
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero, Mathf.Infinity, mask);
            if (hit.collider != null)
            {
                Debug.Log(hit.transform.name);
                hit.transform.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}