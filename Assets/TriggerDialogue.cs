using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerDialogue : MonoBehaviour
{
    public UnityEvent onTriggerEnter = new UnityEvent();
    public UnityEvent onTriggerExit = new UnityEvent();

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) onTriggerEnter.Invoke();
        Debug.Log("Enter");
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) onTriggerExit.Invoke();
        Debug.Log("Exit");
    }

      // void OnCollision2DEnter(Collider2D Collision2D)
    // {
    //     if (Collision2D.gameObject.CompareTag("Player")) onCollision2DEnter.Invoke();
    //     Debug.Log("Enter");
    // }

    // void OnCollision2DExit(Collider2D Collision2D)
    // {
    //     if (Collision2D.gameObject.CompareTag("Player")) onCollision2DExit.Invoke();
    //     Debug.Log("Exit");
    // }
}
