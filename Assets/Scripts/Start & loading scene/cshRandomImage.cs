using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshRandomImage : MonoBehaviour
{
    public Image rndimage;

    public Sprite Image0;
    public Sprite Image1;
    public Sprite Image2;

    public int Rnd;

    void Start()
    {
        Imagerandom();
    }

    void Imagerandom()
    {
        Rnd = Random.Range(0, 3);
        if (Rnd == 0)
        {
            rndimage.sprite = Image0;
        }
        else if (Rnd == 1)
        {
            rndimage.sprite = Image1;
        }
        else if (Rnd == 2)
        {
            rndimage.sprite = Image2;
        }

        Invoke("Imagerandom", 4f);
    }
}
