using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject Player;
    public GameObject BuildTime;
    public GameObject Clear;
    public GameObject RoundText;
    public GameObject CountText;
    public GameObject MonsterSpawner;
    public GameObject PlayerCamera1;
    public GameObject TurretCamera;
    public GameObject GameOverObject;
    public GameObject StartRoundText;

    private GameObject PlayerCamera;

    AudioSource clearsource;

    private Vector3 playerPos;

    public float maxHealth = 100f;
    public float curHealth = 100f;

    public float moveSpeed = 5f;

    public int weaponLevel = 1;
    public int armorLevel = 1;
    public int speedLevel = 1;

    public int attackAmount = 1;
    public float attackArea = 0f;
    public float attackSpeed = 1000f;
    public float attackInterval = 2.0f;

    public bool dodge = false;
    public bool hasWeapon = true;

    public int round = 1;
    public int monsterCount = -1;

    public int coin = 0;
    public int metal = 0;

    public int itemDropInWorld = 0;

    private bool onRound = false;

    public float playerDmg = 5.0f;
    public float TurretDmg = 10.0f;

    private float roundSpeed;

    bool rDown;

    private void Awake()
    {
        GameObject cv = GameObject.Find("AudioSource").transform.Find("ClearSource").gameObject;
        clearsource = cv.GetComponent<AudioSource>();
        instance = this;
        playerPos = Player.GetComponent<Transform>().position;
        PlayerCamera = PlayerCamera1;
        GameStart();
    }

    private void Update()
    {
        if(onRound && monsterCount == 0 && itemDropInWorld == 0)
        {
            RoundClear();
            RoundText.SetActive(false);
            CountText.SetActive(false);
            onRound = false;
            monsterCount = -1;
        }

        if(curHealth <= 0)
        {
            GameOver();
        }

        if(onRound)
        {
            monsterCount = GameObject.FindGameObjectsWithTag("Monster").Length;
        }

    }

    void GameStart()
    {
        RoundStart();
    }

    public void RoundStart()
    {
        StartRoundText.SetActive(true);
        Invoke("RoundSpawn", 3f);
    }

    public void RoundSpawn()
    {
        MonsterSpawner.SetActive(true);
        StartRoundText.SetActive(false);
        Player.GetComponent<Transform>().position = playerPos;
        Player.SetActive(true);
        Player.GetComponent<cshPlayerMovement>().StartShooting();
        RoundText.SetActive(true);
        CountText.SetActive(true);
        MonsterSpawner.GetComponent<cshMonsterSpawner>().setRound();
        onRound = true;

        moveSpeed = moveSpeed + (0.5f * speedLevel);
        roundSpeed = moveSpeed;
    }

    void RoundClear()
    {
        MonsterSpawner.SetActive(false);
        round++;
        Clear.SetActive(true);
        clearsource.Play();
        Invoke("HideClear", 1f);
    }

    void HideClear()
    {
        Clear.SetActive(false);

        if (round == 4)
        {
            GameOver();
        }

        else
        {
            StartBuildTime();
        }
    }

    void StartBuildTime()
    {
        Player.GetComponent<cshPlayerMovement>().StopShooting();
        Player.SetActive(false);
        BuildTime.SetActive(true);
    }

    public void EndBuildTime()
    {
        BuildTime.SetActive(false);
        RoundStart();
    }

    public void GetEnergyItem()
    {
        moveSpeed *= 1.5f;
        Invoke("BringBackSpeed", 5f);
    }

    void BringBackSpeed()
    {
        moveSpeed = roundSpeed;
    }

    public void OnPlayerCamera()
    {
        PlayerCamera.SetActive(true);
    }

    public void OffPlayerCamera()
    {
        PlayerCamera.SetActive(false);
    }

    public void OnTurretCamera()
    {
        TurretCamera.SetActive(true);
    }

    public void OffTurretCamera()
    {
        TurretCamera.SetActive(false);
    }

    public void SelectTurretCamera(GameObject turret)
    {
        TurretCamera.GetComponent<cshCameraTurretFollow>().target
            = turret.GetComponent<Transform>();
    }

    public void OnBuildTime()
    {
        BuildTime.SetActive(true);
    }

    public void OffBuildTime()
    {
        BuildTime.SetActive(false);
    }

    public void GameOver()
    {
        Player.GetComponent<cshPlayerMovement>().StopShooting();
        Player.SetActive(false);
        GameOverObject.SetActive(true);

        Invoke("ReturnToTitle", 3);
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("StartScene");
    }

}
