using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpmedicines_Script : MonoBehaviour
{
    GameObject myMedicinesObject;
    Score myScoreScript;
    AudioSource myAudioSource;

    void Start()
    {
        myScoreScript = FindObjectOfType<Score>();
        myMedicinesObject = GetComponent<GameObject>();
        myAudioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            myAudioSource.Play();
            myScoreScript.AddToScore();
            Destroy(gameObject, 0.5f);
        }
    }
}
