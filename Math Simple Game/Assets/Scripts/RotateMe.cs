using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMe : MonoBehaviour
{
	[SerializeField] private float rotSpeed = 20f;

	private void OnMouseDrag()
	{
		float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
		float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

		transform.parent.RotateAround(Vector3.up, -rotX);
		transform.parent.RotateAround(Vector3.right, -rotY);
	}
}
