using System.Collections;
using UnityEngine;

public class ScalerScript : MonoBehaviour
{
	public static ScalerScript Instance;
	public static bool hasLeft, hasRight;

	public Scale leftScale, rightScale;

	public AudioClip doneWeighing;

	public bool isRuning = false;

	private void Awake()
	{
		Instance = this;
	}
	public void DoTheMath()
    {
		if (leftScale.hasSomething && rightScale.hasSomething)
		{
			if (leftScale.inObjectWeight > rightScale.inObjectWeight)
			{
				StartCoroutine(Animate(true));
			}
			else if (leftScale.inObjectWeight < rightScale.inObjectWeight)
			{
				StartCoroutine(Animate(false));
			}
			else
			{
				rightScale.transform.localScale = Vector3.one;
				leftScale.transform.localScale = Vector3.one;
			}
		}
		else if (leftScale.hasSomething && !rightScale.hasSomething)
		{
				StartCoroutine(Animate(true));
		}
		else if(!leftScale.hasSomething && rightScale.hasSomething)
		{
			StartCoroutine(Animate(false));
		}
		AudioManager.Instance.PlayEffect(doneWeighing);
    }

	IEnumerator Animate(bool isLeft)
	{
		isRuning = true;
		if (isLeft)
		{
			while(leftScale.transform.localScale.y < 1.3f)
			{
				leftScale.transform.localScale += Vector3.up * 0.1f;
				rightScale.transform.localScale += Vector3.up * -0.1f;
				yield return null;
			}
		}
		else
		{
			while (rightScale.transform.localScale.y < 1.3f)
			{
				rightScale.transform.localScale += Vector3.up * 0.1f;
				leftScale.transform.localScale += Vector3.up * -0.1f;
				yield return null;
			}
		}
	}

	public void ResetTheScale()
	{
		rightScale.transform.localScale = Vector3.one;
		leftScale.transform.localScale = Vector3.one;
		isRuning = false;
		leftScale.LosePicture();
		rightScale.LosePicture();
	}
}
