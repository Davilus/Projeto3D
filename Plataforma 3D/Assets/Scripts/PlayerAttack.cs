using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public bool attacking = false;
    public GameObject hitBox;

    public float attackingCounter;
    public float attackingLength = 1f;



    private void Update()
    {
        if (attackingCounter > 0)
        {
            attackingCounter -= Time.deltaTime;
        }
        else
        {
            hitBox.SetActive(false);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        attackingCounter = attackingLength;
        hitBox.SetActive(true);
        attacking = true;
        
    }
}
