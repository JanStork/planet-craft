using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public float rychlostPohybu = 8f;
    public float zrychleni = 8f;
    void Update()
    {
        // Z�sk�n� vstupu od hr��e
        float horizont�ln�Input = Input.GetAxis("Horizontal");
        float vertik�ln�Input = Input.GetAxis("Vertical");
        float rychlost = rychlostPohybu;

        // Zrychlen� p�i dr�en� kl�vesy Shift
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            rychlost *= zrychleni;
        }

        // Pohyb kamery podle kl�ves
        Vector3 pohyb = new Vector3(horizont�ln�Input, vertik�ln�Input, 0f) * rychlost * Time.deltaTime;
        transform.Translate(pohyb);
    }
}