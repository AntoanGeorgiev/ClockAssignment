using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClockManager : MonoBehaviour
{
    [SerializeField] Transform hours;
    [SerializeField] Transform minutes;
    [SerializeField] Transform seconds;
    float hoursRotation = -30f, minutesRotation = -6f, secondsRotation = -6f; // 60 minutes and seconds so starting at -6f, 12 hours so starting -30f;
    bool a = true;
    public UnityEvent MonitorHM;
    void Awake()
    {
        DateTime time = DateTime.Now; // Retrieve the time on Awake
        hours.localRotation = Quaternion.Euler(0f, 0f, hoursRotation * time.Hour);
        minutes.localRotation = Quaternion.Euler(0f, 0f, minutesRotation * time.Minute);
        seconds.localRotation = Quaternion.Euler(0f, 0f, secondsRotation * time.Second);
    }
    void Update()
    {
        var time = DateTime.Now; // Keep updating the time every frame
        hours.localRotation = Quaternion.Euler(0f, 0f, hoursRotation * time.Hour);
        minutes.localRotation = Quaternion.Euler(0f, 0f, minutesRotation * time.Minute);
        seconds.localRotation = Quaternion.Euler(0f, 0f, secondsRotation * time.Second);
        if (minutes.rotation == hours.rotation && a) //If minute and hour are on top of each other
        {
            MonitorHM.Invoke();         
        }
    }
    IEnumerator TrackHoursMinutesAgain()
    {
        yield return new WaitForSeconds(60f); // We wait for a minute to avoid excessive event usage
        a = true;
    }

    public void WhenHMAlign() // Debug that the values align and reset the value of a;
    {
        Debug.Log("Hours and minutes align!");
        a = false;
        StartCoroutine(TrackHoursMinutesAgain());
    }
}
