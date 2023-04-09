using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio_Script : MonoBehaviour
{
    [Header("RunningSound")]
    [SerializeField] AudioClip JumpClip;
    [SerializeField][Range(0f, 1f)] float JumpVolume = 1f;

    [Header("Grunt1Sound")]
    [SerializeField] AudioClip grunt1Clip;
    [SerializeField][Range(0f, 1f)] float grunt1Volume = 1f;

    [Header("Grunt2Sound")]
    [SerializeField] AudioClip grunt2Clip;
    [SerializeField][Range(0f, 1f)] float grunt2Volume = 1f;

    public GameObject Player;

    public void JumpSound()
    {
        AudioSource.PlayClipAtPoint(JumpClip, Player.transform.position,  JumpVolume);   
    }
    public void Grunt1Sound()
    {
        AudioSource.PlayClipAtPoint(grunt1Clip, Player.transform.position, grunt1Volume);
    }

    public void Grunt2Sound()
    {
        AudioSource.PlayClipAtPoint(grunt2Clip, Player.transform.position, grunt2Volume);
    }



}
