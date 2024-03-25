using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhibitorScript : MonoBehaviour
{
    private double HP = 1500;
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject, 0f);
        }
    }
}
