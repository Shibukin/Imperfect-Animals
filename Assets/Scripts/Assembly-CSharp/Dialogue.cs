using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
	public Text textDisplay;

	public string[] sentences;

	public int index;

	public float typingSpeed;

	public GameObject daCbutton;

	[Header("Flick Properties")]
	public Image FlickCat;

	public Sprite[] newFlicks;

	private int spriteIndex;

	[Header("Audio Shit")]
	[SerializeField]
	private AudioClip npcVoice;

	private AudioSource audioSource;

	public int endOfDialogue;

	public GameObject transObj;

	public string otherScene;

	public int charsToPlaySound;


	// =========================================================
	// NUEVO: BACKGROUND POR LÍNEA
	// =========================================================

	[Header("Background por línea")]

	[SerializeField]
	private Image backgroundImage;

	[SerializeField]
	private Sprite[] backgroundsByLine;


	// =========================================================
	// NUEVO: AUDIO POR LÍNEA
	// =========================================================

	[Header("Audio por línea")]

	[SerializeField]
	private AudioClip[] audioByLine;


	private void Start()
	{
		audioSource = GetComponent<AudioSource>();

		audioSource.clip = npcVoice;

		// Busca automáticamente el Image dentro de "Panel"
		FindBackgroundImage();

		// Aplica los elementos correspondientes a la primera línea
		ApplyLineSettings(index);

		StartCoroutine(Type());
	}


	private void Update()
	{
		if (textDisplay.text == sentences[index])
		{
			daCbutton.SetActive(value: true);
		}

		if (index == endOfDialogue)
		{
			StartCoroutine(trnsitionTo());
		}
	}


	private IEnumerator Type()
	{
		int charIndex = 0;
		char[] array = sentences[index].ToCharArray();

		foreach (char c in array)
		{
			textDisplay.text += c;

			if (charIndex % charsToPlaySound == 0)
			{
				audioSource.pitch = 1f + Random.Range(-0.1f, 0.1f);
				audioSource.Play();
			}

			charIndex++;

			yield return new WaitForSeconds(typingSpeed);
		}
	}


	public void NextSentence()
	{
		daCbutton.SetActive(value: false);

		if (index < sentences.Length - 1)
		{
			index++;

			textDisplay.text = "";

			// NUEVO:
			// Cambia background/audio dependiendo de la nueva línea
			ApplyLineSettings(index);

			StartCoroutine(Type());

			NextFlicky();
		}
		else
		{
			textDisplay.text = "";
			daCbutton.SetActive(value: false);
		}
	}


	private void NextFlicky()
	{
		FlickCat.sprite = newFlicks[spriteIndex];

		spriteIndex++;

		int num = newFlicks.Length;

		if (spriteIndex >= num)
		{
			spriteIndex = 0;
		}
	}


	private IEnumerator trnsitionTo()
	{
		yield return new WaitForSeconds(0.9f);

		transObj.SetActive(value: true);

		yield return new WaitForSeconds(1.5f);

		SceneManager.LoadScene(otherScene);
	}


	// =========================================================
	// NUEVAS FUNCIONES PARA LA VN
	// =========================================================

	private void FindBackgroundImage()
	{
		// Si ya asignaste el Image manualmente, no busca nada.
		if (backgroundImage != null)
		{
			return;
		}

		// Busca el objeto llamado "Panel"
		Transform panel = transform.Find("Panel");

		if (panel != null)
		{
			// Busca un Image dentro de Panel
			backgroundImage = panel.GetComponentInChildren<Image>(true);
		}

		if (backgroundImage == null)
		{
			Debug.LogWarning(
				"Dialogue: No se encontró un componente Image dentro de 'Panel'."
			);
		}
	}


	private void ApplyLineSettings(int lineIndex)
	{
		// -----------------------------------------------------
		// BACKGROUND
		// -----------------------------------------------------

		if (backgroundImage != null)
		{
			if (backgroundsByLine != null &&
				lineIndex >= 0 &&
				lineIndex < backgroundsByLine.Length)
			{
				// Si hay sprite asignado para esta línea,
				// cambia el background.
				if (backgroundsByLine[lineIndex] != null)
				{
					backgroundImage.sprite = backgroundsByLine[lineIndex];
				}
			}
		}


		// -----------------------------------------------------
		// AUDIO
		// -----------------------------------------------------

		if (audioSource != null)
		{
			if (audioByLine != null &&
				lineIndex >= 0 &&
				lineIndex < audioByLine.Length)
			{
				// Si existe un audio para esta línea,
				// reemplaza el audio actual.
				if (audioByLine[lineIndex] != null)
				{
					audioSource.clip = audioByLine[lineIndex];
				}
			}
		}
	}


	// =========================================================
	// CAMBIAR BACKGROUND MANUALMENTE
	// =========================================================

	public void ChangeBackground(Sprite newBackground)
	{
		if (backgroundImage != null)
		{
			backgroundImage.sprite = newBackground;
		}
	}


	// =========================================================
	// CAMBIAR AUDIO MANUALMENTE
	// =========================================================

	public void ChangeDialogueAudio(AudioClip newAudio)
	{
		if (audioSource != null)
		{
			audioSource.clip = newAudio;
		}
	}
}

