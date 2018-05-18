using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

	// Use this for initialization
	void Awake () {

        foreach (Sound s in sounds)
        {
           s.source = s.SourceOfSound.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.spatialBlend = s.spatialBlend;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
		
	}

    private void Start()
    {
        //Play("Introduction");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Play();
    }

    
}
