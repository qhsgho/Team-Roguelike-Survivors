using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshBullet : MonoBehaviour
{
    public float bulletSpeed = 1.0f;
    public float deleteTime = 2.0f;

    void Start()
    {
        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.AddForce(transform.forward * bulletSpeed);

        Destroy(gameObject, deleteTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "World")
        {
            Destroy(gameObject);
        }
    }
}
