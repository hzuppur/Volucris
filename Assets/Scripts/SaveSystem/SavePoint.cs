using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public AudioClipGroup _sound;
    public void Play()
    {
        _sound.Play();
    }
}
