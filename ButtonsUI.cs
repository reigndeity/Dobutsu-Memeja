using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsUI : MonoBehaviour
{
    

    public GameObject backButtonCYCScreen;
    public GameObject submitButton;
    public GameObject nartotoUwimaki;
    public GameObject saskiUwuchiwa;
    public GameObject sakkeraHarnowo;
    public GameObject animationScreen;

    private void enableButtons()
    {
        backButtonCYCScreen.SetActive(true);
        nartotoUwimaki.SetActive(true);
        saskiUwuchiwa.SetActive(true);
        sakkeraHarnowo.SetActive(true);
        
    }

    public void submitbutton()
    {
        
        animationScreen.SetActive(true);
        backButtonCYCScreen.SetActive(false);
        nartotoUwimaki.SetActive(false);
        saskiUwuchiwa.SetActive(false);
        sakkeraHarnowo.SetActive(false);
        Invoke("enableButtons", 1.25f);
    }

}


