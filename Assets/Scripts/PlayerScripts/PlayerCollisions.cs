using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.name == "MapBottom")
        {
            gameObject.SetActive(false);
            Events.PlayerDeath();
        }else if (other.collider.gameObject.name == "WinLocation")
        {
            Events.PlayerWin();
        }
    }
}
