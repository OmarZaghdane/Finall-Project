using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArenaDetection : MonoBehaviour
{
    public GameObject Boss;
    public GameObject mur;
    public GameObject BossHealthbar;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Boss.SetActive(true);
            mur.SetActive(true);
            Debug.Log("tihbes");
            BossHealthbar.SetActive(true);
        }
     
    }
}
