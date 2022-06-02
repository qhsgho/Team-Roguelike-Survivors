using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshMonsterSpawner : MonoBehaviour
{
    public Transform Player;
    public int monsterNum = 0;
    public GameObject monster1;
    public GameObject monster2;

    public GameObject[] pos;

    public void setRound()
    {
        monster1.GetComponent<cshMonstermove>().player = Player;
        monster2.GetComponent<cshMonstermove>().player = Player;

        switch (GameManager.instance.round)
        {
            case 1:
                monsterNum = 4;
                GameManager.instance.monsterCount = monsterNum;

                Instantiate(monster1, gameObject.GetComponent<Transform>());
                Instantiate(monster1, pos[0].GetComponent<Transform>());
                Instantiate(monster1, pos[1].GetComponent<Transform>());
                Instantiate(monster1, pos[2].GetComponent<Transform>());

                break;

            case 2:
                monsterNum = 8;
                GameManager.instance.monsterCount = monsterNum;

                Instantiate(monster1, gameObject.GetComponent<Transform>());
                Instantiate(monster1, pos[0].GetComponent<Transform>());
                Instantiate(monster1, pos[1].GetComponent<Transform>());
                Instantiate(monster1, pos[2].GetComponent<Transform>());
                Instantiate(monster1, gameObject.GetComponent<Transform>());
                Instantiate(monster1, pos[0].GetComponent<Transform>());
                Instantiate(monster1, pos[1].GetComponent<Transform>());
                Instantiate(monster1, pos[2].GetComponent<Transform>());

                break;

            case 3:
                monsterNum = 5;
                GameManager.instance.monsterCount = monsterNum;

                Instantiate(monster1, gameObject.GetComponent<Transform>());
                Instantiate(monster1, pos[0].GetComponent<Transform>());
                Instantiate(monster1, pos[1].GetComponent<Transform>());
                Instantiate(monster1, pos[2].GetComponent<Transform>());
                Instantiate(monster2, gameObject.GetComponent<Transform>());
                break;

            default:
            break;
        }
    }
}
