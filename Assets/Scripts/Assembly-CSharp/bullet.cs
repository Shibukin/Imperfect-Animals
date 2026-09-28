using UnityEngine;

public class bullet : MonoBehaviour
{
	private Vector2 moveDirection;

	private float moveSpeed;

	public GameObject onPlayerEfect;

	public GameObject HitSound;

	private void OnEnable()
	{
		Invoke("Destroy", 3f);
	}

	private void Start()
	{
		moveSpeed = 12f;
	}

	private void Update()
	{
		base.transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
	}

	public void SetMoveDirection(Vector2 dir)
	{
		moveDirection = dir;
	}

	private void Destroy()
	{
		base.gameObject.SetActive(value: false);
	}

	private void OnDisable()
	{
		CancelInvoke();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Physics2D.IgnoreLayerCollision(8, 9);
		if (collision.gameObject.tag == "Player")
		{
			Object.Instantiate(onPlayerEfect, base.transform.position, base.transform.rotation);
			Debug.Log("HitPlayer");
			Object.Instantiate(HitSound);
			Destroy();
		}
	}
}
