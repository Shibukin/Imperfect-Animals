using UnityEngine;

public class Gunner : MonoBehaviour
{
	public GameObject myPlayer;

	public Camera cam;

	private void FixedUpdate()
	{
		Vector3 vector = cam.ScreenToWorldPoint(Input.mousePosition) - base.transform.position;
		vector.Normalize();
		float z = Mathf.Atan2(vector.y, vector.x) * 57.29578f;
		base.transform.rotation = Quaternion.Euler(0f, 0f, z);
	}
}
