using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionAnimation : MonoBehaviour
{
    public Image m_Image;
    public Sprite[] m_SpriteArray;
    public float m_Speed = 0.02f;

    private int m_IndexSprite;

    public void Func_PlayUIAnim()
    {
        StartCoroutine(Func_PlayAnimUI());
    }

    IEnumerator Func_PlayAnimUI()
    {
        for (int i = 0; i < m_SpriteArray.Length; i++)
        {
            m_Image.sprite = m_SpriteArray[i];
            yield return new WaitForSeconds(m_Speed);
        }

        // Animation is done, deactivate the image component
        m_Image.enabled = false;
    }
}


