using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PaintJobMonitor : MonoBehaviour {

    [SerializeField]
    private GameObject EventSystem;

    [SerializeField]
    private GameObject PaintJobMonitorScreen;

    [SerializeField]
    private GameObject PaintJobCapsule;

    [SerializeField]
    private GameObject NoRobotInCapsule;


    [SerializeField]
    private string[] PaintJob;

    private int currentPaintJob = 0;

    private string CommitedPaintJob;

    public TextMeshProUGUI PaintJobValue;

    private void OnEnable()
    {
        NoRobotInCapsule.SetActive(false);
    }

    void Update()
    {
        PaintJobValue.text = PaintJob[currentPaintJob].ToString();
    }

    public void IncreasePaintJob()
    {
        if (currentPaintJob < 3)
        {
            currentPaintJob++;
        }
        else
        {
            currentPaintJob = 0;
        }
    }

    public void DecreasePaintJob()
    {
        if (currentPaintJob > 0)
        {
            currentPaintJob--;
        }
        else
        {
            currentPaintJob = 3;
        }
    }

    public void CommitPaintJob()
    {
        // commit current paint job and add value to finished robots statistics
        if (PaintJobCapsule.GetComponent<LevelFourSpawner>().bodyInLocation == true)
        {
            CommitedPaintJob = PaintJob[currentPaintJob];
            EventSystem.GetComponent<RobotSpawnerLevelFour>().RobotTraits[1] = CommitedPaintJob;
            EventSystem.GetComponent<RobotSpawnerLevelFour>().SpawnCompletedRobot(currentPaintJob);
        }
        else
        {
            PaintJobMonitorScreen.SetActive(false);
            NoRobotInCapsule.SetActive(true);
        }
    }
}
