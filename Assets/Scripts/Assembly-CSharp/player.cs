using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
	[Header("Physics")]
	public float moveSpeed = 5f;

	public Rigidbody2D rb;

	private Vector2 movement;

	public Animator anim;

	[Header("Health and visuals")]
	public static float health = 100f;

	private CamShake shake;

	public Text healthText;

	public GameObject hurtPane;

	public GameObject gunPlayer;

	public GameObject musci;

	public GameObject HitSound;

	private void Start()
	{
		Application.targetFrameRate = 60;
		health = 100f;
		shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CamShake>();
		healthText.text = health + "%".ToString();
	}

	private void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
		if (health <= 0f)
		{
			healthText.text = "0%".ToString();
			base.gameObject.SetActive(value: false);
			musci.SetActive(value: false);
			gunPlayer.SetActive(value: false);
		}
	}

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
		Vector3 localScale = base.transform.localScale;
		if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
		{
			anim.SetFloat("Speed", 1f);
		}
		else
		{
			anim.SetFloat("Speed", 0f);
		}
		if (Input.GetAxis("Horizontal") < 0f)
		{
			localScale.x = -1f;
		}
		if (Input.GetAxis("Horizontal") > 0f)
		{
			localScale.x = 1f;
		}
		base.transform.localScale = localScale;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "bull")
		{
			Object.Instantiate(HitSound);
			Hurt();
		}
	}

	public void Hurt()
	{
		int num = Random.Range(4, 10);
		anim.SetTrigger("hurt");
		StartCoroutine(PanelHurt());
		UpdateHText();
		shake.CamShaker();
		health -= num;
	}

	private void UpdateHText()
	{
		healthText.text = health + "%".ToString();
	}

	private IEnumerator PanelHurt()
	{
		hurtPane.SetActive(value: true);
		yield return new WaitForSeconds(1f);
		hurtPane.SetActive(value: false);
	}
}
