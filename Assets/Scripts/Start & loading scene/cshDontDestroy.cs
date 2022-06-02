using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshDontDestroy : MonoBehaviour
{
    private void Awake()
    {
        var obj = FindObjectsOfType<cshDontDestroy>();
        if(obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
