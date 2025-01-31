using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonS : MonoBehaviour
{
    public GameObject menu;
    public GameObject video;
    public GameObject eyes;
    public StartTimedEvent timerscript;
    public GameObject audiostop;

    public void Play()
    {
            video.SetActive(true);
            menu.SetActive(false);
            eyes.SetActive(false);
            audiostop.SetActive(false);
            timerscript.StartTimer();
    }
}
