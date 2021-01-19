using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine;

public class Door : MonoBehaviour
{

    private float _startY;
    // Start is called before the first frame update
    public void Start()
    {
        _startY = gameObject.transform.position.y;
    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 gameObjPos = gameObject.transform.position;
        float newYpos = (float) (_startY + Math.Cos(Time.time * 4) / 4f);
        gameObject.transform.position = new Vector3(gameObjPos.x, newYpos, gameObjPos.z);
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            Events.DoorOpened(transform.parent.gameObject.name);
            Destroy(this.transform.parent.gameObject);
        }
    }
}
