using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUISpriteAnimation : MonoBehaviour
{
    public Image m_Image;

    public Sprite[] m_IdleSpriteArray;
    public Sprite[] m_BattleSpriteArray;

    public float m_Speed = 0.13f;

    private Coroutine m_CoroutineAnim = null;

    public void EnemyPlayIdleSprite()
    {
        if (m_CoroutineAnim != null)
        {
            StopCoroutine(m_CoroutineAnim);
        }
        StartSpriteAnimation(m_IdleSpriteArray);
    }

    public void EnemyPlayBattleSprite()
    {
        if (m_CoroutineAnim != null)
        {
            StopCoroutine(m_CoroutineAnim);
        }
        StartSpriteAnimation(m_BattleSpriteArray);

        Invoke("EnemyPlayIdleSprite", 1.56f);
    }

    private void StartSpriteAnimation(Sprite[] spriteArray)
    {
        m_CoroutineAnim = StartCoroutine(PlaySpriteAnimation(spriteArray));
    }

    private IEnumerator PlaySpriteAnimation(Sprite[] spriteArray)
    {
        int index = 0;

        while (index < spriteArray.Length)
        {
            m_Image.sprite = spriteArray[index];
            index++;

            if (index >= spriteArray.Length)
            {
                index = 0;
            }

            yield return new WaitForSeconds(m_Speed);
        }

        // Switch back to idle sprite after the animation finishes.
        EnemyPlayIdleSprite();
    }
}
