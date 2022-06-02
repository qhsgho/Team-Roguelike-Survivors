using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshBuild1Event : MonoBehaviour
{
    public GameObject WeaponText;

    public void WeaponLevelUp()
    {
        GameManager.instance.OffBuildTime();
        WeaponText.SetActive(true);
    }
}
