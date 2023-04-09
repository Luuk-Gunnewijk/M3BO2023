using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors_Script : MonoBehaviour
{
    public SpriteRenderer Door_01;
    public SpriteRenderer Door_02;

    AudioSource myAudioSource;
    
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        Door_01.enabled = true;
        Door_02.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(Door_02.enabled == true) { return; }
        if (other.tag == "Player")
        {
            myAudioSource.Play();
            Door_01.enabled = false;
            Door_02.enabled = true;
        }
    }
}
