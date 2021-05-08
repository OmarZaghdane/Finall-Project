using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public int attackDamage = 10;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    public ParticleSystem Ahayt;
    public AudioSource Ouch;

    public void Attack()
    {
        /*Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if(colInfo != null)
        {
            // colInfo.GetComponent<HealthManager>().TakeDamage();
            HealthManager.healthmanager.TakeDamage();
            Ouch.Play();
          Ahayt.Play();
        }
        */
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthManager.healthmanager.TakeDamage();
            Ouch.Play();
            Ahayt.Play();
        }
       
    }
}
