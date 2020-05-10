using UnityEngine;

public class DragItem : MonoBehaviour
{
	[SerializeField] Transform target;

	[SerializeField] Transform[] possibleTargets;

	bool isDragging = false;
	Vector3 initPos;

	public bool isVanishable = true;

	private void Awake()
	{
		if (target == null && possibleTargets.Length > 0) target = possibleTargets[0];
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
		isDragging = false;
		if (!FoundReachableTarget())
		{
			if(Vector3.Distance(transform.position, target.position) < DraggablesManager.Instance.sensetivity)
			{
				target.gameObject.SetActive(true);
				gameObject.SetActive(false);
				DraggablesManager.Instance.TrueEffect();
			}
			else
			{
				DraggablesManager.Instance.FalseEffect();
				transform.localPosition = initPos;
			}
		}
	}

	bool FoundReachableTarget()
	{
		if (possibleTargets == null || possibleTargets.Length == 0)
			return false;
		foreach (Transform target in possibleTargets)
		{
			if (Vector3.Distance(transform.position, target.position) < DraggablesManager.Instance.sensetivity)
			{
				target.gameObject.SetActive(true);
				if(isVanishable)
					gameObject.SetActive(false);
				DraggablesManager.Instance.TrueEffect();
				return true;
			}
		}
		return false;
	}
}
