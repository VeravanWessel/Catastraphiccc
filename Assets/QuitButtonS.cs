using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonS : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Application.Quit();
        } 
    }
}
