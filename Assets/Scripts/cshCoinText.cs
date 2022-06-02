using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshCoinText : MonoBehaviour
{
    public Text Coin;
    void Update()
    {
        Coin.text = GameManager.instance.coin.ToString();
    }
}
