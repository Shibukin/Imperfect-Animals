using UnityEngine;

public class bullet1 : MonoBehaviour
{
	public GameObject hitEffect;

	private CamShake shake;

	private GameObject player;

	public GameObject HitSound;

	private void Start()
	{
		shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CamShake>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Physics2D.IgnoreLayerCollision(6, 7);
		Object.Instantiate(HitSound);
		shake.CamShaker();
		Object.Destroy(Object.Instantiate(hitEffect, base.transform.position, Quaternion.identity), 5f);
		Object.Destroy(base.gameObject);
	}

	private void Update()
	{
		Object.Destroy(base.gameObject, 3f);
	}
}
