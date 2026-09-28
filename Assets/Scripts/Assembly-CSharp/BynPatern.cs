using System;
using UnityEngine;

public class BynPatern : MonoBehaviour
{
	private float angle;

	public float repeaterBe = 0.4f;

	private void Start()
	{
		InvokeRepeating("Fire", 0f, repeaterBe);
	}

	private void Fire()
	{
		float x = base.transform.position.x + Mathf.Sin(angle * MathF.PI / 180f);
		float y = base.transform.position.y + Mathf.Cos(angle * MathF.PI / 180f);
		Vector2 moveDirection = (new Vector3(x, y, 0f) - base.transform.position).normalized;
		GameObject obj = pool.buletPoolInstance.GetBullet();
		obj.transform.position = base.transform.position;
		obj.transform.rotation = base.transform.rotation;
		obj.SetActive(value: true);
		obj.GetComponent<bullet>().SetMoveDirection(moveDirection);
		angle += 20f;
	}

	private void Update()
	{
	}
}
