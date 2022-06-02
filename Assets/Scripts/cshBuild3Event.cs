using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshBuild3Event : MonoBehaviour
{
    public GameObject StatusText;

    public void WeaponLevelUp()
    {
        GameManager.instance.OffBuildTime();
        StatusText.SetActive(true);
    }
}
