using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CrowbarTimer : MonoBehaviour {

    private int seconds = 5;
    private int miliseconds;
    public GameObject CrowbarScreen;

    public Text timer;

    public void Reset()
    {
        seconds = 5;
        miliseconds = 0;

        timer.text = "5";
    }

    public void StartTimer()
    {
        StartCoroutine(RunTimer());
    }

    public void EndTimer()
    {
        StopCoroutine(RunTimer());
        Reset();
        CrowbarScreen.SetActive(false);
        
    }

    private IEnumerator RunTimer()
    {
        while(seconds >= 1)
        {
            yield return new WaitForSeconds(1);
            seconds--;
            timer.text = seconds.ToString();
        }
        
        if (seconds ==  0)
        {
            EndTimer();
        }
    }
}
