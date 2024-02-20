using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    public GameObject continuePause;
    public void ContinueGame()
    {
        continuePause.SetActive(false);
        GameObject.FindObjectOfType<GameManager>().isEscapeOn = false;
        Debug.Log("Game Continue!");
    }
}
