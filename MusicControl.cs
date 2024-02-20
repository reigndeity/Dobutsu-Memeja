using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public bool isMusicMute = false;
    
    public void MuteButtonMusic()
    {
        if (isMusicMute == false)
        {
            isMusicMute = true;
            GameObject.FindObjectOfType<GameManager>().bgmAudioSource.volume = 0.0f;
            

        }
    }
    public void OnButtonMusic()
    {
        if (isMusicMute == true)
        {
            isMusicMute = false;
            GameObject.FindObjectOfType<GameManager>().bgmAudioSource.volume = 0.25f;

        }
    }

    
}
