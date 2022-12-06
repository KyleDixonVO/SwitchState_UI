using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public LevelManager levelManager;
    public Canvas mainMenu;
    public Canvas pause;
    public Canvas options;
    public Canvas win;
    public Canvas gameover;
    public Canvas gameplay;
    public Canvas credits;
    public Slider slider;
    public TMP_Text loadTimeText;
    public TMP_Text zombiesRemainingTxt;
    public HealthBar playerHealthBar;

    // Start is called before the first frame update

    private void Awake()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        mainMenu = GameObject.Find("MainMenuCanvas").GetComponent<Canvas>();
        pause = GameObject.Find("PauseCanvas").GetComponent<Canvas>();
        options = GameObject.Find("OptionsCanvas").GetComponent<Canvas>();
        win = GameObject.Find("WinCanvas").GetComponent<Canvas>();
        gameover = GameObject.Find("GameoverCanvas").GetComponent<Canvas>();
        //gameplay = GameObject.Find("GameplayCanvas").GetComponent<Canvas>();
        credits = GameObject.Find("CreditsCanvas").GetComponent<Canvas>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        loadTimeText.text = slider.value.ToString();

        if (levelManager.returnFromOptions != LevelManager.UI_States.mainMenu)
        {
            slider.interactable = false;
        }
        else
        {
            slider.interactable = true;
        }

        if (levelManager.state == LevelManager.UI_States.mainMenu) 
        {
            zombiesRemainingTxt = null;
            playerHealthBar = null;
            return;
        }

        if (playerHealthBar == null || zombiesRemainingTxt == null)
        {
            playerHealthBar = GameObject.Find("Player").GetComponent<HealthBar>();
            zombiesRemainingTxt = GameObject.Find("ZombiesLeftTxt").GetComponent<TMP_Text>();
        }
        else
        {
            //Debug.Log(slider.value + " " + playerHealthBar.zombiesKilled);
            zombiesRemainingTxt.text = "Zombies left: " + (slider.value - playerHealthBar.zombiesKilled);
        }
        
    }

    public void MainMenu()
    {
        mainMenu.enabled = true;
        pause.enabled = false;
        options.enabled = false;
        win.enabled = false;
        gameover.enabled = false;
        credits.enabled = false;
        if (gameplay != null)
        {
            gameplay.enabled = false;
        }
    }

    public void Pause()
    {
        mainMenu.enabled = false;
        pause.enabled = true;
        options.enabled = false;
        win.enabled = false;
        gameover.enabled = false;
        credits.enabled = false;
        if (gameplay != null)
        {
            gameplay.enabled = false;
        }
    }

    public void Options()
    {
        mainMenu.enabled = false;
        pause.enabled = false;
        options.enabled = true;
        win.enabled = false;
        gameover.enabled = false;
        credits.enabled = false;
        if (gameplay != null)
        {
            gameplay.enabled = false;
        }
    }

    public void Credits()
    {
        mainMenu.enabled = false;
        pause.enabled = false;
        options.enabled = false;
        win.enabled = false;
        gameover.enabled = false;
        credits.enabled = true;
        if (gameplay != null)
        {
            gameplay.enabled = false;
        }
    }

    public void Gameplay()
    {
        mainMenu.enabled = false;
        pause.enabled = false;
        options.enabled = false;
        win.enabled = false;
        gameover.enabled = false;
        credits.enabled = false;
        gameplay = GameObject.Find("GameplayCanvas").GetComponent<Canvas>();
        if (gameplay != null)
        {
            gameplay.enabled = true;
        }
    }

    public void Win()
    {
        mainMenu.enabled = false;
        pause.enabled = false;
        options.enabled = false;
        win.enabled = true;
        gameover.enabled = false;
        credits.enabled = false;
        if (gameplay != null)
        {
            gameplay.enabled = false;
        }
    }

    public void Gameover()
    {
        mainMenu.enabled = false;
        pause.enabled = false;
        options.enabled = false;
        win.enabled = false;
        gameover.enabled = true;
        credits.enabled = false;
        if (gameplay != null)
        {
            gameplay.enabled = false;
        }
    }


}
