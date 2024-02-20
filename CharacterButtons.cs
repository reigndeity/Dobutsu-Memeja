using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nartotoUwimaki;
    public GameObject saskiUwuchiwa;
    public GameObject sakkeraHarnowo;
    public void CharacterButton()
    {
        GameObject.FindObjectOfType<GameManager>().canAttack = true;
        GameObject.FindObjectOfType<GameManager>().bgmAudioSource.Stop();
        GameObject.FindObjectOfType<GameManager>().bgmAudioSource.clip = GameObject.FindObjectOfType<GameManager>().backgroundMusic[1];
        GameObject.FindObjectOfType<GameManager>().bgmAudioSource.Play();
    }

}
