using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshSetBack : MonoBehaviour
{
    public GameObject backbutton;
    public void setOnBackButton()
    {
        backbutton.SetActive(false);
    }
}
