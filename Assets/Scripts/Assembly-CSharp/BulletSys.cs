using UnityEngine;

public class BulletSys : MonoBehaviour
{
	public int number_colums;

	public float speed;

	public Sprite texture;

	public Color color;

	public float lifeTime;

	public float fireRate;

	public float size;

	private float angle;

	public Material material;

	public float spin_speed;

	private float time;

	public ParticleSystem system;

	private void Awake()
	{
		Summon();
	}

	private void FixedUpdate()
	{
		time += Time.fixedDeltaTime;
		base.transform.rotation = Quaternion.Euler(0f, 0f, time * spin_speed);
	}

	private void Summon()
	{
		angle = 360 / number_colums;
		for (int i = 0; i < number_colums; i++)
		{
			Material material = this.material;
			GameObject gameObject = new GameObject("Particle System");
			gameObject.transform.Rotate(angle * (float)i, 90f, 0f);
			gameObject.transform.parent = base.transform;
			gameObject.transform.position = base.transform.position;
			system = gameObject.AddComponent<ParticleSystem>();
			gameObject.GetComponent<ParticleSystemRenderer>().material = material;
			ParticleSystem.MainModule main = system.main;
			main.startColor = Color.green;
			main.startSize = 0.5f;
			main.startSpeed = speed;
			main.maxParticles = 100000;
			main.duration = 0f;
			main.simulationSpace = ParticleSystemSimulationSpace.World;
			system.GetComponent<ParticleSystemRenderer>().sortingOrder = 2;
			ParticleSystem.EmissionModule emission = system.emission;
			emission.enabled = false;
			ParticleSystem.ShapeModule shape = system.shape;
			shape.enabled = true;
			shape.shapeType = ParticleSystemShapeType.Sprite;
			shape.sprite = null;
			ParticleSystem.TextureSheetAnimationModule textureSheetAnimation = system.textureSheetAnimation;
			textureSheetAnimation.mode = ParticleSystemAnimationMode.Sprites;
			textureSheetAnimation.AddSprite(texture);
			textureSheetAnimation.enabled = true;
		}
		InvokeRepeating("DoEmit", 0f, fireRate);
	}

	private void DoEmit()
	{
		foreach (Transform item in base.transform)
		{
			system = item.GetComponent<ParticleSystem>();
			ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams
			{
				startColor = color,
				startSize = size,
				startLifetime = lifeTime
			};
			system.Emit(emitParams, 10);
		}
	}
}
