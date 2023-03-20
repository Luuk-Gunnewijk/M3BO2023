using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{
    PlayerMovement myPlayerMovement;

    bool isTakingDamage = false;

    void Awake()
    {
        myPlayerMovement = FindObjectOfType<PlayerMovement>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTakingDamage = true;
            if (isTakingDamage == true)
            {
                myPlayerMovement.TakingDamage();
            }
            
        }
    }
}
