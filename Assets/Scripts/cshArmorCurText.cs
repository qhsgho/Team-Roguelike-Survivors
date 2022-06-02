using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshArmorCurText : MonoBehaviour
{
    public Text CurLevel;

    void Update()
    {
        CurLevel.text = "Armor Level " + GameManager.instance.armorLevel;
    }
}
