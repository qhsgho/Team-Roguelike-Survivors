using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshArmorNextText : MonoBehaviour
{
    public Text NextLevel;

    void Update()
    {
        if (GameManager.instance.armorLevel != 5)
        {
            int level = GameManager.instance.armorLevel + 1;
            NextLevel.text = "Armor Level " + level;
        }

        else
        {
            NextLevel.text = "최고 레벨입니다";
        }
    }
}
