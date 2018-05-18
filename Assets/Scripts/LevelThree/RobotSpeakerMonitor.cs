using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RobotSpeakerMonitor : MonoBehaviour {

    [SerializeField]
    private GameObject AudioManager;

    [SerializeField]
    private GameObject EventSystem;

    public GameObject SpeakerCapsule;

    public GameObject SpeakerMonitor;

    public GameObject NoRobotInCapsule;

    [SerializeField]
    private string[] voiceTone;

    private int currentVoiceTone = 0;

    private int CommitedVoiceTone;

    public TextMeshProUGUI VoiceToneValue;

    private void OnEnable()
    {
        NoRobotInCapsule.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {

        VoiceToneValue.text = voiceTone[currentVoiceTone].ToString();

    }

    public void IncreaseVoiceTone()
    {
        if (currentVoiceTone < 3)
        {
            currentVoiceTone++;
        }
        else
        {
            currentVoiceTone = 0;
        }
    }

    public void DecreaseVoiceTone()
    {
        if (currentVoiceTone > 0)
        {
            currentVoiceTone--;
        }
        else
        {
            currentVoiceTone = 3;
        }
    }

    public void CommitSpeaker()
    {
        if (SpeakerCapsule.GetComponent<BodySpawnLocation>().bodyInLocation == true)
        {
            AudioManager.GetComponent<AudioManager>().Play("Drill");
            CommitedVoiceTone = currentVoiceTone;
            EventSystem.GetComponent<RobotSpawner>().completedRobotStatistics[1] = CommitedVoiceTone;
            EventSystem.GetComponent<RobotSpawner>().SpawnSpeaker();
        }
        else
        {
            SpeakerMonitor.SetActive(false);
            NoRobotInCapsule.SetActive(true);
        }
    }
}
