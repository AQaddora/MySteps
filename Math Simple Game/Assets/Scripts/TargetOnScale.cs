using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetOnScale : MonoBehaviour
{
	public GameObject[] targets;
	public Transform pointer;
	public float zRotForPointer;
	private void OnEnable()
	{
		foreach (GameObject gameObject in targets)
		{
			if(gameObject != this.gameObject)
				gameObject.SetActive(false);
		}
		pointer.rotation = Quaternion.Euler(0, 0, zRotForPointer);
	}
}
