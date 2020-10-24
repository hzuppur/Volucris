using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    private void Awake()
    {
        Events.OnGetPlayerPos += OnGetPlayerPos;
    }

    private Transform OnGetPlayerPos()
    {
        return transform;
    }
}
