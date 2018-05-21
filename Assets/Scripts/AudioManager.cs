using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

	void Awake () {
        
        // for each sound in the audio manager, add variables to inspector
        foreach (Sound s in sounds)
        {
           s.source = s.SourceOfSound.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.spatialBlend = s.spatialBlend;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
		
	}

    private void Start()
    {
        Play("Introduction"); 
    }

    public void Play (string name)
    {
        // play the sound
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        if (s == null)
        {
            Debug.Log("No sound found");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        // stop the sound
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Stop();
    }


}
