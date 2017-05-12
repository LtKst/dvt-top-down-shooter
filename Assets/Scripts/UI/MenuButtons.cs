using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

	public void LoadLevel(int scene)
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(scene);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
