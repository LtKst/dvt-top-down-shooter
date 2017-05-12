using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

    [SerializeField]
    private int score;
    [SerializeField]
    private int winScore = 500;

    [SerializeField]
    private AudioClip victoryClip;

    [Header("UI")]
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject winUI;

    private void Awake()
    {
        scoreText.text = "Score: " + score + "/" + winScore;
    }

	public void IncreaseScore(int amount)
    {
        score += amount;

        scoreText.text = "Score: " + score + "/" + winScore;

        if (score >= winScore)
        {
            GameObject.FindWithTag("Music").GetComponent<AudioSource>().clip = victoryClip;
            GameObject.FindWithTag("Music").GetComponent<AudioSource>().Play();

            winUI.SetActive(true);
        }
    }
}
