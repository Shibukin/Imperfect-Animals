using UnityEngine;

public class Shooting : MonoBehaviour
{
	public Transform firePoint;

	public GameObject bulletPrefab;

	public GameObject fireEffect;

	public float bulletForce = 20f;

	public float spawnRate;

	public float spawnCounter;

	private void Update()
	{
		if (Input.GetButton("Fire1"))
		{
			spawnCounter -= Time.deltaTime;
			if (spawnCounter <= 0f)
			{
				Shoot();
				spawnCounter = spawnRate;
			}
		}
	}

	private void Shoot()
	{
		GameObject obj = Object.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Object.Instantiate(fireEffect, firePoint.position, firePoint.rotation);
		obj.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
	}
}
