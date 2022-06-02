using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshTurretPosition : MonoBehaviour
{
    public GameObject[] turretPos;
    public bool[] isTurret;
    public int position = 0;

    private void Awake()
    {
        isTurret = new bool[turretPos.Length];
    }

    public void TurretPositionSetup(int pos)
    {
        if(!isTurret[pos])
        {
            turretPos[pos].GetComponent<cshBuildTurret>().TurretSetup();
        }
        GameManager.instance.SelectTurretCamera(turretPos[pos]);
    }

    public void TurretPositionOff(int pos)
    {
        if (!isTurret[pos])
        {
            turretPos[pos].GetComponent<cshBuildTurret>().TurretOff();
        }
    }

    public void NextTurret()
    {
        TurretPositionOff(position);

        if (position != 3)
            position++;
        else
            position = 0;

        TurretPositionSetup(position);
    }

    public void PreviousTurret()
    {
        TurretPositionOff(position);

        if (position != 0)
            position--;
        else
            position = 3;

        TurretPositionSetup(position);
    }

    public void ChooseTurret()
    {
        isTurret[position] = true;
    }

    public bool CheckTurret()
    {
        return isTurret[position];
    }
}
