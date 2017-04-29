using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour {

    public enum SelectedCursor { pointer, crosshair }
    public SelectedCursor selectedCursor = SelectedCursor.pointer;

    [SerializeField]
    private Texture2D pointerTexture;
    [SerializeField]
    private Vector2 pointerHotspot = Vector2.zero;

    [SerializeField]
    private Texture2D crosshairTexture;
    [SerializeField]
    private Vector2 crosshairHotspot = new Vector2(16, 16);

    [SerializeField]
    public CursorMode cursorMode = CursorMode.Auto;

    private void Awake () {
        ChangeCursor(selectedCursor);
	}

    public void ChangeCursor(SelectedCursor newCursor)
    {
        selectedCursor = newCursor;

        switch (selectedCursor)
        {
            case SelectedCursor.pointer:
                Cursor.SetCursor(pointerTexture, pointerHotspot, cursorMode);
                break;
            case SelectedCursor.crosshair:
                Cursor.SetCursor(crosshairTexture, crosshairHotspot, cursorMode);
                break;
        }
    }
}
