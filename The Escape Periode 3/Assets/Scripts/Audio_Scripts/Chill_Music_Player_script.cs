using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chill_Music_Player_script : MonoBehaviour
{
    AudioSource myAudioScource;

    float waitForMusicToEnd = 25f;
    void Start()
    {
        myAudioScource = GetComponent<AudioSource>();
        StartCoroutine(StartMusicAfterTime());
    }

    IEnumerator StartMusicAfterTime()
    {
        yield return new WaitForSeconds(waitForMusicToEnd);
        myAudioScource.Play();
    }
}
