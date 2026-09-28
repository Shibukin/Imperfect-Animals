using UnityEngine;

public class minionGenerator : MonoBehaviour
{
	public GameObject minion;

	public GameObject efe;

	public Transform[] spawnPoints;

	public float spawnRate;

	public float spawnCounter;

	private void Start()
	{
	}

	private void Update()
	{
		Transform transform = spawnPoints[Random.Range(0, spawnPoints.Length)];
		spawnCounter -= Time.deltaTime;
		if (spawnCounter <= 0f)
		{
			Object.Instantiate(efe, minion.transform.position, minion.transform.rotation);
			Object.Instantiate(minion, transform.position, Quaternion.identity);
			spawnCounter = spawnRate;
		}
	}
}
