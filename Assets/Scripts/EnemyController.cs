using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public GameObject healthBar;
    public Slider slider;
    public Gradient grad;
    public Color color;
    public float startingWidth;
    public int maxHealth;
    public int health;
    public int damage;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //healthBar = GameObject.Find("Fill");
        maxHealth = 100;
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;
        healthBar.GetComponent<Image>().color = grad.Evaluate(1.0f);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
        Navigate();
        UpdateAnimationReferences();
        Attack();
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

    void Attack()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= gameObject.GetComponent<NavMeshAgent>().stoppingDistance + 0.5)
        {
            player.GetComponent<HealthBar>().TakeDamage(damage);
        }
    }

    void UpdateHealthBar()
    {
        slider.value = health;
        color = grad.Evaluate(slider.normalizedValue);
        healthBar.GetComponent<Image>().color = color;
    }

    void UpdateAnimationReferences()
    {
        gameObject.transform.GetComponentInChildren<Animator>().SetFloat("speed", gameObject.GetComponent<NavMeshAgent>().velocity.magnitude);
        gameObject.transform.GetComponentInChildren<Animator>().SetFloat("health", health);
        gameObject.transform.GetComponentInChildren<Animator>().SetFloat("distanceFromPlayer", Vector3.Distance(gameObject.transform.position, player.transform.position));
    }

    void Navigate()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) > 60 || health == 0 || Vector3.Distance(gameObject.transform.position, player.transform.position) < gameObject.GetComponent<NavMeshAgent>().stoppingDistance)
        {
            gameObject.GetComponent<NavMeshAgent>().SetDestination(gameObject.transform.position);
            gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
        }
        else
        {
            gameObject.GetComponent<NavMeshAgent>().SetDestination(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z));
        }
    }


}
