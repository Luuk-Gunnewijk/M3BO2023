using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hazards : MonoBehaviour
{
    PlayerMovement myPlayerMovement;

    [SerializeField] float nextDamageTimer = 3f;

    bool isTakingDamage = false;
    bool canTakeDamge = true;

    void Awake()
    {
        myPlayerMovement = FindObjectOfType<PlayerMovement>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (canTakeDamge == false)
        {
            return;
        }
        if (other.tag == "Player")
        {
            isTakingDamage = true;
            if (isTakingDamage == true)
            {
                myPlayerMovement.TakingDamage();
                StartCoroutine(CanTakeDamageTimer());
                
            }
            
        }
    }

    IEnumerator CanTakeDamageTimer()
    {
        canTakeDamge = false;
        yield return new WaitForSeconds(nextDamageTimer);
        canTakeDamge = true;
    }
}
