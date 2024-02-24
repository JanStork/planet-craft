/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject workerIcon;
    public GameObject marineIcon;
    private void Start()
    {
        workerIcon.SetActive(false);
        marineIcon.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Inhibitor"))
                {
                    Inhibitor inhibitor = hit.collider.GetComponent<Inhibitor>();
                    if (inhibitor != null)
                    {
                        inhibitor.OnClick();
                    }
                    workerIcon.SetActive(true);
                }
                else if (hit.collider.CompareTag("Baracks"))
                {
                    Baracks baracks = hit.collider.GetComponent<Baracks>();
                    if (baracks != null)
                    {
                        // Volání metody pro "Baracks"
                        baracks.OnClick();
                    }
                    marineIcon.SetActive(true);
                }
                else if (hit.collider.CompareTag("UI"))
                {

                }
                else
                {
                    DoSomethingElse();
                }
            }
            else
            {
                DoSomethingElse();
            }
        }
    }
    void DoSomethingElse()
    {
        workerIcon?.SetActive(false);
        marineIcon?.SetActive(false);
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject player1;
    public GameObject workerPrefab;
    public GameObject marinePrefab;
    public GameObject workerIcon;
    public GameObject marineIcon;
    private void Start()
    {
        workerIcon.SetActive(false);
        marineIcon.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Inhibitor"))
                {
                    marineIcon.SetActive(false);
                    workerIcon.SetActive(true);
                }
                else if (hit.collider.CompareTag("WorkerButton"))
                {
                    Vector3 newPosition = new Vector3(-19f, -7f, 0f);
                    GameObject newWorker = Instantiate(workerPrefab, newPosition, Quaternion.identity);
                    newWorker.transform.parent = player1.transform;
                }
                else if (hit.collider.CompareTag("Barracks"))
                {
                    workerIcon.SetActive(false);
                    marineIcon.SetActive(true);
                }
                else if (hit.collider.CompareTag("MarineButton"))
                {
                    Vector3 newPosition = new Vector3(-12.5f, -8f, 0f);
                    GameObject newMarine = Instantiate(marinePrefab, newPosition, Quaternion.identity);
                    newMarine.transform.parent = player1.transform;
                }
                else
                {
                    DoSomethingElse();
                }
            }
            else
            {
                DoSomethingElse();
            }
        }
    }
    void DoSomethingElse()
    {
        workerIcon.SetActive(false);
        marineIcon.SetActive(false);
    }
}