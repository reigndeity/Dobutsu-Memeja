using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttackEffects : MonoBehaviour
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

    private Coroutine m_CoroutineAnim = null;

    public void Start()
    {
        m_Image.enabled = false;

    }
    // Dog Attack Animations
    public void EnemyDogBarkSpriteArray()
    {
        m_Image.enabled = true;

        StartCoroutine(EnemyDogBark_PlayAnimation());

    }

    IEnumerator EnemyDogBark_PlayAnimation()
    {
        for (int i = 0; i < m_dogBarkSpriteArray.Length; i++)
        {
            m_Image.sprite = m_dogBarkSpriteArray[i];
            yield return new WaitForSeconds(m_Speed);
        }

        // Animation is done, deactivate the image component
        m_Image.enabled = false;
    }

    public void EnemyDogScratchSpriteArray()
    {
        m_Image.enabled = true;

        StartCoroutine(EnemyDogScratch_PlayAnimation());
    }

    IEnumerator EnemyDogScratch_PlayAnimation()
    {
        for (int i = 0; i < m_dogScratchSpriteArray.Length; i++)
        {
            m_Image.sprite = m_dogScratchSpriteArray[i];
            yield return new WaitForSeconds(m_Speed);
        }

        // Animation is done, deactivate the image component
        m_Image.enabled = false;
    }

    public void EnemyDogBiteSpriteArray()
    {
        m_Image.enabled = true;

        StartCoroutine(EnemyDogBite_PlayAnimation());
    }

    IEnumerator EnemyDogBite_PlayAnimation()
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
    public void EnemyCatMeowSpriteArray()
    {
        m_Image.enabled = true;

        StartCoroutine(EnemyCatMeow_PlayAnimation());

    }

    IEnumerator EnemyCatMeow_PlayAnimation()
    {
        for (int i = 0; i < m_catMeowSpriteArray.Length; i++)
        {
            m_Image.sprite = m_catMeowSpriteArray[i];
            yield return new WaitForSeconds(m_Speed);
        }

        // Animation is done, deactivate the image component
        m_Image.enabled = false;
    }

    public void EnemyCatScratchSpriteArray()
    {
        m_Image.enabled = true;

        StartCoroutine(EnemyCatScratch_PlayAnimation());
    }

    IEnumerator EnemyCatScratch_PlayAnimation()
    {
        for (int i = 0; i < m_catScratchSpriteArray.Length; i++)
        {
            m_Image.sprite = m_catScratchSpriteArray[i];
            yield return new WaitForSeconds(m_Speed);
        }

        // Animation is done, deactivate the image component
        m_Image.enabled = false;
    }

    public void EnemyCatBiteSpriteArray()
    {
        m_Image.enabled = true;

        StartCoroutine(EnemyCatBite_PlayAnimation());
    }

    IEnumerator EnemyCatBite_PlayAnimation()
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
    public void EnemyRatSqueakSpriteArray()
    {
        m_Image.enabled = true;

        StartCoroutine(EnemyRatSqueak_PlayAnimation());

    }

    IEnumerator EnemyRatSqueak_PlayAnimation()
    {
        for (int i = 0; i < m_ratSqueakSpriteArray.Length; i++)
        {
            m_Image.sprite = m_ratSqueakSpriteArray[i];
            yield return new WaitForSeconds(m_Speed);
        }

        // Animation is done, deactivate the image component
        m_Image.enabled = false;
    }

    public void EnemyRatScratchSpriteArray()
    {
        m_Image.enabled = true;

        StartCoroutine(EnemyRatScratch_PlayAnimation());
    }

    IEnumerator EnemyRatScratch_PlayAnimation()
    {
        for (int i = 0; i < m_ratScratchSpriteArray.Length; i++)
        {
            m_Image.sprite = m_ratScratchSpriteArray[i];
            yield return new WaitForSeconds(m_Speed);
        }

        // Animation is done, deactivate the image component
        m_Image.enabled = false;
    }

    public void EnemyRatBiteSpriteArray()
    {
        m_Image.enabled = true;

        StartCoroutine(EnemyRatBite_PlayAnimation());
    }

    IEnumerator EnemyRatBite_PlayAnimation()
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
