using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;

    public GameObject Destroyeffect;

    private void Start()
    {
        Invoke("DestroyProjectile", lifetime);
           
    }
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void DestroyProjectile()
    {
        Instantiate(Destroyeffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
