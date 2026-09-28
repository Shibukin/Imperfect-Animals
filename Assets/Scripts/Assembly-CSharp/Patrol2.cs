using UnityEngine;

public class Patrol2 : MonoBehaviour
{
	public float speed;

	public float waitTime;

	public float startWaitTime;

	public Transform[] moveSpots;

	private int randSpot;

	private void Start()
	{
		waitTime = startWaitTime;
		randSpot = Random.Range(0, moveSpots.Length);
	}

	private void Update()
	{
		base.transform.position = Vector2.MoveTowards(base.transform.position, moveSpots[randSpot].position, speed * Time.deltaTime);
		if (Vector2.Distance(base.transform.position, moveSpots[randSpot].position) < 0.2f)
		{
			if (waitTime <= 0f)
			{
				randSpot = Random.Range(0, moveSpots.Length);
				waitTime = startWaitTime;
			}
			else
			{
				waitTime -= Time.deltaTime;
			}
		}
	}
}
