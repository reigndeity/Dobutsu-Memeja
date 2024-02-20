using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameOutput : MonoBehaviour
{
    public TMPro.TextMeshProUGUI playername;
    public TMP_InputField playernameinput;

    void Start()
    {
        playername.text = PlayerPrefs.GetString("user_name");
    }

    public void Create()
    {
        playername.text = playernameinput.text;
        PlayerPrefs.SetString("user_name", playername.text);
        PlayerPrefs.Save();
    }
}