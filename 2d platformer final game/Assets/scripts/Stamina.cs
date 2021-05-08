using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Stamina : MonoBehaviour
{
    public Slider StaminaBar;

    private int MaxStamina = 100;
    private int CurrentStamina;

    private WaitForSeconds RegentTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static Stamina instance;
    public PlayerMovement player;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CurrentStamina = MaxStamina;
        StaminaBar.maxValue = MaxStamina;
        StaminaBar.value = MaxStamina;
    }

    public void Stamuna(int amount)
    {
        if(CurrentStamina - amount >= 0)
        {
            CurrentStamina -= amount;
            StaminaBar.value = CurrentStamina;

            if(regen != null)
            {
                StopCoroutine(regen);
            }
           regen =  StartCoroutine(RegeanStamina());
        }
        else
        {
            Debug.Log("mouch ma3koul zaah chwaya stamina");
        }
    }
    private IEnumerator RegeanStamina()
    {
        yield return new WaitForSeconds(2);

        while(CurrentStamina < MaxStamina)
        {
            CurrentStamina += MaxStamina / 100;
            StaminaBar.value = CurrentStamina;
            yield return RegentTick;
            player.isTired = true;
        }
        regen = null;
    }
    
}
