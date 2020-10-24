using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEvents : MonoBehaviour
{
    private void Awake()
    {
        Events.OnGetCameraPos += OnGetCameraPos;
    }
    
    private void OnDestroy()
    {
        Events.OnGetCameraPos -= OnGetCameraPos;
    }

    private Transform OnGetCameraPos()
    {
        return transform;
    }
}
