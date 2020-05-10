using UnityEngine;
using UnityEngine.UI;

public class ColorHandScript : MonoBehaviour
{
	public Color[] colors;
    void Start()
    {
		GetComponent<Button>().onClick.AddListener(delegate
		{
			GetComponent<Image>().color = colors[Random.Range(0, colors.Length)];
		});     
    }
}
