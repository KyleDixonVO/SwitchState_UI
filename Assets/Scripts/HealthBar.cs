using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject regularBoringHealthBar;
    public Slider boringHealthSlider;
    public Gradient grad;
    public Color color;
    public float startingWidth;
    public int maxHealth;
    public int health;
    public bool invincible;
    public float cooldownTimer;

    // Start is called before the first frame update
    void Start()
    {
        //healthBar = GameObject.Find("Fill");
        maxHealth = 100;
        health = maxHealth;
        boringHealthSlider.maxValue = maxHealth;
        boringHealthSlider.value = health;
        regularBoringHealthBar.GetComponent<Image>().color = grad.Evaluate(1.0f);
    }

    // Update is called once per frame
    void Update()
    {


        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDamage(5);
        //}

        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    Heal(5);
        //}

        boringHealthSlider.value = health;
        color = grad.Evaluate(boringHealthSlider.normalizedValue);
        regularBoringHealthBar.GetComponent<Image>().color = color;
    }

    public void TakeDamage(int damage)
    {
        if (invincible) return;
        health -= damage;
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

    IEnumerator attackCooldown(float cooldownTime)
    {
        invincible = true;
        yield return new WaitForSeconds(cooldownTime);
        invincible = false;
    }

}
