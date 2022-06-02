using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshGameOverRoundText : MonoBehaviour
{
    public Text Round;

    void Update()
    {
        Round.text = "현재 라운드 : " + GameManager.instance.round;
    }
}
