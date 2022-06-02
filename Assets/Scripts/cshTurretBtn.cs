using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshTurretBtn : MonoBehaviour
{
    public GameObject ConfirmBtn;
    public GameObject CancelBtn;
    public GameObject TurretPosition;

    public void PressedConfirmBtn()
    {
        if(!TurretPosition.GetComponent<cshTurretPosition>().CheckTurret() && GameManager.instance.metal >= 1)
        {
            GameManager.instance.metal -= 1;
            TurretPosition.GetComponent<cshTurretPosition>().ChooseTurret();
            GameManager.instance.OnPlayerCamera();
            GameManager.instance.OffTurretCamera();
            GameManager.instance.RoundStart();
            gameObject.SetActive(false);
        }
    }

    public void PressedCancelBtn()
    {
        TurretPosition.GetComponent<cshTurretPosition>().TurretPositionOff(TurretPosition.GetComponent<cshTurretPosition>().position);
        GameManager.instance.OnPlayerCamera();
        GameManager.instance.OffTurretCamera();
        GameManager.instance.OnBuildTime();
        gameObject.SetActive(false);
    }
}
