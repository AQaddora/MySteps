using UnityEngine;
using UnityEngine.UI;

public class HandsColorer : MonoBehaviour
{
	[SerializeField] Color[] colors;
	[SerializeField] Image[] handOutlines;
	private void Awake()
	{
		foreach (Image image in handOutlines)
		{
			image.color = colors[Random.Range(0, colors.Length)];
			foreach (Image childImage in image.GetComponentsInChildren<Image>())
			{
				childImage.color = image.color;
			}
		}
	}
}
