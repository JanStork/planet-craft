using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksScript : MonoBehaviour
{
    private double HP = 1000;
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject, 0f);
        }
    }
}