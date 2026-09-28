using System.Collections.Generic;
using UnityEngine;

public class pool : MonoBehaviour
{
	public static pool buletPoolInstance;

	[SerializeField]
	private GameObject pooledBullet;

	private bool notEnoughBulletsInPool = true;

	private List<GameObject> bullets;

	private void Awake()
	{
		buletPoolInstance = this;
	}

	private void Start()
	{
		bullets = new List<GameObject>();
	}

	public GameObject GetBullet()
	{
		if (bullets.Count > 0)
		{
			for (int i = 0; i < bullets.Count; i++)
			{
				if (!bullets[i].activeInHierarchy)
				{
					return bullets[i];
				}
			}
		}
		if (notEnoughBulletsInPool)
		{
			GameObject gameObject = Object.Instantiate(pooledBullet);
			gameObject.SetActive(value: false);
			bullets.Add(gameObject);
			return gameObject;
		}
		return null;
	}
}
