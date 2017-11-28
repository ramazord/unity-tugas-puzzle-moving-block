using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControl : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;
	// Use this for initialization
	void OnMouseDown()
	{
		//firstY = transform.position.y;
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag() {
		Vector3 currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint (currentScreenPoint) + offset;
		transform.position = curPosition;
		Debug.Log ("Mouse drags");
	}

	private void OnMouseUp()
	{
		transform.position = new Vector3(transform.position.x,transform.position.y, transform.position.z);
	}
}
