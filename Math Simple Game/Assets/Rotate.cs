using UnityEngine;

public class Rotate : MonoBehaviour
{
	[SerializeField] float speed;
	[SerializeField] bool isOnY;
	bool isHours = false;

	private void Awake()
	{
		isHours = gameObject.name == "hours";
	}

	void Update()
    {
		if (isOnY)
		{
			transform.Rotate(0, Time.deltaTime * speed, 0);
		}
		else
		{
			transform.Rotate(0, 0, Time.deltaTime * speed);
		}
		if (!isOnY && isHours && transform.rotation.eulerAngles.z % 360 > -1 && transform.rotation.eulerAngles.z % 360 < 1)
		{
			LevelOneManager.Instance.DayCycle();
		}
	}
}
