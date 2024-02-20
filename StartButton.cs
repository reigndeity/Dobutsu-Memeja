using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public TMP_InputField inputFieldName;
    public Button startButton;

    void Start()
    {
        startButton.interactable = false;

        inputFieldName.onValueChanged.AddListener(OnNameInputValueChanged);
    }

    private void OnNameInputValueChanged(string newValue)
    {

        startButton.interactable = !string.IsNullOrEmpty(newValue);
    }
}
