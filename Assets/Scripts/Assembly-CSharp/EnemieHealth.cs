using UnityEngine;
using UnityEngine.UI;

public class EnemieHealth : MonoBehaviour
{
	public static float health = 100f;

	public Text healthText;

	[Header("Objects Holder")]
	public GameObject DieEfect;

	public GameObject Chest;

	public GameObject music;

	public GameObject winMusic;

	private void Start()
	{
		health = 100f;
		healthText.text = health + "%".ToString();
	}

	private void Update()
	{
		if (health <= 0f)
		{
			healthText.text = "0%".ToString();
			Object.Instantiate(DieEfect, base.transform.position, base.transform.rotation);
			Object.Instantiate(DieEfect, base.transform.position, base.transform.rotation);
			music.SetActive(value: false);
			Object.Instantiate(winMusic);
			Object.Destroy(base.gameObject);
		}
	}

	private void UpdateTexxt()
	{
		healthText.text = health + "%".ToString();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "plBull")
		{
			int num = Random.Range(5, 11);
			health -= num;
			UpdateTexxt();
		}
	}
}
