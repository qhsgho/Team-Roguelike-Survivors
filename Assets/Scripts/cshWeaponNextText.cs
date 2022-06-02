using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshWeaponNextText : MonoBehaviour
{
    public Text NextLevel;

    void Update()
    {
        if(GameManager.instance.weaponLevel != 5)
        {
            int level = GameManager.instance.weaponLevel + 1;
            NextLevel.text = "Weapon Level " + level;
        }

        else
        {
            NextLevel.text = "최고 레벨입니다";
        }
    }
}
