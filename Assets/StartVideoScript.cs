using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVideoScript : MonoBehaviour
{
    [SerializeField] private UnityEngine.Video.VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,"Intro.mp4"); 
    }
}
