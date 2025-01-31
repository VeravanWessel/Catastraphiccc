using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndVideoScript : MonoBehaviour
{
    [SerializeField] private UnityEngine.Video.VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,"Outro.mp4"); 
    }
}
