using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshSpwanBullet : MonoBehaviour
{
	public enum TurretType
	{
		Single = 1,
		Dual = 2,
	}
	public GameObject currentTarget;
	public Transform turretHead;

	public float attackDist = 10.0f;
	public float attackDamage;
	public float shootCoolDown;
	private float timer;
	public float loockSpeed;
	public float interval = 1.0f;
	public float t_HP = 100.0f;
	public Vector3 randomRot;

	[Header("[Turret Type]")]
	public TurretType turretType = TurretType.Single;

	public Transform muzzleMain;
	public Transform muzzleSub;
	public GameObject muzzleEff;
	public GameObject bullet;
	private bool shootLeft = true;

	public AudioSource audioPlayer;
	public AudioClip fireClip;

	void Start()
	{
		InvokeRepeating("CheckForTarget", 0, interval); // 인터벌 마다 몬스터 찾기
		randomRot = new Vector3(Random.Range(-15, 16), Random.Range(0, 359), 0);
	}
	void Update()
	{
		if (currentTarget != null)
		{
			FollowTarget();

			float currentTargetDist = Vector3.Distance(transform.position, currentTarget.transform.position);
			
			if (currentTargetDist > attackDist) // 공격 범위 벗어남
			{
				currentTarget = null;
			}
		}
		else
		{
			IdleRitate();
		}

		timer += Time.deltaTime;
		if (timer >= shootCoolDown)
		{
			if (currentTarget != null)
			{
				timer = 0;
				ShootTrigger();
			}
		}
		if (t_HP == 0)
        {
			CancelInvoke("CheckForTarget");
			//turretHead.transform.rotation = Quaternion.identity;
			turretHead.transform.rotation = Quaternion.Euler(turretHead.transform.rotation.eulerAngles);
			Debug.Log(turretHead.transform.rotation.eulerAngles);
		}
			
	}

	private void CheckForTarget() //몬스터 찾기
	{
		Collider[] colls = Physics.OverlapSphere(transform.position, attackDist);
		float distAway = Mathf.Infinity;

		for (int i = 0; i < colls.Length; i++)
		{
			if (colls[i].tag == "Monster") 
			{
				float dist = Vector3.Distance(transform.position, colls[i].transform.position);
				if (dist < distAway)
				{
					currentTarget = colls[i].gameObject;
					distAway = dist;
				}
			}
		}
	}

	private void FollowTarget() //todo : smooth rotate
	{
		Vector3 targetDir = currentTarget.transform.position - turretHead.position;
		targetDir.y = 0;
		if (turretType == TurretType.Single)
		{
			turretHead.forward = targetDir;
		}
		else
		{
			turretHead.transform.rotation = Quaternion.RotateTowards(turretHead.rotation, Quaternion.LookRotation(targetDir), loockSpeed * Time.deltaTime);
		}
	}

	private void ShootTrigger()
	{
		Shoot(currentTarget);
	}

	public void IdleRitate()
	{
		bool refreshRandom = false;

		if (turretHead.rotation != Quaternion.Euler(randomRot))
		{
			turretHead.rotation = Quaternion.RotateTowards(turretHead.transform.rotation, Quaternion.Euler(randomRot), loockSpeed * Time.deltaTime * 0.2f);
		}
		else
		{
			refreshRandom = true;

			if (refreshRandom)
			{
				int randomAngle = Random.Range(0, 359);
				int randomAngleX = Random.Range(-15, 16);
				randomRot = new Vector3(randomAngleX, randomAngle, 0);
				refreshRandom = false;
			}
		}
	}

	public void Shoot(GameObject go)
	{
		if (turretType == TurretType.Dual)
		{
			if (shootLeft)
			{
				Instantiate(muzzleEff, muzzleMain.transform.position, muzzleMain.rotation);
				GameObject firebullet = Instantiate(bullet, muzzleMain.transform.position, muzzleMain.rotation);
				cshFire fire = firebullet.GetComponent<cshFire>();
				fire.target = transform.GetComponent<cshSpwanBullet>().currentTarget.transform;
				audioPlayer.PlayOneShot(fireClip);
			}
			else
			{
				Instantiate(muzzleEff, muzzleSub.transform.position, muzzleSub.rotation);
				GameObject firebullet = Instantiate(bullet, muzzleSub.transform.position, muzzleSub.rotation);
				cshFire fire = firebullet.GetComponent<cshFire>();
				fire.target = transform.GetComponent<cshSpwanBullet>().currentTarget.transform;
				audioPlayer.PlayOneShot(fireClip);
			}

			shootLeft = !shootLeft;
		}
		else
		{
			Instantiate(muzzleEff, muzzleMain.transform.position, muzzleMain.rotation);
			GameObject firebullet = Instantiate(bullet, muzzleMain.transform.position, muzzleMain.rotation);
			cshFire fire = firebullet.GetComponent<cshFire>();
			fire.target = currentTarget.transform;
			audioPlayer.PlayOneShot(fireClip);
		}
	}
}