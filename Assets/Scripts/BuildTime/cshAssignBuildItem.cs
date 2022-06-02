using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshAssignBuildItem : MonoBehaviour
{
    public int[] itemNumber = new int[4];
    public GameObject[] Btn_pos = new GameObject[4];

    void Awake()
    {
        /*
        아이템 랜덤 요소
        RandomItems(itemNumber);
        Btn_pos[0].GetComponent<cshBuildItem>().SetItemNumber(itemNumber[0]);
        Btn_pos[1].GetComponent<cshBuildItem>().SetItemNumber(itemNumber[1]);
        Btn_pos[2].GetComponent<cshBuildItem>().SetItemNumber(itemNumber[2]);
        Btn_pos[3].GetComponent<cshBuildItem>().SetItemNumber(itemNumber[3]);
        */

        Btn_pos[0].GetComponent<cshBuildItem>().SetItemNumber(0);
        Btn_pos[1].GetComponent<cshBuildItem>().SetItemNumber(1);
        Btn_pos[2].GetComponent<cshBuildItem>().SetItemNumber(3);
        Btn_pos[3].GetComponent<cshBuildItem>().SetItemNumber(2);
    }

    void RandomItems(int[] items)
    {
        int i = 0;
        while(i < 4)
        {
            items[i] = Random.Range(0, 4);

            if(i != 0)
            {
                for(int j = 0; j < i; j++)
                {
                    if (items[i] == items[j])
                    {
                        items[i] = -1;
                        break;
                    }
                }

                if(items[i] != -1)
                {
                    i++;
                }
            }

            else
            {
                i++;
            }
        }
    }
}
