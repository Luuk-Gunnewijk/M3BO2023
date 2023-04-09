using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;

    CapsuleCollider2D myCapsuleCollider2D;
    LevelManager_script myLevelManager_Script;
    PlayerAudio_Script myPlayerAudio_Script;
    Animator myAnimator;

    public bool isAlive = true;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myLevelManager_Script = FindObjectOfType<LevelManager_script>();
        myPlayerAudio_Script = FindObjectOfType<PlayerAudio_Script>();
        myCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        HealthReachesZero();
        //Debug.Log(health);
    }

    public void LoseHealth()
    {
        myPlayerAudio_Script.Grunt1Sound();
        health = health - 1;
    }

    public void HealthReachesZero()
    {
        if (health <= 0)
        {
            isAlive = false;
            myAnimator.SetBool("IsDying", true);
            myPlayerAudio_Script.Grunt2Sound();
            myLevelManager_Script.LoadMainMenu();
        }
    }
}
