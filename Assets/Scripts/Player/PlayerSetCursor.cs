using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetCursor : MonoBehaviour {

    [SerializeField]
    private Texture2D cursorTexture;

    [SerializeField]
    public CursorMode cursorMode = CursorMode.Auto;

    private Vector2 hotSpot = Vector2.zero;

    void Awake () {
        hotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);

        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
}
