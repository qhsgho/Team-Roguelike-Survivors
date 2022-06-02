using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshMonsterDrop : MonoBehaviour
{
    Rigidbody rigid;
    Material mat;
    Material mat2;
    public GameObject[] item = new GameObject[4];

    public float maxHealth = 20f;
    public float curHealth = 20f;
    public float Damage = 10f;
    public bool isBoss = false;
    public bool isDrop = false;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        mat = transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material;
        mat2 = transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;

        if(isBoss)
        {
            maxHealth = 50f;
            curHealth = 50f;
            Damage = 20f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);

            curHealth -= GameManager.instance.playerDmg;

            StartCoroutine(OnDamage());
        }

        else if (other.gameObject.tag == "TurretBullet")
        {
            Destroy(other.gameObject);

            curHealth -= GameManager.instance.TurretDmg;

            StartCoroutine(OnDamage());
        }
    }

    IEnumerator OnDamage()
    {
        mat.color = Color.red;
        mat2.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        if(curHealth > 0)
        {
            mat.color = Color.white;
            mat2.color = Color.white;
        }

        else
        {
            mat.color = Color.gray;
            mat2.color = Color.gray;

            if (itemPercentage() && !isDrop)
            {
                Drop();
                isDrop = true;
            }

            Destroy(gameObject, 0.1f);
        }

    }

    public void Drop()
    {
        int itemNumber = Random.Range(0, item.Length);
        Vector3 v = new Vector3(0f, 0.5f, 0f);
        Instantiate(item[itemNumber], transform.position + v, transform.rotation);
        GameManager.instance.itemDropInWorld++;
    }

    bool itemPercentage()
    {
        int percentage = Random.Range(0, 2);
        if (percentage == 0)
            return true;
        return false;
    }
}
