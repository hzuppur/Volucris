using System;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    public WeaponUpgradeData weaponUpgradeData;

    private float _startY;

    public void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = weaponUpgradeData.sprite;
        _startY = gameObject.transform.position.y;
    }

    public void Update()
    {
        Vector3 gameObjPos = gameObject.transform.position;
        float newYpos = (float) (_startY + Math.Cos(Time.time * 4) / 4f);
        gameObject.transform.position = new Vector3(gameObjPos.x, newYpos, gameObjPos.z);
    }
}