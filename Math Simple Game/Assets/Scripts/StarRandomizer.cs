using UnityEngine;

public class StarRandomizer : MonoBehaviour
{
	Transform starTransform;
	int direction;
    void Start()
    {
		starTransform = gameObject.transform;
		float rnd = Random.Range(0.3f, 0.8f);
		direction = Random.Range(0, 100) > 50 ? -1 : 1;
		starTransform.localScale = Vector3.one * rnd;
    }

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(0, 0, transform.localScale.z * Time.deltaTime * 50 * direction);
    }
}
