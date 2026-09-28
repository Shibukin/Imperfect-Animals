using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BosBar : MonoBehaviour
{
	private Image healthBar;

	public float currentHealth;

	private float maxHealth = 100f;

	private EnemieHealth thePlayer;

	public GameObject thisPanels;

	public GameObject minionGen;

	public GameObject hellPanel;

	private player pl;

	public GameObject gun;

	private void Start()
	{
		healthBar = GetComponent<Image>();
		thePlayer = Object.FindObjectOfType<EnemieHealth>();
		pl = Object.FindObjectOfType<player>();
	}

	private void Update()
	{
		currentHealth = EnemieHealth.health;
		healthBar.fillAmount = currentHealth / maxHealth;
		if (currentHealth <= 0f)
		{
			pl.enabled = false;
			gun.SetActive(value: false);
			StartCoroutine(Apperas());
		}
	}

	private IEnumerator Apperas()
	{
		Time.timeScale = 0.5f;
		Object.Destroy(minionGen);
		yield return new WaitForSeconds(1.5f);
		Time.timeScale = 1f;
		hellPanel.SetActive(value: true);
		thisPanels.SetActive(value: false);
	}
}
