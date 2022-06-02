using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshHpText : MonoBehaviour
{
    public Text Hp;

    void Update()
    {
        Hp.text = GameManager.instance.curHealth + " / " + GameManager.instance.maxHealth;
    }
}
