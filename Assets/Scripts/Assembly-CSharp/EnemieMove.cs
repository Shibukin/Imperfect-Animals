using UnityEngine;

public class EnemieMove : MonoBehaviour
{
	private float moveSpeed;

	private bool moveRight;

	private void Start()
	{
		moveSpeed = 3.5f;
		moveRight = true;
	}

	private void Update()
	{
		Vector3 localScale = base.transform.localScale;
		if (base.transform.position.x > 7f)
		{
			moveRight = false;
			localScale.x = -1f;
		}
		else if (base.transform.position.x < -7f)
		{
			moveRight = true;
			localScale.x = 1f;
		}
		base.transform.localScale = localScale;
		if (moveRight)
		{
			base.transform.position = new Vector2(base.transform.position.x + moveSpeed * Time.deltaTime, base.transform.position.y);
		}
		else
		{
			base.transform.position = new Vector2(base.transform.position.x - moveSpeed * Time.deltaTime, base.transform.position.y);
		}
	}
}
