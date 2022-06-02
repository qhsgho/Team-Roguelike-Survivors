using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshBtnVolume : MonoBehaviour
{
    AudioSource btnsource;

    void Awake()
    {
        GameObject btn = GameObject.Find("AudioSource").transform.Find("BtnSource").gameObject;
        btnsource = btn.GetComponent<AudioSource>();
    }
    public void OnSfx()
    {
        
        btnsource.Play();
    }
}
