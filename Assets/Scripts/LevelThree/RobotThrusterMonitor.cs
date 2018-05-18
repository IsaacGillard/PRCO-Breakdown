using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RobotThrusterMonitor : MonoBehaviour {

    [SerializeField]
    private GameObject AudioManager;

    [SerializeField]
    private GameObject EventSystem;

    public GameObject ThrusterCapsule;

    public GameObject ThrusterMonitor;

    public GameObject NoRobotInCapsule;

    [SerializeField]
    private int[] thrusterPower;

    private int currentThusterPower = 0;

    private int CommitedThrusterPower;

    public TextMeshProUGUI ThrusterPowerValue;

    private void OnEnable()
    {
        NoRobotInCapsule.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {

        ThrusterPowerValue.text = thrusterPower[currentThusterPower].ToString();

    }

    public void IncreaseThrusterPower()
    {
        if (currentThusterPower < 2)
        {
            currentThusterPower++;
        }
        else
        {
            currentThusterPower = 0;
        }
    }

    public void DecreaseThrusterPower()
    {
        if (currentThusterPower > 0)
        {
            currentThusterPower--;
        }
        else
        {
            currentThusterPower = 2;
        }
    }

    public void CommitThruster()
    {
        if (ThrusterCapsule.GetComponent<BodySpawnLocation>().bodyInLocation == true)
        {
            AudioManager.GetComponent<AudioManager>().Play("Drill");
            Debug.Log("committed");
            CommitedThrusterPower = thrusterPower[currentThusterPower];
            EventSystem.GetComponent<RobotSpawner>().completedRobotStatistics[2] = CommitedThrusterPower;
            EventSystem.GetComponent<RobotSpawner>().SpawnThruster();
            EventSystem.GetComponent<LevelProgression>().UpdateProgression();
        }
        else
        {
            Debug.Log("committed failed");
            ThrusterMonitor.SetActive(false);
            NoRobotInCapsule.SetActive(true);
        }
    }
}
