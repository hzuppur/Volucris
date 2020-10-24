using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    public static event Func<Transform> OnGetPlayerPos;
    public static Transform GetPlayerPos() => OnGetPlayerPos?.Invoke();
    
}
