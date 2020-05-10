using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
	public GameObject lineRendererPrefab;
	public Transform parent;
	public LayerMask layermask;

	private GameObject currentLine;


	private bool isDrawing = false;
	private void Update()
	{
		if (isDrawing)
		{
			Vector3 camPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 desiredPos = new Vector3(camPos.x, camPos.y, transform.position.z);
			currentLine.transform.position = desiredPos;
		}
	}


	private void OnMouseDown()
	{
		Vector3 camPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 desiredPos = new Vector3(camPos.x, camPos.y, transform.position.z);
		currentLine = Instantiate(lineRendererPrefab, desiredPos, Quaternion.identity);
		currentLine.transform.parent = parent;
		Gradient gradient;
		GradientColorKey[] colorKey;
		GradientAlphaKey[] alphaKey;
		gradient = new Gradient();
		colorKey = new GradientColorKey[1];
		colorKey[0].time = 0f;
		colorKey[0].color = PaintingManager.Instance.mainColor;
		alphaKey = new GradientAlphaKey[1];
		alphaKey[0].alpha = 1f;
		alphaKey[0].time = 0f;
		gradient.SetKeys(colorKey, alphaKey);
		currentLine.GetComponent<TrailRenderer>().colorGradient = gradient;
		isDrawing = true;
	}

	private void OnMouseExit()
	{
		Debug.Log("Mouse Exit");
		isDrawing = false;
	}

	private void OnMouseUp()
	{
		Debug.Log("Mouse UP");
		isDrawing = false;
	}
}
