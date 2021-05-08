using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Boss : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    public static Boss boss;
    public ParticleSystem AhaytVersionBoss;
  
    private void Awake()
    {
        boss = this;
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BossHealthManager.bosshealthmanager.TakeDamage();
            Destroy(collision.gameObject);
            AhaytVersionBoss.Play();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(2);

    }

    
   
}   
 
