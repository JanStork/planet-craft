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
using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Player : MonoBehaviour
{
    public GameObject player1;
    public GameObject workerPrefab;
    public GameObject marinePrefab;
    public GameObject workerIcon;
    public GameObject marineIcon;
    public Text mineralsText;
    public static int Minerals;
    public GameObject inhibitorIcon;
    public static bool inhibitorActive = false;
    public GameObject barracksIcon;
    public static bool barracksActive = false;

    //PhotonView view;
    private void Start()
    {
        Minerals = 1000;
        workerIcon.SetActive(false);
        marineIcon.SetActive(false);
        //view = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (true)  //view.IsMine
        {
            if (Input.GetMouseButtonUp(0))
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
                        if (Minerals >= 25)
                        {
                            Minerals -= 25;
                            Vector3 newPosition = new Vector3(-22f, -10f, 0f);
                            GameObject newWorker = Instantiate(workerPrefab, newPosition, Quaternion.identity);
                            newWorker.transform.parent = player1.transform;
                        }
                        else
                        {
                            Debug.Log("Není dostatek minerálù");
                        }
                    }
                    else if (hit.collider.CompareTag("Barracks"))
                    {
                        workerIcon.SetActive(false);
                        marineIcon.SetActive(true);
                    }
                    else if (hit.collider.CompareTag("MarineButton"))
                    {
                        if (Minerals >= 75)
                        {
                            Minerals -= 75;
                            Vector3 newPosition = new Vector3(-12.5f, -8f, 0f);
                            GameObject newMarine = Instantiate(marinePrefab, newPosition, Quaternion.identity);
                            newMarine.transform.parent = player1.transform;
                        }
                        else
                        {
                            Debug.Log("Není dostatek minerálù");
                        }
                    }
                    else if (hit.collider.CompareTag("InhibitorButton"))
                    {
                        if (Minerals >= 500)
                        {
                            inhibitorActive = true;
                        }
                        else
                        {
                            Debug.Log("Nedostatek mineralu");
                        }
                    }
                    else if (hit.collider.CompareTag("BarracksButton"))
                    {
                        if (Minerals >= 250)
                        {
                            barracksActive = true;
                        }
                        else
                        {
                            Debug.Log("Nedostatek mineralu");
                        }
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
        mineralsText.text = "Minerals: " + Minerals;
        if (inhibitorActive)
        {
            MoveInhibitorIconWithCursor();
        }
        else
        {
            inhibitorIcon.transform.position = new Vector3(-50f, 25f, 0f);
        }
        if (barracksActive)
        {
            MoveBarracksIconWithCursor();
        }
        else
        {
            barracksIcon.transform.position = new Vector3(-50f, 25f, 0f);
        }
    }
    void DoSomethingElse()
    {
        workerIcon.SetActive(false);
        marineIcon.SetActive(false);
    }
    void MoveInhibitorIconWithCursor()
    {
        if (inhibitorIcon != null)
        {
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorPosition.z = 0f;
            inhibitorIcon.transform.position = cursorPosition;
        }
    }
    void MoveBarracksIconWithCursor()
    {
        if (barracksIcon != null)
        {
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorPosition.z = 0f;
            barracksIcon.transform.position = cursorPosition;
        }
    }
}