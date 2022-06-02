using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshBuild0Event : MonoBehaviour
{
    public GameObject Btn;

    public void BuildHeal()
    {
        if (GameManager.instance.curHealth + 50 >
            GameManager.instance.maxHealth)
        {
            GameManager.instance.curHealth = GameManager.instance.maxHealth;
        }

        else
        {
            GameManager.instance.curHealth += 50;
        }

    }
}
