using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    InputManager inputManager;
    LevelManager levelManager;
    Gameplay gameplay;
    public GameObject regularBoringHealthBar;
    public Slider boringHealthSlider;
    public Gradient grad;
    public Image jam;
    public Color color;
    public float startingWidth;
    public int maxHealth;
    public int health;
    public bool invincible;
    public float cooldownTimer;
    public int zombiesKilled;
    private float timeToHealing;
    public float elapsedHealingTime;

    // Start is called before the first frame update
    void Start()
    {
        timeToHealing = 3.0f;
        elapsedHealingTime = 0;
        zombiesKilled = 0;
        maxHealth = 100;
        health = maxHealth;
        boringHealthSlider.maxValue = maxHealth;
        boringHealthSlider.value = health;
        regularBoringHealthBar.GetComponent<Image>().color = grad.Evaluate(1.0f);
        inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        gameplay = GameObject.Find("GameplayManager").GetComponent<Gameplay>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedHealingTime += Time.deltaTime;
        if (health > 0 && health < 100 && elapsedHealingTime > timeToHealing)
        {
            health++;
        }

        if (health <= 0 && levelManager.state == LevelManager.UI_States.gameplay)
        {
            Debug.Log("Lost Game");
            inputManager.Lose = true;
        }
        else if (zombiesKilled >= gameplay.zombieSlider.value && levelManager.state == LevelManager.UI_States.gameplay)
        {
            Debug.Log(zombiesKilled + " " + gameplay.zombieSlider.value);
            Debug.Log("Won Game");
            inputManager.Win = true;
        }

        boringHealthSlider.value = health;
        color = grad.Evaluate(boringHealthSlider.normalizedValue);
        regularBoringHealthBar.GetComponent<Image>().color = color;
        FadeJam();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Taking Damage" + health);
        if (invincible) return;
        health -= damage;
        elapsedHealingTime = 0;
        StartCoroutine(attackCooldown(cooldownTimer));
        if (health < 0)
        {
            health = 0;
        }
    }

    public void Heal(int healing)
    {
        health += healing;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void FadeJam()
    {
        if (health == maxHealth && jam.color.a == 0) return;
        //Debug.Log("Fading Jam");
        if ((health / maxHealth) < 0.25)
        {
            jam.DOFade(0.5f, 1);
        }
        else if ((health / maxHealth) < 0.5)
        {
            jam.DOFade(0.35f, 1);
        }
        else if ((health / maxHealth) < 0.7)
        {
            jam.DOFade(0.1f, 1);
        }
        else if (jam.color.a != 0)
        {
            jam.DOFade(0, 1);
        }
    }

    IEnumerator attackCooldown(float cooldownTime)
    {
        invincible = true;
        yield return new WaitForSeconds(cooldownTime);
        invincible = false;
        Debug.Log("No longer invincible!");
    }

    public void Reset()
    {
        elapsedHealingTime = 0;
        zombiesKilled = 0;
        maxHealth = 100;
        health = maxHealth;
        boringHealthSlider.maxValue = maxHealth;
        boringHealthSlider.value = health;
        FadeJam();
    }

}
