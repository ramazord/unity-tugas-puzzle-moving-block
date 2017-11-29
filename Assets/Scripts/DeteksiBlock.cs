using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteksiBlock : MonoBehaviour {

	void OnTriggerStay2D(Collider2D collider) {
		Debug.Log ("Enter colider with deteksi block");
		if (Input.GetMouseButtonDown(0))
			Debug.Log("Pressed left click.");
		
		if (Input.GetMouseButtonDown(1))
			Debug.Log("Pressed right click.");
		
		if (Input.GetMouseButtonDown(2))
			Debug.Log("Pressed middle click.");
	}
}
