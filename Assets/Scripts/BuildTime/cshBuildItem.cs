using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshBuildItem : MonoBehaviour
{
    public GameObject[] items;
    public int itemNumber = -1;

    public void SetItemNumber(int number)
    {

        itemNumber = number;
        items[itemNumber].gameObject.SetActive(true);
    }
}
