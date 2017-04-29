using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

	public void LoadLevel(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void SettingsButton()
    {
        print("settings");
    }

    public void QuitButton()
    {
        print("quit");

        Application.Quit();
    }
}
