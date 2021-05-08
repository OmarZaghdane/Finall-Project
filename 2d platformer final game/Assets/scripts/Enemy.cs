using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleSystem Ahayt;
    public AudioSource Ouch;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Ahayt.Play();
            HealthManager.healthmanager.TakeDamage();
            Ouch.Play();
          
        }
    }
}
