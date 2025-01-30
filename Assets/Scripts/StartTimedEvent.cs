using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartTimedEvent : MonoBehaviour
{
    [SerializeField] float seconds = 5;
[SerializeField] UnityEvent unityEvent;

    float endTime=-1;

    public void StartTimer()
    {
endTime = Time.time + seconds;
}


    private void Update()
    {
        if (endTime>=0 && Time.time > endTime)
        {
unityEvent.Invoke();
endTime = float.PositiveInfinity;
}
}


}