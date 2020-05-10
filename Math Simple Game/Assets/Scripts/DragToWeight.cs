using UnityEngine;
using UnityEngine.UI;

public class DragToWeight : MonoBehaviour
{
	[SerializeField] Transform[] possibleTargets;
	[SerializeField] int weight;

	bool isDragging = false;
	Vector3 initPos;

	private void Awake()
	{
		initPos = transform.localPosition;
	}

	private void Update()
	{
		if (isDragging)
		{
			transform.position = Input.mousePosition;
		}
	}

	public void OnMouseDown()
	{
		isDragging = true;
	}

	public void OnMouseUp()
	{
		FoundReachableTarget();
		isDragging = false;
	}

	void FoundReachableTarget()
	{
		if (possibleTargets == null || possibleTargets.Length == 0)
			return;

		foreach (Transform target in possibleTargets)
		{
			if (Vector3.Distance(transform.position, target.position) < 150)
			{
				target.GetComponent<Scale>().SetPicture(GetComponent<Image>().sprite);
				target.GetComponent<Scale>().inObjectWeight = weight;
				ScalerScript.Instance.DoTheMath();
			}
		}
		transform.localPosition = initPos;
	}
}
