using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackEffects : MonoBehaviour
{
    public Image m_Image;
    [Header("Dog Attack Animation")]
    public Sprite[] m_dogBarkSpriteArray;
    public Sprite[] m_dogScratchSpriteArray;
    public Sprite[] m_dogBiteSpriteArray;
    [Header("Cat Attack Animation")]
    public Sprite[] m_catMeowSpriteArray;
    public Sprite[] m_catScratchSpriteArray;
    public Sprite[] m_catBiteSpriteArray;
    [Header("Rat Attack Animation")]
    public Sprite[] m_ratSqueakSpriteArray;
    public Sprite[] m_ratScratchSpriteArray;
    public Sprite[] m_ratBiteSpriteArray;




    public float m_Speed = 0.10f;

    

    public void Start()
    {
        m_Image.enabled = false;

    }
    // Dog Attack Animations
    public void DogBarkSpriteArray()
    {
        m_Image.enabled = true;

        StartCoroutine(DogBark_PlayAnimation());

    }

    IEnumerator DogBark_PlayAnimation()
    {
        for (int i = 0; i < m_dogBarkSpriteArray.Length; i++)
        {
            m_Image.sprite = m_dogBarkSpriteArray[i];
            yield return new WaitForSeconds(m_Speed);
        }

        // Animation is done, deactivate the image component
        m_Image.enabled = false;
    }

    public void DogScratchSpriteArray()
    {
        m_Image.enabled = true;

        StartCoroutine(DogScratch_PlayAnimation());
    }

    IEnumerator DogScratch_PlayAnimation()
    {
        for (int i = 0; i < m_dogScratchSpriteArray.Length; i++)
        {
            m_Image.sprite = m_dogScratchSpriteArray[i];
            yield return new WaitForSeconds(m_Speed);
        }

        // Animation is done, deactivate the image component
        m_Image.enabled = false;
    }

    public void DogBiteSpriteArray()
    {
        m_Image.enabled = true;

        StartCoroutine(DogBite_PlayAnimation());
    }

    IEnumerator DogBite_PlayAnimation()
    {
        for (int i = 0; i < m_dogBiteSpriteArray.Length; i++)
        {
            m_Image.sprite = m_dogBiteSpriteArray[i];
            yield return new WaitForSeconds(m_Speed);
        }

        // Animation is done, deactivate the image component
        m_Image.enabled = false;
    }

    // Cat Attack Animations
    public void CatMeowSpriteArray()
    {
        m_Image.enabled = true;

        StartCoroutine(CatMeow_PlayAnimation());
        
    }

    IEnumerator CatMeow_PlayAnimation()
    {
        for (int i = 0; i < m_catMeowSpriteArray.Length; i++)
        {
            m_Image.sprite = m_catMeowSpriteArray[i];
            yield return new WaitForSeconds(m_Speed);
        }

        // Animation is done, deactivate the image component
        m_Image.enabled = false;
    }

    public void CatScratchSpriteArray()
    {
        m_Image.enabled = true;

        StartCoroutine(CatScratch_PlayAnimation());
    }

    IEnumerator CatScratch_PlayAnimation()
    {
        for (int i = 0; i < m_catScratchSpriteArray.Length; i++)
        {
            m_Image.sprite = m_catScratchSpriteArray[i];
            yield return new WaitForSeconds(m_Speed);
        }

        // Animation is done, deactivate the image component
        m_Image.enabled = false;
    }

    public void CatBiteSpriteArray()
    {
        m_Image.enabled = true;

        StartCoroutine(CatBite_PlayAnimation());
    }

    IEnumerator CatBite_PlayAnimation()
    {
        for (int i = 0; i < m_catBiteSpriteArray.Length; i++)
        {
            m_Image.sprite = m_catBiteSpriteArray[i];
            yield return new WaitForSeconds(m_Speed);
        }

        // Animation is done, deactivate the image component
        m_Image.enabled = false;
    }

    // Rat Attack Animations
    public void RatSqueakSpriteArray()
    {
        m_Image.enabled = true;

        StartCoroutine(RatSqueak_PlayAnimation());

    }

    IEnumerator RatSqueak_PlayAnimation()
    {
        for (int i = 0; i < m_ratSqueakSpriteArray.Length; i++)
        {
            m_Image.sprite = m_ratSqueakSpriteArray[i];
            yield return new WaitForSeconds(m_Speed);
        }

        // Animation is done, deactivate the image component
        m_Image.enabled = false;
    }

    public void RatScratchSpriteArray()
    {
        m_Image.enabled = true;

        StartCoroutine(RatScratch_PlayAnimation());
    }

    IEnumerator RatScratch_PlayAnimation()
    {
        for (int i = 0; i < m_ratScratchSpriteArray.Length; i++)
        {
            m_Image.sprite = m_ratScratchSpriteArray[i];
            yield return new WaitForSeconds(m_Speed);
        }

        // Animation is done, deactivate the image component
        m_Image.enabled = false;
    }

    public void RatBiteSpriteArray()
    {
        m_Image.enabled = true;

        StartCoroutine(RatBite_PlayAnimation());
    }

    IEnumerator RatBite_PlayAnimation()
    {
        for (int i = 0; i < m_ratBiteSpriteArray.Length; i++)
        {
            m_Image.sprite = m_ratBiteSpriteArray[i];
            yield return new WaitForSeconds(m_Speed);
        }

        // Animation is done, deactivate the image component
        m_Image.enabled = false;
    }
}
