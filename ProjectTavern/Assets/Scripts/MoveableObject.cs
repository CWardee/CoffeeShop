using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
	private Vector3 screenPoint;
	private Vector3 offset;
	private bool objectPickedUp = false;
	public bool rotateObjectOnPickup = false;
	private Quaternion initialRotation;


	public Texture2D cursorHoverTexture;
	public Texture2D cursorGrabbingTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	void OnMouseEnter()
	{
		if (!objectPickedUp)
		{
			UnityEngine.Cursor.SetCursor(cursorHoverTexture, hotSpot, cursorMode);
		}
	}

	void OnMouseExit()
	{
		if(!objectPickedUp)
		{
			UnityEngine.Cursor.SetCursor(null, Vector2.zero, cursorMode);
		}
	}

	void OnMouseDown()
	{
		if(objectPickedUp)
		{
			UnityEngine.Cursor.SetCursor(cursorHoverTexture, hotSpot, cursorMode);
		}

		else
		{
			UnityEngine.Cursor.SetCursor(cursorGrabbingTexture, hotSpot, cursorMode);
		}

		Rigidbody rig = GetComponent<Rigidbody>();
		rig.useGravity = !rig.useGravity;
		objectPickedUp = !objectPickedUp;
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag()
	{

	}

	// Start is called before the first frame update
	void Start()
	{
		initialRotation = transform.rotation;
	}

		// Update is called once per frame
	void Update()
    {	
		if(objectPickedUp)
		{
			Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
			//transform.position = cursorPosition;
			transform.position = Vector3.Slerp(transform.position, cursorPosition, 0.1f);
			if(rotateObjectOnPickup)
			{
				transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, Time.deltaTime / 0.2f);
			}
		}
	}
}
