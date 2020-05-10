using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingManager : MonoBehaviour
{
	public static PaintingManager Instance;

	public Color mainColor = Color.red;
	public Transform parent;

	private void Awake()
	{
		Instance = this;
	}

	public void Clear()
	{
		for (int i = 0; i < parent.childCount; i++)
		{
			Destroy(parent.GetChild(i).gameObject);
		}
	}

	public void Exit()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}
}
