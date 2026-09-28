using UnityEngine;

public class LifeTime : MonoBehaviour
{
	public float LifeTimes;

	private AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.pitch = 1f + Random.Range(-0.1f, 0.1f);
	}

	private void Update()
	{
		Object.Destroy(base.gameObject, LifeTimes);
	}
}
