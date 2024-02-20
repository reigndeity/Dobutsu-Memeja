using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState : MonoBehaviour
{
    public int CardElement; // Dog beats Cat, Cat beats Mouse, Rat beats Dog
    public int CardValue; // 1-9 of each card (1-9 Dog, 1-9 Cat, 1-9 Rat)
    public bool playerRoundWin;
    public bool enemyRoundWin;
    public int EnemyCardElement;
    public int EnemyCardValue;

    public void ChosenCard()
    {

        if (GameObject.FindObjectOfType<GameManager>().canAttack == true)
        {
            GameObject.FindObjectOfType<GameManager>().playerAttackElement = CardElement;
            GameObject.FindObjectOfType<GameManager>().playerAttackValue = CardValue;
            GameObject.FindObjectOfType<GameManager>().Battle();
            if (playerRoundWin = GameObject.FindObjectOfType<GameManager>().isPlayerWon)
            {
                // ============================= DOG ANIMATIONS =============================
                // Dog Bark
                if ((CardElement == 0 && CardValue == 1) || (CardElement == 0 && CardValue == 2) || (CardElement == 0 && CardValue == 3))
                {
                    GameObject.FindObjectOfType<AttackEffects>().DogBarkSpriteArray();
                }
                // Dog Scratch
                if ((CardElement == 0 && CardValue == 4) || (CardElement == 0 && CardValue == 5) || (CardElement == 0 && CardValue == 6))
                {
                    GameObject.FindObjectOfType<AttackEffects>().DogScratchSpriteArray();
                }
                // Dog Bite
                if ((CardElement == 0 && CardValue == 7) || (CardElement == 0 && CardValue == 8) || (CardElement == 0 && CardValue == 9))
                {
                    GameObject.FindObjectOfType<AttackEffects>().DogBiteSpriteArray();
                }
                // ============================= CAT ANIMATIONS =============================
                // Cat Meow
                if ((CardElement == 1 && CardValue == 1) || (CardElement == 1 && CardValue == 2) || (CardElement == 1 && CardValue == 3))
                {
                    GameObject.FindObjectOfType<AttackEffects>().CatMeowSpriteArray();
                }
                // Cat Scratch
                if ((CardElement == 1 && CardValue == 4) || (CardElement == 1 && CardValue == 5) || (CardElement == 1 && CardValue == 6))
                {
                    GameObject.FindObjectOfType<AttackEffects>().CatScratchSpriteArray();
                }
                // Cat Bite
                if ((CardElement == 1 && CardValue == 7) || (CardElement == 1 && CardValue == 8) || (CardElement == 1 && CardValue == 9))
                {
                    GameObject.FindObjectOfType<AttackEffects>().CatBiteSpriteArray();
                }
                // ============================= RAT ANIMATIONS =============================
                // Rat Squeak
                if ((CardElement == 2 && CardValue == 1) || (CardElement == 2 && CardValue == 2) || (CardElement == 2 && CardValue == 3))
                {
                    GameObject.FindObjectOfType<AttackEffects>().RatSqueakSpriteArray();
                }
                // Rat Scratch
                if ((CardElement == 2 && CardValue == 4) || (CardElement == 2 && CardValue == 5) || (CardElement == 2 && CardValue == 6))
                {
                    GameObject.FindObjectOfType<AttackEffects>().RatScratchSpriteArray();
                }
                // Rat Bite
                if ((CardElement == 2 && CardValue == 7) || (CardElement == 2 && CardValue == 8) || (CardElement == 2 && CardValue == 9))
                {
                    GameObject.FindObjectOfType<AttackEffects>().RatBiteSpriteArray();
                }

            }
            GameObject.FindObjectOfType<UISpriteAnimation>().PlayBattleSprite();
            GameObject.FindObjectOfType<EnemyUISpriteAnimation>().EnemyPlayBattleSprite();
            Destroy(gameObject);
        }

    }

}