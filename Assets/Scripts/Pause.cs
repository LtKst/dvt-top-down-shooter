using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    private bool isPaused = false;

    [SerializeField]
    private GameObject pauseUI;

    private CursorManager cursorManager;

    private void Awake()
    {
        cursorManager = GameObject.FindWithTag("Manager").GetComponent<CursorManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPause();
        }
    }

    public void OnPause()
    {
        if (!isPaused)
        {
            isPaused = true;

            cursorManager.ChangeCursor(CursorManager.SelectedCursor.pointer);

            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;

            cursorManager.ChangeCursor(CursorManager.SelectedCursor.crosshair);

            Time.timeScale = 1;
        }

        pauseUI.SetActive(isPaused);
    }

    public bool IsPaused
    {
        get
        {
            return isPaused;
        }
    }
}
