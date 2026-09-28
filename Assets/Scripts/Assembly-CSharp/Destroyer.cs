using UnityEngine;

public class Destroyer : MonoBehaviour
{
	public float timer;

	private void Start()
	{
		Object.Destroy(base.gameObject, timer);
	}
}
