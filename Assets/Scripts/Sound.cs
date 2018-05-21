using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound {

    // sound class to be used with audio manager

    public string name;

    public GameObject SourceOfSound;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(-3f, 3f)]
    public float pitch;
    [Range(0f, 1f)]
    public float spatialBlend;

    public bool loop;

    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;
}
