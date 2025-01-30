using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToStartScene : MonoBehaviour
{
    public void GoToStart()
    {
        SceneManager.LoadScene("StartScene");
    }
}
