using System;
using UnityEngine;

public class FireBull : MonoBehaviour
{
	[SerializeField]
	private int bulletsAmmount = 10;

	public float repeater = 2f;

	[SerializeField]
	private float startAngle = 90f;

	[SerializeField]
	private float endAngle = 270f;

	private Vector2 bulletMoveDirection;

	private void Start()
	{
		InvokeRepeating("Fire", 0f, repeater);
	}

	private void Fire()
	{
		float num = (endAngle - startAngle) / (float)bulletsAmmount;
		float num2 = startAngle;
		for (int i = 0; i < bulletsAmmount + 1; i++)
		{
			float x = base.transform.position.x + Mathf.Sin(num2 * MathF.PI / 180f);
			float y = base.transform.position.y + Mathf.Cos(num2 * MathF.PI / 180f);
			Vector2 moveDirection = (new Vector3(x, y, 0f) - base.transform.position).normalized;
			GameObject obj = pool.buletPoolInstance.GetBullet();
			obj.transform.position = base.transform.position;
			obj.transform.rotation = base.transform.rotation;
			obj.SetActive(value: true);
			obj.GetComponent<bullet>().SetMoveDirection(moveDirection);
			num2 += num;
		}
	}
}
