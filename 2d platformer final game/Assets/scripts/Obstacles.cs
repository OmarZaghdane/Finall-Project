using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public bool push;
    public float force = 300f;
    public float damage = 5f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            if (push)
            {
                Vector2 pushDirection = collision.transform.position - transform.position;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection.normalized * force);
            }
        }
    }
}

