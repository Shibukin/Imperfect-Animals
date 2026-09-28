using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryMenu : MonoBehaviour
{
	private Scene m_Scene;

	private string sceneName;

	public GameObject goToPanel;

	private void Start()
	{
		m_Scene = SceneManager.GetActiveScene();
		sceneName = m_Scene.name;
	}

	public void ResetGames()
	{
		StartCoroutine(Res());
	}

	public void GoMenuFunct()
	{
		StartCoroutine(goToMain());
	}

	private IEnumerator goToMain()
	{
		goToPanel.SetActive(value: true);
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene("MainMenu");
	}

	private IEnumerator Res()
	{
		goToPanel.SetActive(value: true);
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene(sceneName);
	}
}
