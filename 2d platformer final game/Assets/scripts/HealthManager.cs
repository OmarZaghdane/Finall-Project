using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float MaxHealth;
    private float health;
    public Slider slider;
    public static HealthManager healthmanager;
    Animator animator;
    private void Awake()
    {
        healthmanager = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth;
    }


   
    public void TakeDamage()
    {
        health--;
        Debug.Log("Health: " + health);
        slider.value = health;
        if (health <= 0)
        {
            PlayerMovement.player.Die();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Health: " + health);
        slider.value = health;
        if (health <= 0)
        {
            health = 0;
            
        }
    }
   
}    
