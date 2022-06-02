using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshDestroyObj : MonoBehaviour
{
    public float deleteTime = 3.0f;

    void Start()
    {
        Destroy(gameObject, deleteTime); 
    }
}
