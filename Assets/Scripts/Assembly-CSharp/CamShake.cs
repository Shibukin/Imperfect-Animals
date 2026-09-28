using UnityEngine;

public class CamShake : MonoBehaviour
{
	public Animator camAnim;

	public void CamShaker()
	{
		int num = Random.Range(0, 3);
		if (num == 0)
		{
			camAnim.SetTrigger("shake");
		}
		if (num == 1)
		{
			camAnim.SetTrigger("shake2");
		}
		if (num == 2)
		{
			camAnim.SetTrigger("shake3");
		}
	}
}
