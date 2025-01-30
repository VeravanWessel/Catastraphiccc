using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonS : MonoBehaviour
{
    public GameObject menu;
    public GameObject video;
    public GameObject eyes;
    public StartTimedEvent timerscript;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            video.SetActive(true);
            menu.SetActive(false);
            eyes.SetActive(false);
            timerscript.StartTimer();
        } 
    }
}
