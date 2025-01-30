using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimedEvent : MonoBehaviour
{
    [SerializeField] float seconds = 5;
[SerializeField] UnityEvent unityEvent;

    float endTime;

    private void Start()
    {
endTime = Time.time + seconds;
}

    private void Update()
    {
        if (Time.time > endTime)
        {
unityEvent.Invoke();
endTime = float.PositiveInfinity;
}
}


}