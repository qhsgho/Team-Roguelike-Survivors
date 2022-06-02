using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshMonsterCountText : MonoBehaviour
{
    public Text MonsterCount;

    void Update()
    {
        MonsterCount.text = "" + GameManager.instance.monsterCount;
    }
}
