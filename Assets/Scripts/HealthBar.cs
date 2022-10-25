using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject healthBar;
    public GameObject regularBoringHealthBar;
    public Slider boringHealthSlider;
    public Slider slider;
    public Gradient grad;
    public Color color;
    public float startingWidth;
    public int maxHealth;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        //healthBar = GameObject.Find("Fill");
        maxHealth = 100;
        health = maxHealth;
        boringHealthSlider.maxValue = maxHealth;
        boringHealthSlider.value = health;
        slider.maxValue = maxHealth;
        slider.value = health;
        healthBar.GetComponent<Image>().color = grad.Evaluate(1.0f);
        regularBoringHealthBar.GetComponent<Image>().color = grad.Evaluate(1.0f);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(5);
        }
        slider.value = health;
        boringHealthSlider.value = health;
        color = grad.Evaluate(slider.normalizedValue);
        healthBar.GetComponent<Image>().color = color;
        regularBoringHealthBar.GetComponent<Image>().color = color;
    }

    void TakeDamage(int damage)
    { 
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
    }

    void Heal(int healing)
    {
        health += healing;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
