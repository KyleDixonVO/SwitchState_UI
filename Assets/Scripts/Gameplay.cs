using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    public bool winGame;
    public LevelManager levelManager;
    public HealthBar healthBar;
    public Slider zombieSlider;
    public int zombies;
    public InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Reset()
    {
        inputManager.Win = false;
        inputManager.Lose = false;
        healthBar = null;
    }

    // Update is called once per frame
    void Update()
    {
        zombies = (int)zombieSlider.value;
        if (levelManager.state != LevelManager.UI_States.gameplay) return;
        if (healthBar == null)
        {
            healthBar = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBar>();
        } 
    }
}
