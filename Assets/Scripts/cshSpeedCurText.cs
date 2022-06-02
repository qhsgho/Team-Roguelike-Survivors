using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshSpeedCurText : MonoBehaviour
{
    public Text CurLevel;

    void Update()
    {
        CurLevel.text = "Speed Level " + GameManager.instance.speedLevel;
    }
}
