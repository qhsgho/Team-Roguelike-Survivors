using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshFire : MonoBehaviour
{
	public cshSpwanBullet.TurretType type = cshSpwanBullet.TurretType.Single;
	public Transform target;
	public float speed = 1000.0f;
	public float turnSpeed = 4;

	public float knockBack = 1.5f;
	public float boomTimer = 4;

	public ParticleSystem explosion;
    public AudioSource audioPlayer;
    public AudioClip fireClip;
    void Start()
	{
		if (type == cshSpwanBullet.TurretType.Single)
		{
			Vector3 dir = target.position - transform.position;
			transform.rotation = Quaternion.LookRotation(dir);
		}
	}
    private void Update()
    {
        if (target == null)
        {
            Explosion();
            return;
        }

        if (transform.position.y < -0.2F)
        {
            Explosion();
        }

        boomTimer -= Time.deltaTime;
        if (boomTimer < 0)
        {
            Explosion();
        }

        if (type == cshSpwanBullet.TurretType.Dual)
        {
            Vector3 dir = target.position - transform.position;
            //float distThisFrame = speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, dir, Time.deltaTime * turnSpeed, 0.0f);
   
            transform.LookAt(target);

            //transform.Translate(Vector3.forward * Time.deltaTime * speed);
            GetComponent<Rigidbody>().AddForce(transform.forward * speed);
            transform.rotation = Quaternion.LookRotation(newDirection);

        }
        else //single
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * speed);
            //transform.Translate(transform.forward * singleSpeed * 2, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Vector3 dir = other.transform.position - transform.position;
            Vector3 knockBackPos = other.transform.position + (dir.normalized * knockBack);
            knockBackPos.y = 1;
            other.transform.position = knockBackPos;
            Explosion();
        }
    }
    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
