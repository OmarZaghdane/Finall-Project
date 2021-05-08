using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool MovingRight = true;
    public Transform GroundDetction;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
           
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        if(collision.gameObject.CompareTag("Right"))
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            MovingRight = false;
        }
                        
        if (collision.gameObject.CompareTag("Left"))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            MovingRight = true;
        }
    }
}
