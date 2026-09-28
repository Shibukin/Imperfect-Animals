using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
	public float currentscroll;

	public float speed;

	public Material _material;

	private void Start()
	{
		_material = GetComponent<SpriteRenderer>().material;
	}

	private void Update()
	{
		currentscroll += speed * Time.deltaTime;
		_material.mainTextureOffset = new Vector2(currentscroll, 0f);
	}
}
