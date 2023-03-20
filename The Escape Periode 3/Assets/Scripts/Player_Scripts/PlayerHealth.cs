using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 3;

    CapsuleCollider2D myCapsuleCollider2D;

    public bool isAlive = true;

    void Start()
    {
        myCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        TestingDie();
        HealthReachesZero();
        //Debug.Log(health);
    }

    void TestingDie()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            health = health - 1;
            //Debug.Log(health);
            //Debug.Log(isAlive);
        }
    }

    public void LoseHealth()
    {
        health = health - 1;
    }

    public void HealthReachesZero()
    {
        if (health <= 0)
        {
            isAlive = false;
        }
    }
}
