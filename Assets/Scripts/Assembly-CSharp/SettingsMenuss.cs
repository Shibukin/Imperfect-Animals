using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenuss : MonoBehaviour
{
	public AudioMixer audioMix;

	public void SetVolume(float volume)
	{
		audioMix.SetFloat("volume", volume);
	}

	public void SetFullScre(bool isFull)
	{
		Screen.fullScreen = isFull;
	}
}
