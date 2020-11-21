using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WeaponPresenter : MonoBehaviour
{
    public WeaponUpgradeData weaponUpgradeData;
    public Image iconImage;
    public Image background;

    private Button _button;


    private void Awake()
    {
        Events.OnSelectWeapon += OnSelectWeapon;
    }

    private void OnSelectWeapon(WeaponUpgradeData data)
    {
        ChangeBackground(data);
    }

    private void OnDestroy()
    {
        Events.OnSelectWeapon -= OnSelectWeapon;
    }

    public void Start()
    {
        _button = GetComponent<Button>();
        if (_button != null)
        {
            _button.onClick.AddListener(Pressed);
        }

        if (weaponUpgradeData != null)
        {
            iconImage.sprite = weaponUpgradeData.sprite;
        }

        ChangeBackground(Events.GetSelectedWeaponData());
    }

    public void Pressed()
    {
        Events.SelectWeapon(weaponUpgradeData);
    }

    public void ChangeBackground(WeaponUpgradeData data)
    {
        background.color = data == weaponUpgradeData
            ? new Color(background.color.r, background.color.g, background.color.b, 1f)
            : new Color(background.color.r, background.color.g, background.color.b, 0.3f);
    }
}