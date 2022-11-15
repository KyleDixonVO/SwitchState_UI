using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
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
        FadeJam();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Taking Damage" + health);
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

    public void FadeJam()
    {
        Debug.Log("Fading Jam");
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

}
