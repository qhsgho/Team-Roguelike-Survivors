using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshBuild2Event : MonoBehaviour
{
    public GameObject Btn;
    public GameObject TurretPositon;
    public GameObject TurretBtn;

    public void BuildTurret()
    {
        GameManager.instance.OffPlayerCamera();
        GameManager.instance.OnTurretCamera();
        TurretBtn.SetActive(true);

        GameManager.instance.OffBuildTime();
        TurretPositon.GetComponent<cshTurretPosition>().TurretPositionSetup(0);
    }
}
