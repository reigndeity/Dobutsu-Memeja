using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Variables")]
    public bool canAttack = false;
    public float remainingTimeToAttack = 10;
    public TextMeshProUGUI timeDisplay;
    public bool isEscapeOn = false;
    public GameObject pausePanel;
    public GameObject finalWinnerPanel;
    public TMPro.TextMeshProUGUI finalResult;
    public GameObject proceedWinButton;
    public GameObject proceedLoseButton;
    public GameObject continueButton;
    

    [Header("Player Variables")]
    // Player's chosen card  [0 = Dog | 1 = Cat | 2 = Rat]
    public int playerAttackElement;
    public int playerAttackValue;
    // Keeps track of the player's score
    public int playerDogPoint;
    public int playerCatPoint;
    public int playerRatPoint;
    // Card image display for player
    public Image playerAttackImage;
    public GameObject playerCardGameObject;
    // Player Win/Lose Determinator
    public bool isPlayerWon = false;


    [Header("Enemy Variables")]
    // Enemy's chosen card  [0 = Dog | 1 = Cat | 2 = Rat]
    public int enemyAttackElement;
    public int enemyAttackValue;
    // Keeps track of the enemy's score
    public int enemyDogPoint;
    public int enemyCatPoint;
    public int enemyRatPoint;
    // Card image display for enemy
    public Image enemyAttackImage;
    public GameObject enemyCardGameObject;
    // Enemy Win/Lose Determinator
    public bool isEnemyWon = false;
    public GameObject enemyCardDisplay;


    [Header("Cards")]
    // The place where the cards will spawn
    public Transform playerCardHolder;
    public GameObject[] cardPrefab;
    public Sprite[] cardImageDog;
    public Sprite[] cardImageCat;
    public Sprite[] cardImageRat;
    // A lsit tracker to prevent the same card form spawning in the card holder
    public List<int> spawnedCardValues = new List<int>();

    // Player Score Tracker
    [Header("Score")]
    public Transform playerDogScoreTracker;
    public Transform playerCatScoreTracker;
    public Transform playerRatScoreTracker;
    public Transform enemyDogScoreTracker;
    public Transform enemyCatScoreTracker;
    public Transform enemyRatScoreTracker;
    public GameObject dogScorePrefab;
    public GameObject catScorePrefab;
    public GameObject ratScorePrefab;

    [Header("BGM & SFX")]
    public AudioSource bgmAudioSource;
    public AudioClip[] backgroundMusic;

    // Simple For-Loop for cards to spawn 5 times under the START FUNCTION
    public void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Spawn();
        }
    }


    public void Update()
    {

        if (isEscapeOn == false)
        {
            if (canAttack == true)
            {
                // This will display the time text and remove the decimals
                float minutes = Mathf.Floor(remainingTimeToAttack / 60);
                float seconds = remainingTimeToAttack % 60;
                remainingTimeToAttack -= Time.deltaTime;
                timeDisplay.text = string.Format("{1:00}", minutes, seconds); // A string format is used here for a cleaner look to achieve the 10,09,08,... countdown

                if (remainingTimeToAttack <= 0)
                {
                    Debug.Log("The player ran out of time to select a card. Lose round!");
                    canAttack = false;

                    enemyAttackElement = Random.Range(0, 3);
                    enemyAttackValue = Random.Range(1, 10);

                    enemyCardGameObject.SetActive(true);

                    if (enemyAttackElement == 0)
                    {
                        enemyAttackImage.sprite = cardImageDog[enemyAttackValue - 1];
                    }
                    else if (enemyAttackElement == 1)
                    {
                        enemyAttackImage.sprite = cardImageCat[enemyAttackValue - 1];
                    }
                    else if (enemyAttackElement == 2)
                    {
                        enemyAttackImage.sprite = cardImageRat[enemyAttackValue - 1];
                    }

                    StartCoroutine(DelaySeconds());

                    EnemyWin();
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isEscapeOn == false)
            {
                isEscapeOn = true;
                pausePanel.SetActive(true);
                Debug.Log("Paused On");
            }
            else if (isEscapeOn == true)
            {
                isEscapeOn = false;
                pausePanel.SetActive(false);
                Debug.Log("Paused Off");
            }
        }
   
    }

    // Spawning of Cards FUNCTION
    public void Spawn()
    {
        int cardValue;
        GameObject[] existingCards = GameObject.FindGameObjectsWithTag("Cards");
        if (existingCards.Length < 5)
        {
            do
            {
                cardValue = Random.Range(0, 27); // Generate a random card value from 1 to 27 (1-9 Dog | 1-9 Cat | 1-9 Rat)
            } while (spawnedCardValues.Contains(cardValue)); // Keep generating until a unique card value is found

            spawnedCardValues.Add(cardValue); // Add the card value to the list of spawned cards

            // Instantiate the card with the corresponding value
            GameObject spawnedObject = Instantiate(cardPrefab[cardValue], playerCardHolder);

        }

    }


    // Main Gameplay FUNCTION
    public void Battle()
    {

        canAttack = false;
        // Enemy chosen cards randomizer
        enemyAttackElement = Random.Range(0, 3);
        enemyAttackValue = Random.Range(1, 10);

        // Show Cards
        playerCardGameObject.SetActive(true);
        enemyCardGameObject.SetActive(true);
        enemyCardDisplay.SetActive(false);


        // Player's chosen card element
        if (playerAttackElement == 0)
        {
            playerAttackImage.sprite = cardImageDog[playerAttackValue - 1];
        }
        else if (playerAttackElement == 1)
        {
            playerAttackImage.sprite = cardImageCat[playerAttackValue - 1];
        }
        else if (playerAttackElement == 2)
        {
            playerAttackImage.sprite = cardImageRat[playerAttackValue - 1];
        }
        // Enemy's chosen card element
        if (enemyAttackElement == 0)
        {
            enemyAttackImage.sprite = cardImageDog[enemyAttackValue - 1];
        }
        else if (enemyAttackElement == 1)
        {
            enemyAttackImage.sprite = cardImageCat[enemyAttackValue - 1];
        }
        else if (enemyAttackElement == 2)
        {
            enemyAttackImage.sprite = cardImageRat[enemyAttackValue - 1];
        }


        // Win | Lose | Tie Conditions
        if (playerAttackElement == enemyAttackElement)
        {
            if (playerAttackValue > enemyAttackValue)
            {
                Debug.Log("Player Won (Higher Attack Value)");
                PlayerWin();

            }
            else if (playerAttackValue < enemyAttackValue)
            {
                Debug.Log("Enemy Won (Higher Attack Value)");
                EnemyWin();

            }
            else if (playerAttackValue == enemyAttackValue)
            {
                Debug.Log("Tie (Same Attack Value)");

            }


        }
        else if ((playerAttackElement == 0 && enemyAttackElement == 1) || (playerAttackElement == 1 && enemyAttackElement == 2) || (playerAttackElement == 2 && enemyAttackElement == 0))
        {
            Debug.Log("Player Win (Elemental Advantage)");
            PlayerWin();

        }
        else
        {
            Debug.Log("Enemy Win (Elemental Advantage)");
            EnemyWin();

        }

        StartCoroutine(DelaySeconds());

    }

    IEnumerator DelaySeconds()
    {


        yield return new WaitForSeconds(2.68f);
        playerCardGameObject.SetActive(false);
        enemyCardGameObject.SetActive(false);
        enemyCardDisplay.SetActive(true);


        VictoryCheck();


        Spawn();

    }
    // Player Score Tracker FUNCTION
    public void PlayerWin()
    {
        isPlayerWon = true;
        if (playerAttackElement == 0)
        {
            GameObject playerDogScoreCounter = Instantiate(dogScorePrefab, playerDogScoreTracker);
            playerDogPoint++;
        }
        else if (playerAttackElement == 1)
        {
            GameObject playerCatScoreCounter = Instantiate(catScorePrefab, playerCatScoreTracker);
            playerCatPoint++;
        }
        else if (playerAttackElement == 2)
        {
            GameObject playerRatScoreCounter = Instantiate(ratScorePrefab, playerRatScoreTracker);
            playerRatPoint++;
        }
    }

    // Enemy Score Tracker FUNCTION
    public void EnemyWin()
    {
        isEnemyWon = true;
        if ((enemyAttackElement == 0 && enemyAttackValue == 1) || (enemyAttackElement == 0 && enemyAttackValue == 2) || (enemyAttackElement == 0 && enemyAttackValue == 3))
        {
            GameObject.FindObjectOfType<EnemyAttackEffects>().EnemyDogBarkSpriteArray();
            GameObject enemyDogScoreCounter = Instantiate(dogScorePrefab, enemyDogScoreTracker);
            enemyDogPoint++;
        }
        else if ((enemyAttackElement == 0 && enemyAttackValue == 4) || (enemyAttackElement == 0 && enemyAttackValue == 5) || (enemyAttackElement == 0 && enemyAttackValue == 6))
        {
            GameObject.FindObjectOfType<EnemyAttackEffects>().EnemyDogScratchSpriteArray();
            GameObject enemyDogScoreCounter = Instantiate(dogScorePrefab, enemyDogScoreTracker);
            enemyDogPoint++;
        }
        else if ((enemyAttackElement == 0 && enemyAttackValue == 7) || (enemyAttackElement == 0 && enemyAttackValue == 8) || (enemyAttackElement == 0 && enemyAttackValue == 9))
        {
            GameObject.FindObjectOfType<EnemyAttackEffects>().EnemyDogBiteSpriteArray();
            GameObject enemyDogScoreCounter = Instantiate(dogScorePrefab, enemyDogScoreTracker);
            enemyDogPoint++;
        }
        // Cat Attack Animations
        if ((enemyAttackElement == 1 && enemyAttackValue == 1) || (enemyAttackElement == 1 && enemyAttackValue == 2) || (enemyAttackElement == 1 && enemyAttackValue == 3))
        {
            GameObject.FindObjectOfType<EnemyAttackEffects>().EnemyCatMeowSpriteArray();
            GameObject enemyCatScoreCounter = Instantiate(catScorePrefab, enemyCatScoreTracker);
            enemyCatPoint++;
        }
        else if ((enemyAttackElement == 1 && enemyAttackValue == 4) || (enemyAttackElement == 1 && enemyAttackValue == 5) || (enemyAttackElement == 1 && enemyAttackValue == 6))
        {
            GameObject.FindObjectOfType<EnemyAttackEffects>().EnemyCatScratchSpriteArray();
            GameObject enemyCatScoreCounter = Instantiate(catScorePrefab, enemyCatScoreTracker);
            enemyCatPoint++;
        }
        else if ((enemyAttackElement == 1 && enemyAttackValue == 7) || (enemyAttackElement == 1 && enemyAttackValue == 8) || (enemyAttackElement == 1 && enemyAttackValue == 9))
        {
            GameObject.FindObjectOfType<EnemyAttackEffects>().EnemyCatBiteSpriteArray();
            GameObject enemyCatScoreCounter = Instantiate(catScorePrefab, enemyCatScoreTracker);
            enemyCatPoint++;
        }
        // Rat Attack Animations
        if ((enemyAttackElement == 2 && enemyAttackValue == 1) || (enemyAttackElement == 2 && enemyAttackValue == 2) || (enemyAttackElement == 2 && enemyAttackValue == 3))
        {
            GameObject.FindObjectOfType<EnemyAttackEffects>().EnemyRatSqueakSpriteArray();
            GameObject enemyRatScoreCounter = Instantiate(ratScorePrefab, enemyRatScoreTracker);
            enemyRatPoint++;
        }
        else if ((enemyAttackElement == 2 && enemyAttackValue == 4) || (enemyAttackElement == 2 && enemyAttackValue == 5) || (enemyAttackElement == 2 && enemyAttackValue == 6))
        {
            GameObject.FindObjectOfType<EnemyAttackEffects>().EnemyRatScratchSpriteArray();
            GameObject enemyRatScoreCounter = Instantiate(ratScorePrefab, enemyRatScoreTracker);
            enemyRatPoint++;
        }
        if ((enemyAttackElement == 2 && enemyAttackValue == 7) || (enemyAttackElement == 2 && enemyAttackValue == 8) || (enemyAttackElement == 2 && enemyAttackValue == 9))
        {
            GameObject.FindObjectOfType<EnemyAttackEffects>().EnemyRatBiteSpriteArray();
            GameObject enemyRatScoreCounter = Instantiate(ratScorePrefab, enemyRatScoreTracker);
            enemyRatPoint++;
        }
    }

    // This will check if the player or enemy wins
    // Fuck i need to add a panel here to display player name lol GG
    public void VictoryCheck()
    {
        if (playerDogPoint == 3 || playerCatPoint == 3 || playerRatPoint == 3)
        {
            finalWinnerPanel.SetActive(true);
            finalResult.text = ("\nwon against the enemy!");
            proceedWinButton.SetActive(true);
            bgmAudioSource.Stop();
            bgmAudioSource.clip = backgroundMusic[2];
            bgmAudioSource.Play();
            Debug.Log("The Player won the battle");
        }
        else if (playerDogPoint >= 1 && playerCatPoint >= 1 && playerRatPoint >= 1)
        {
            finalWinnerPanel.SetActive(true);
            finalResult.text = ("\nwon against the enemy!");
            proceedWinButton.SetActive(true);
            bgmAudioSource.Stop();
            bgmAudioSource.clip = backgroundMusic[2];
            bgmAudioSource.Play();
            Debug.Log("The Player won the battle");
        }
        else if (enemyDogPoint == 3 || enemyCatPoint == 3 || enemyRatPoint == 3)
        {
            finalWinnerPanel.SetActive(true);
            finalResult.text = ("\nhas been defeated by the enemy!");
            proceedLoseButton.SetActive(true);
            bgmAudioSource.Stop();
            bgmAudioSource.clip = backgroundMusic[3];
            bgmAudioSource.Play();
            Debug.Log("The Enemy won the battle");
        }
        else if (enemyDogPoint >= 1 && enemyCatPoint >= 1 && enemyRatPoint >= 1)
        {
            finalWinnerPanel.SetActive(true);
            finalResult.text = ("\nhas been defeated by the enemy!");
            proceedLoseButton.SetActive(true);
            bgmAudioSource.Stop();
            bgmAudioSource.clip = backgroundMusic[3];
            bgmAudioSource.Play();
            Debug.Log("The Enemy won the battle");
        }
        else
        {
            canAttack = true;
            isPlayerWon = false;
            isEnemyWon = false;
            remainingTimeToAttack = 10f;
        }

    }

}