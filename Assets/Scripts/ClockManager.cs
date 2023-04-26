using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
    [SerializeField] Transform hours;
    [SerializeField] Transform minutes;
    [SerializeField] Transform seconds;
    float hoursRotation = -30f, minutesRotation = -6f, secondsRotation = -6f;
    bool a = true;
    void Awake()
    {
        DateTime time = DateTime.Now;
        hours.localRotation = Quaternion.Euler(0f, 0f, hoursRotation * time.Hour);
        minutes.localRotation = Quaternion.Euler(0f, 0f, minutesRotation * time.Minute);
        seconds.localRotation = Quaternion.Euler(0f, 0f, secondsRotation * time.Second);
    }
    void Update()
    {
        var time = DateTime.Now;
        hours.localRotation = Quaternion.Euler(0f, 0f, hoursRotation * time.Hour);
        minutes.localRotation = Quaternion.Euler(0f, 0f, minutesRotation * time.Minute);
        seconds.localRotation = Quaternion.Euler(0f, 0f, secondsRotation * time.Second);
        if (minutes.rotation == hours.rotation && a)
        {
            Debug.Log("Hours and minutes align!");
            a = false;
            StartCoroutine(TrackHoursMinutesAgain());
        }
    }
    IEnumerator TrackHoursMinutesAgain()
    {
        yield return new WaitForSeconds(61f);
        a = true;
    }
}
