using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshSpeedNextText : MonoBehaviour
{
    public Text NextLevel;

    void Update()
    {
        if (GameManager.instance.speedLevel != 5)
        {
            int level = GameManager.instance.speedLevel + 1;
            NextLevel.text = "Speed Level " + level;
        }

        else
        {
            NextLevel.text = "최고 레벨입니다";
        }
    }
}
