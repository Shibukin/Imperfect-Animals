using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	private Image healthBar;

	public float currentHealth;

	private float maxHealth = 100f;

	private player thePlayer;

	public GameObject retryPanel;

	private void Start()
	{
		healthBar = GetComponent<Image>();
		thePlayer = Object.FindObjectOfType<player>();
	}

	private void Update()
	{
		currentHealth = player.health;
		healthBar.fillAmount = currentHealth / maxHealth;
		if (currentHealth <= 0f)
		{
			StartCoroutine(Apperas());
		}
	}

	private IEnumerator Apperas()
	{
		Time.timeScale = 0.5f;
		yield return new WaitForSeconds(1.5f);
		Time.timeScale = 1f;
		retryPanel.SetActive(value: true);
	}
}
