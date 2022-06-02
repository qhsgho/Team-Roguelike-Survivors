using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class cshMonstermove : MonoBehaviour

{
    Rigidbody rigid;
    public Transform player;
    NavMeshAgent nav;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        transform.LookAt(player);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        nav.SetDestination(player.position);
    }

    void FreezeVelocity()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        FreezeVelocity();
    }
}
