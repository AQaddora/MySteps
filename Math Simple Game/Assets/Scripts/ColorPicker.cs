using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
	void Start()
	{
		GetComponent<Button>().onClick.AddListener(delegate
		{
			PaintingManager.Instance.mainColor = GetComponent<Image>().color;
		});
	}
}
