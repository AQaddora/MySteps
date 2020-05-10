using UnityEngine;
using UnityEngine.UI;

public class TalkAnimation : MonoBehaviour
{
	public Image image;
	[SerializeField] Sprite[] startSprites;
	[SerializeField] Sprite[] loopedSprites;
	[SerializeField] Sprite[] endSprites;
	
	int loopedCounter = 0;
	int startCounter = 0;
	int endCounter = 0;

	void Start()
    {
		image.sprite = startSprites[0];
    }

	public void StartAnimation()
	{
		CancelInvoke();
		if (++startCounter >= startSprites.Length)
		{
			LoopAnimation();
			return;
		}
		image.sprite = startSprites[startCounter];
		Invoke("StartAnimation", 0.2f);
	}

	public void LoopAnimation()
	{
		CancelInvoke();
		loopedCounter = (loopedCounter + 1) % loopedSprites.Length;
		image.sprite = loopedSprites[loopedCounter];
		Invoke("LoopAnimation", 0.2f);
	}

	public void EndAnimation()
	{
		CancelInvoke();
		if (++endCounter >= endSprites.Length)
		{
			//EVENT OR RETURN
			return;
		}
		image.sprite = endSprites[endCounter];
		Invoke("StartAnimation", 0.2f);
	}
}
