using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class cshSetvolume : MonoBehaviour
{
    public AudioSource bgmsource;

    public AudioSource btnsource;
    public AudioSource coinsource;
    public AudioSource metalsource;
    public AudioSource healsource;
    public AudioSource energysource;

    public AudioSource bulletsource;
    public AudioSource clearsource;


    public void SetBgm(float volume)
    {
        bgmsource.volume = volume;
    }

    public void SetSfx(float volume)
    {
        btnsource.volume = volume;
        coinsource.volume = volume;
        metalsource.volume = volume;
        healsource.volume = volume;
        energysource.volume = volume;

        bulletsource.volume = volume; 
        clearsource.volume = volume;
    }

    public void OnSfx()
    {
        btnsource.Play();
    }
}
