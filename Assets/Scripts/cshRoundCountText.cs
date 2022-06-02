using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshRoundCountText : MonoBehaviour
{
    public Text RoundCount;

    void Update()
    {
        RoundCount.text = "" + GameManager.instance.round;
    }
}
