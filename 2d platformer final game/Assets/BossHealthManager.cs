using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthManager : MonoBehaviour
{
    public float MaxHealth;
    private float health;
    public Slider slider;
    public static BossHealthManager bosshealthmanager;
    private void Awake()
    {
        bosshealthmanager = this;
    }
    private void Start()
    {
        health = MaxHealth;
    }
    public void TakeDamage()
    {
        health--;
        Debug.Log("BossHealth: " + health);
        slider.value = health;
        if (health <= 0)
        {
            Boss.boss.Die();
        }
    }
}
