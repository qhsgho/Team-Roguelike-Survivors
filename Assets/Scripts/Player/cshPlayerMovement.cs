using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshPlayerMovement : MonoBehaviour
{
    public GameObject bulletSpawner;
    public GameObject bullet;


    AudioSource CoinSource;
    AudioSource MetalSource;
    AudioSource HealSource;
    AudioSource EnergySource;
    AudioSource Bulletsource;

    private float pastSpeed;

    float hAxis;
    float vAxis;

    bool dDown;
    bool isDodge;

    Vector3 moveVec;
    Vector3 dodgeVec;

    Animator anim;

    Rigidbody rigid;


    private void Awake()
    {
        sfx();
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void sfx()
    {
        GameObject coinsource = GameObject.Find("AudioSource").transform.Find("CoinSource").gameObject;
        GameObject metalsource = GameObject.Find("AudioSource").transform.Find("MetalSource").gameObject;
        GameObject healsource = GameObject.Find("AudioSource").transform.Find("HealSource").gameObject;
        GameObject energysource = GameObject.Find("AudioSource").transform.Find("EnergySource").gameObject;
        GameObject bulletvolme = GameObject.Find("AudioSource").transform.Find("BulletSource").gameObject;
        
        CoinSource = coinsource.GetComponent<AudioSource>();
        MetalSource = metalsource.GetComponent<AudioSource>();
        HealSource = healsource.GetComponent<AudioSource>();
        EnergySource = energysource.GetComponent<AudioSource>();
        Bulletsource = bulletvolme.GetComponent<AudioSource>();
    }

    void Update()
    {
        GetInput();
        Move();
        Turn();
        Dodge();
        CheckWeapon();
        SetWorldRange();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        dDown = Input.GetButtonDown("Dodge");
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        if (isDodge)
            moveVec = dodgeVec;

        transform.position += moveVec * GameManager.instance.moveSpeed * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);
    }

    void SetWorldRange()
    {
        transform.position
        = new Vector3(Mathf.Clamp(transform.position.x, -75f, 75f), 
        Mathf.Clamp(transform.position.y, 0, 5f) ,
        Mathf.Clamp(transform.position.z, -75f, 75f));
    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }

    void Dodge()
    {
        if (dDown && moveVec != Vector3.zero && !isDodge)
        {
            dodgeVec = moveVec;
            pastSpeed = GameManager.instance.moveSpeed;
            GameManager.instance.moveSpeed *= 1.2f;

            anim.SetTrigger("doDodge");
            isDodge = true;

            Invoke("DodgeOut", 0.9f);
        }
    }

    void DodgeOut()
    {
        GameManager.instance.moveSpeed = pastSpeed;
        isDodge = false;
    }

    void CheckWeapon()
    {
        anim.SetBool("hasWeapon", GameManager.instance.hasWeapon);
    }

    public void StartShooting()
    {
        InvokeRepeating("Shot", 1, GameManager.instance.attackInterval);
    }

    public void StopShooting()
    {
        CancelInvoke("Shot");
    }

    void Shot()
    {
        Bulletsource.Play();
        if (GameManager.instance.hasWeapon && !isDodge)
        {
            bullet.GetComponent<cshBullet>().bulletSpeed = GameManager.instance.attackSpeed;

            switch (GameManager.instance.weaponLevel)
            {
                case 1:
                    Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                    break;

                case 2:
                    Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                    Invoke("ShotTwice", 0.2f);
                    break;

                case 3:
                    Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);

                    bulletSpawner.transform.Rotate(new Vector3(0, 10, 0));
                    Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                    bulletSpawner.transform.Rotate(new Vector3(0, -10, 0));

                    bulletSpawner.transform.Rotate(new Vector3(0, -10, 0));
                    Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                    bulletSpawner.transform.Rotate(new Vector3(0, 10, 0));
                    break;

                case 4:
                    Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);

                    bulletSpawner.transform.Rotate(new Vector3(0, 10, 0));
                    Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                    bulletSpawner.transform.Rotate(new Vector3(0, -10, 0));

                    bulletSpawner.transform.Rotate(new Vector3(0, -10, 0));
                    Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                    bulletSpawner.transform.Rotate(new Vector3(0, 10, 0));

                    Invoke("ShotTwice", 0.2f);
                    break;

                case 5:
                    Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);

                    bulletSpawner.transform.Rotate(new Vector3(0, 10, 0));
                    Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                    bulletSpawner.transform.Rotate(new Vector3(0, -10, 0));

                    bulletSpawner.transform.Rotate(new Vector3(0, -10, 0));
                    Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                    bulletSpawner.transform.Rotate(new Vector3(0, 10, 0));

                    Invoke("ShotTwice", 0.2f);
                    break;

                default:

                    break;
            }

        }
    }

    void ShotTwice()
    {
        Bulletsource.Play();
        if (GameManager.instance.hasWeapon && !isDodge)
        {
            bullet.GetComponent<cshBullet>().bulletSpeed = GameManager.instance.attackSpeed;

            switch (GameManager.instance.weaponLevel)
            {
                case 2:
                    Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                    break;

                case 4:
                    Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                    break;

                case 5:
                    Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);

                    bulletSpawner.transform.Rotate(new Vector3(0, 10, 0));
                    Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                    bulletSpawner.transform.Rotate(new Vector3(0, -10, 0));

                    bulletSpawner.transform.Rotate(new Vector3(0, -10, 0));
                    Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                    bulletSpawner.transform.Rotate(new Vector3(0, 10, 0));
                    break;

                default:

                    break;
            }

        }
    }

    void FreezeRotation()
    {
        rigid.angularVelocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        FreezeRotation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            // coin
            CoinSource.Play();
            GameManager.instance.coin++;
            GameManager.instance.itemDropInWorld--;
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "Metal")
        {
            // metal
            MetalSource.Play();
            GameManager.instance.metal++;
            GameManager.instance.itemDropInWorld--;
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "Heal")
        {
            // heal
            HealSource.Play();
            GameManager.instance.itemDropInWorld--;

            if (GameManager.instance.curHealth + 20 >
                GameManager.instance.maxHealth)
            {
                GameManager.instance.curHealth = GameManager.instance.maxHealth;
            }
            else
            {
                GameManager.instance.curHealth += 20;
            }

            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "Energy")
        {
            // energy
            EnergySource.Play();
            GameManager.instance.itemDropInWorld--;
            GameManager.instance.GetEnergyItem();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster" ||
            collision.gameObject.tag == "MonsterHand")
        {
            GameManager.instance.curHealth 
                -= (collision.gameObject.GetComponent<cshMonsterDrop>().Damage - GameManager.instance.armorLevel);
        }
    }
}
