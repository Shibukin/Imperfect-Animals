using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[Header("Panels")]
	public GameObject creditsPanel;

	public GameObject settingsPanel;

	public GameObject goToPanel;

	public void StartGame()
	{
		StartCoroutine(PanelPlay());
	}

	private IEnumerator PanelPlay()
	{
		goToPanel.SetActive(value: true);
		yield return new WaitForSeconds(1.9f);
		SceneManager.LoadScene("Cinematic1");
	}

	public void ActivePanel()
	{
		creditsPanel.SetActive(value: true);
	}

	public void InActivePanel()
	{
		creditsPanel.SetActive(value: false);
	}

	public void ActiveSetting()
	{
		settingsPanel.SetActive(value: true);
	}

	public void InActiveSetting()
	{
		settingsPanel.SetActive(value: false);
	}
}
