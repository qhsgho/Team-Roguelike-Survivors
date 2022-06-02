using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshWeaponCurText : MonoBehaviour
{
    public Text CurLevel;

    void Update()
    {
        CurLevel.text = "Weapon Level " + GameManager.instance.weaponLevel;
    }
}
