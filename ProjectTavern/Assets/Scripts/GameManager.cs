using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class GameManager : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void OnMouseEnter()
    {
        //UnityEngine.Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);       
    }

    void OnMouseExit()
    {
       // UnityEngine.Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    // Start is called before the first frame update
    void Start()
    {
       // UnityEngine.Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
