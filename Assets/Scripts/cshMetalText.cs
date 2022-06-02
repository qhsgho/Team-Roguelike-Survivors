using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshMetalText : MonoBehaviour
{
    public Text Metal;
    void Update()
    {
        Metal.text = GameManager.instance.metal.ToString();
    }
}
