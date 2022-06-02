using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshHpProgress : MonoBehaviour
{
    public Image img;

    void Update()
    {
        img.fillAmount = GameManager.instance.curHealth / GameManager.instance.maxHealth;
    }
}
