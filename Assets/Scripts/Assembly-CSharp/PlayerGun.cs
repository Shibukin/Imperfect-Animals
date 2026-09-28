using UnityEngine;

public class PlayerGun : MonoBehaviour
{
	public float moveSpeed = 5f;

	public Rigidbody2D rb;

	public Camera cam;

	private Vector2 movement;

	private Vector2 mousePos;

	public Transform wandPos;

	private void Update()
	{
		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
	}

	private void FixedUpdate()
	{
		base.gameObject.transform.position = wandPos.position;
		Vector2 vector = mousePos - rb.position;
		float rotation = Mathf.Atan2(vector.y, vector.x) * 57.29578f - 90f;
		rb.rotation = rotation;
	}
}
