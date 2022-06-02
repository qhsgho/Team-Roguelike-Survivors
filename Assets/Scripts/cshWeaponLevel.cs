using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshWeaponLevel : MonoBehaviour
{
    public GameObject ConfirmBtn;
    public GameObject CancelBtn;

    public void PressedConfirmBtn()
    {
        if(GameManager.instance.weaponLevel != 5 && GameManager.instance.coin >= 2)
        {
            GameManager.instance.coin -= 2;
            GameManager.instance.weaponLevel++;
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
