using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RobotSpeakerMonitor : MonoBehaviour {

    [SerializeField]
    private GameObject EventSystem;

    public GameObject SpeakerCapsule;

    public GameObject SpeakerMonitor;

    public GameObject NoRobotInCapsule;

    [SerializeField]
    private string[] voiceTone;

    private int currentVoiceTone = 0;

    private string CommitedVoiceTone;

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
        if (currentVoiceTone < 2)
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
            currentVoiceTone = 2;
        }
    }

    public void CommitSpeaker()
    {
        if (SpeakerCapsule.GetComponent<BodySpawnLocation>().bodyInLocation == true)
        {
            CommitedVoiceTone = voiceTone[currentVoiceTone];
            EventSystem.GetComponent<RobotSpawner>().SpawnSpeaker();
        }
        else
        {
            SpeakerMonitor.SetActive(false);
            NoRobotInCapsule.SetActive(true);
        }
    }
}
