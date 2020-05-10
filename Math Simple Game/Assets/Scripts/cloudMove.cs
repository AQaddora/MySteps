using UnityEngine;

public class cloudMove : MonoBehaviour
{
	[SerializeField] Transform maxRight;
	[SerializeField] Transform minRight;
 	[SerializeField] float speed = 10;
	private void Update()
	{
		transform.Translate(Time.deltaTime * speed, 0, 0);
		if(transform.position.x > maxRight.position.x)
		{
			transform.position = new Vector3(minRight.position.x, transform.position.y, transform.position.z);
			speed = Random.Range(5, 10);
			float rndScale = Random.Range(0.8f, 1.5f);
			transform.localScale = Vector3.one * rndScale;
		}
	}
}
