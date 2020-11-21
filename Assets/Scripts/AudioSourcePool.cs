using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourcePool : MonoBehaviour
{
    public static AudioSourcePool Instance;
    
    public AudioSource AudioSourcePrefab;

    private List<AudioSource> _audioSources;

    private void Awake()
    {
        Instance = this;
        _audioSources = new List<AudioSource>();
    }

    public AudioSource GetSource()
    {
        foreach (AudioSource source in _audioSources)
        {
            if (!source.isPlaying)
            {
                return source;
            }
        }

        AudioSource newSource = Instantiate(AudioSourcePrefab, transform);
        _audioSources.Add(newSource);
        return newSource;
    }
}
