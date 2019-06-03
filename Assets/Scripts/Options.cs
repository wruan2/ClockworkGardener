using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Options : MonoBehaviour
{
    AudioSource audioSource;
    bool muted = false;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

  
    public void Mute()
    {
        if (muted == false)
        {
            audioSource.mute = !audioSource.mute;
            muted = true;
        }
        else
        {
            audioSource.mute = !audioSource.mute;
            muted = false;
        }
    }
}
