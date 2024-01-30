using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vsechno : MonoBehaviour
{
    public GameObject menuScreen;
    public void Exit()
    {
        Application.Quit();
    }
    public void Play()
    {
        menuScreen.SetActive(false);
    }
}
