﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupervisorOpinion : MonoBehaviour {

    [SerializeField]
    private Slider OpinionMeter;

    public void ReduceOpinion(int amount)
    {
        OpinionMeter.value -= amount;
    }

    private void ZeroOpinion()
    {

    }

	
}
