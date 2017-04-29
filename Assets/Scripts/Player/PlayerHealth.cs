using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private GameObject spawnOnDeath;
    private GameObject spawnOnDeathInstance;

    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int health = 100;

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

    private void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
    }

    public void Die()
    {
        cursorManager.ChangeCursor(CursorManager.SelectedCursor.pointer);

        deathUI.SetActive(true);
        spawnOnDeathInstance = Instantiate(spawnOnDeath);
        spawnOnDeathInstance.transform.position = transform.position;

        gameObject.SetActive(false);
    }

    public void Damage(int damage)
    {
        health -= damage;

        healthBarRect.sizeDelta = new Vector2(initialHealthBarWidth - (initialHealthBarWidth / maxHealth) * (maxHealth - health), healthBarRect.sizeDelta.y);
        healthText.text = health.ToString() + "/" + maxHealth.ToString();

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        health += amount;

        healthBarRect.sizeDelta = new Vector2(initialHealthBarWidth - (initialHealthBarWidth / maxHealth) * (maxHealth - health), healthBarRect.sizeDelta.y);
        healthText.text = health.ToString() + "/" + maxHealth.ToString();
    }

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
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
