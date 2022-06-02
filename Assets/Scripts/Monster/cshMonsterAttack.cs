using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshMonsterAttack : MonoBehaviour
{
    Animator anim;

    private cshAttackArea m_attackArea = null;

    void Start()
    {
        anim = GetComponent<Animator>();
        
       m_attackArea = GetComponentInChildren<cshAttackArea>();
    }


    void Update()
    {
        if (m_attackArea != null && (m_attackArea.colliders.Count > 0))
            anim.SetBool("ArmAttack", true);
        else if (m_attackArea != null && (m_attackArea.colliders.Count <= 0))
            anim.SetBool("ArmAttack", false);

    }


}
