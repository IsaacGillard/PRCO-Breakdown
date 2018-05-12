using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PersonalityMonitor : MonoBehaviour {

    [SerializeField]
    private GameObject EventSystem;

    [SerializeField]
    private GameObject PersonalityMonitorScreen;

    [SerializeField]
    private GameObject PersonalityCapsule;

    [SerializeField]
    private GameObject NoRobotInCapsule;


    [SerializeField]
    private string[] Personality;

    private int currentPersonality = 0;

    private string CommitedPersonality;

    public TextMeshProUGUI PersonalityValue;

    private void OnEnable()
    {
        NoRobotInCapsule.SetActive(false);
    }

    void Update()
    {
        PersonalityValue.text = Personality[currentPersonality].ToString();
    }

    public void IncreasePersonality()
    {
        if (currentPersonality < 2)
        {
            currentPersonality++;
        }
        else
        {
            currentPersonality = 0;
        }
    }

    public void DecreasePersonality()
    {
        if (currentPersonality > 0)
        {
            currentPersonality--;
        }
        else
        {
            currentPersonality = 2;
        }
    }

    public void CommitPersonality()
    {
        if (PersonalityCapsule.GetComponent<LevelFourSpawner>().bodyInLocation == true)
        {
            CommitedPersonality = Personality[currentPersonality];
            EventSystem.GetComponent<RobotSpawnerLevelFour>().RobotTraits[0] = CommitedPersonality;
            EventSystem.GetComponent<RobotSpawnerLevelFour>().SpawnPaintJob();
        }
        else
        {
            PersonalityMonitorScreen.SetActive(false);
            NoRobotInCapsule.SetActive(true);
        }
    }
}
