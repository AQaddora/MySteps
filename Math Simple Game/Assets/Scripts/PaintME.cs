using UnityEngine;
using UnityEngine.UI;

public class PaintME : MonoBehaviour
{
	private void Start()
	{
		GetComponent<Button>().onClick.AddListener(delegate
		{
			 PaintingManager.Instance.mainColor = GetComponent<Image>().color;
		});
	}
}
