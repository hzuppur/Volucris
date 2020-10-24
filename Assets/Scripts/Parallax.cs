using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject cam;
    public float parallaxEffect;
    public float parallaxEffectY;
    
    private float _lenght, _startposX, _startposY;

    void Start()
    {
        _startposX = transform.position.x;
        _startposY = transform.position.y;
        _lenght = 0;
    }

    void Update()
    {
        var position = cam.transform.position;
        float tempX = position.x * (1 - parallaxEffect);
        float distX = position.x * parallaxEffect;
        float tempY = position.y * (1 - parallaxEffectY);
        float distY = position.y * parallaxEffectY;

        var position1 = transform.position;
        position1 = new Vector3(_startposX + distX, _startposY + distY, position1.z);
        transform.position = position1;

        if (tempX > _startposX + _lenght) _startposX += _lenght;
        else if (tempX < _startposX - _lenght) _startposX -= _lenght;
    }
}
