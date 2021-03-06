using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float offset;

    public GameObject Kartouch;
    public Transform FirePoint;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public static Weapon weapon;
    public AudioSource ShotSoundEffect;
    private void Awake()
    {
        weapon = this;   
    }
    // Update is called once per frame
    void Update()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(Kartouch, FirePoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
                ShotSoundEffect.Play();
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    public void Rotate()
    {
       
        
    }
    
}
