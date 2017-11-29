using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControl : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;

    private bool isOnStick;
    GameObject stickObject;
    Vector3 curMousePos;
    Vector3 tempPos;
    void FixedUpdate()
    {
        if (isOnStick)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(stickObject.transform.position.x, transform.position.y, transform.position.z), Time.deltaTime * 3);
        }
    }

	void OnMouseDown()
	{
		////firstY = transform.position.y;
		//screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		//offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        tempPos = transform.position;
	}

	void OnMouseDrag() {
		//Vector3 currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		//Vector3 curPosition = Camera.main.ScreenToWorldPoint (currentScreenPoint) + offset;
        //transform.position = curPosition;
		//Debug.Log ("Mouse drags");

        if (isOnStick)
            DragOnStick();
        else
            DragOutStick();
        
	}

    void DragOnStick()
    {
        curMousePos = Camera.main.ScreenToWorldPoint(new Vector3(0, Input.mousePosition.y, 0));
        transform.position = new Vector3(stickObject.transform.position.x, curMousePos.y, 0);
    }

    void DragOutStick()
    {
        curMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        transform.position = new Vector3(curMousePos.x, curMousePos.y, 0);
    }

	private void OnMouseUp()
	{
		//transform.position = new Vector3(transform.position.x,transform.position.y, transform.position.z);
        if (!isOnStick)
            transform.position = tempPos;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Stick")
        {
            isOnStick = true;
            stickObject = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Stick")
        {
            isOnStick = false;
            stickObject = null;
        }
    }
}
