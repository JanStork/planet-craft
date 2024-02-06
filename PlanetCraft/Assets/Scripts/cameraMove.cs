using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public float rychlostPohybu = 8f;
    public float zrychleni = 8f;
    void Update()
    {
        float horizontálníInput = Input.GetAxis("Horizontal");
        float vertikálníInput = Input.GetAxis("Vertical");
        float rychlost = rychlostPohybu;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            rychlost *= zrychleni;
        }
        Vector3 pohyb = new Vector3(horizontálníInput, vertikálníInput, 0f) * rychlost * Time.deltaTime;
        transform.Translate(pohyb);
    }
}