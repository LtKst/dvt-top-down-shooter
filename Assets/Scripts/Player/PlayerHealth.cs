using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    [Range(0, 100)]
    private int health = 100;
    private int initialHealth;

    [SerializeField]
    private RectTransform healthBarRect;
    private float initialHealthBarWidth;
    [SerializeField]
    private UnityEngine.UI.Text healthText;

    private void Awake()
    {
        initialHealth = health;

        initialHealthBarWidth = healthBarRect.sizeDelta.x;
    }

    private void Update()
    {
        healthBarRect.sizeDelta = Vector2.Lerp(healthBarRect.sizeDelta, new Vector2(initialHealthBarWidth - (initialHealthBarWidth / initialHealth) * (initialHealth - health), healthBarRect.sizeDelta.y), Time.deltaTime * 25);
        healthText.text = health.ToString() + "/" + initialHealth.ToString();
    }
}
