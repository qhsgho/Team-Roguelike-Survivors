using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshBuildTurret : MonoBehaviour
{
    public GameObject Turret1;

    public void TurretSetup()
    {
        Turret1.SetActive(true);
    }

    public void TurretOff()
    {
        Turret1.SetActive(false);
    }
}
