using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EventSound : MonoBehaviour
{
    AudioSource mySourse;
    public AudioClip open;
    public AudioClip close;
    public AudioClip neverClose;

    public AudioClip List;


    void Start()
    {
        mySourse = GetComponent<AudioSource>();
    }

    public void VoidEventSoundOpen()
    {
        mySourse.PlayOneShot(open);
    }

    public void VoidEventSoundClose()
    {
        mySourse.PlayOneShot(close);
    }

    public void VoidEventSoundNeverClose()
    {
        mySourse.PlayOneShot(neverClose);
    }

    public void VoidEventSoundList()
    {
        mySourse.PlayOneShot(List);
    }
}
