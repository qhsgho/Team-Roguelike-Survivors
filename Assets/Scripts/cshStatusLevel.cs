using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshStatusLevel : MonoBehaviour
{
    public GameObject ArmorConfirmBtn;
    public GameObject SpeedConfirmBtn;
    public GameObject CancelBtn;

    public void PressedArmorConfirmBtn()
    {
        if (GameManager.instance.armorLevel != 5 && GameManager.instance.coin >= 1)
        {
            GameManager.instance.coin -= 1;
            GameManager.instance.armorLevel++;
            GameManager.instance.RoundStart();
            gameObject.SetActive(false);
        }
    }

    public void PressedSpeedConfirmBtn()
    {
        if (GameManager.instance.speedLevel != 5 && GameManager.instance.coin >= 1)
        {
            GameManager.instance.coin -= 1;
            GameManager.instance.speedLevel++;
            GameManager.instance.RoundStart();
            gameObject.SetActive(false);
        }
    }

    public void PressedCancelBtn()
    {
        GameManager.instance.OnBuildTime();
        gameObject.SetActive(false);
    }
}
