using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [Header("Health")]
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int health = 100;

    [SerializeField]
    private bool godMode;

    [Header("GameObjects")]
    [SerializeField]
    private GameObject spawnOnDeath;
    private GameObject spawnOnDeathInstance;

    [Header("UI")]
    [SerializeField]
    private RectTransform healthBarRect;
    private float initialHealthBarWidth;
    [SerializeField]
    private UnityEngine.UI.Text healthText;
    [SerializeField]
    private GameObject deathUI;

    private CursorManager cursorManager;

    private void Awake()
    {
        health = maxHealth;

        initialHealthBarWidth = healthBarRect.sizeDelta.x;

        cursorManager = GameObject.FindWithTag("Manager").GetComponent<CursorManager>();
    }

    public void Die()
    {
        cursorManager.ChangeCursor(CursorManager.SelectedCursor.pointer);

        deathUI.SetActive(true);
        spawnOnDeathInstance = Instantiate(spawnOnDeath);
        spawnOnDeathInstance.transform.position = transform.position;

        gameObject.SetActive(false);
    }

    public void ModifyHealth(int amount)
    {
        if (!godMode)
        {
            health += amount;

            health = Mathf.Clamp(health, 0, maxHealth);

            healthBarRect.sizeDelta = new Vector2(initialHealthBarWidth - (initialHealthBarWidth / maxHealth) * (maxHealth - health), healthBarRect.sizeDelta.y);
            healthText.text = health.ToString() + "/" + maxHealth.ToString();

            if (health <= 0)
            {
                Die();
            }
        }
    }

    public int Health
    {
        get
        {
            return health;
        }
    }

    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
        }
    }
}
