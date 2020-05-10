using UnityEngine;
using UnityEngine.UI;

public class Scale : MonoBehaviour
{
	[SerializeField] private Image scaledObj;
	[HideInInspector] public int inObjectWeight;
	[HideInInspector] public bool hasSomething;
	public void SetPicture(Sprite objeSpr)
	{
		hasSomething = true;
		scaledObj.sprite = objeSpr;
		scaledObj.GetComponentInChildren<CanvasGroup>().alpha = 1;
	}

	public void LosePicture()
	{
		hasSomething = false;
		scaledObj.sprite = null;
		scaledObj.GetComponentInChildren<CanvasGroup>().alpha = 0;
	}
}
