using UnityEngine;

public class minionFlip : MonoBehaviour
{
	public GameObject spriteMInion;

	public GameObject dieEffect;

	private player player;

	private void Start()
	{
		player = Object.FindObjectOfType<player>();
	}

	private void Update()
	{
		Vector3 localScale = spriteMInion.transform.localScale;
		if (base.transform.position.x < 0f)
		{
			localScale.x = -1f;
		}
		if (base.transform.position.x > 0f)
		{
			localScale.x = 1f;
		}
		base.transform.localScale = localScale;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			player.Hurt();
			Object.Instantiate(dieEffect, base.transform.position, base.transform.rotation);
			Object.Destroy(base.gameObject);
		}
		if (collision.gameObject.tag == "plBull")
		{
			Object.Instantiate(dieEffect, base.transform.position, base.transform.rotation);
			Object.Destroy(base.gameObject);
		}
	}
}
