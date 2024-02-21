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
    public GameObject workerPrefab;
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
                    workerIcon.SetActive(true);
                }
                /*else if (hit.collider.CompareTag("Baracks"))
                {
                    marineIcon.SetActive(true);
                }*/
                else if (hit.collider.CompareTag("WorkerButton")) // Pokud klikneme na UI
                {
                    // Zde mùžete zavolat metodu, která reaguje na kliknutí na tlaèítko
                    /*Button buttonClicked = hit.collider.GetComponent<Button>();
                    if (buttonClicked != null)
                    {
                        buttonClicked.onClick.Invoke();
                    }*/
                    Vector3 newPosition = new Vector3(-16f, -10f, 0f);
                    Instantiate(workerPrefab, newPosition, Quaternion.identity);
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