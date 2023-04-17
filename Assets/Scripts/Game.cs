using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] TMP_Text resultText;
    [SerializeField] TMP_Text computerChoiceText;
    [SerializeField] Button rockButton;
    [SerializeField] Button paperButton;
    [SerializeField] Button scissorsButton;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Button replayButton;
    [SerializeField] TMP_Text countdownText;

    private int playerScore = 0;
    private int computerScore = 0;
    private int roundsPlayed = 0;

    private void Start()
    {
        // Add event listeners for the rock, paper, and scissors buttons
        rockButton.onClick.AddListener(OnRockButtonClick);
        paperButton.onClick.AddListener(OnPaperButtonClick);
        scissorsButton.onClick.AddListener(OnScissorsButtonClick);

        // Disable the replay button, computer choice text, and game buttons initially
        replayButton.gameObject.SetActive(false);
        computerChoiceText.gameObject.SetActive(false);
        rockButton.interactable = false;
        paperButton.interactable = false;
        scissorsButton.interactable = false;

        // Start the countdown coroutine
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        countdownText.gameObject.SetActive(true);

        // Display "3" for 1 second
        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        // Display "2" for 1 second
        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        // Display "1" for 1 second
        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        // Display "Go!" for 1 second, enable game buttons, and hide countdown text
        countdownText.text = "Go!";
        rockButton.interactable = true;
        paperButton.interactable = true;
        scissorsButton.interactable = true;
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);
    }

    private void OnRockButtonClick()
    {
        PlayRound(0);
    }

    private void OnPaperButtonClick()
    {
        PlayRound(1);
    }

    private void OnScissorsButtonClick()
    {
        PlayRound(2);
    }

    private void PlayRound(int playerChoice)
    {
        // Increment the rounds played counter and determine computer's choice
        roundsPlayed++;
        int computerChoice = Random.Range(0, 3);

        // Set the computer choice text and make it visible
        string computerChoiceString = "";
        if (computerChoice == 0)
        {
            computerChoiceString = "rock";
        }
        else if (computerChoice == 1)
        {
            computerChoiceString = "paper";
        }
        else if (computerChoice == 2)
        {
            computerChoiceString = "scissors";
        }
        computerChoiceText.text = "Computer chose " + computerChoiceString + "!";
        computerChoiceText.gameObject.SetActive(true);

        // Determine the result of the round
        if (playerChoice == computerChoice)
        {
            resultText.text = "Tie!";
        }
        else if ((playerChoice == 0 && computerChoice == 2) || 
                 (playerChoice == 1 && computerChoice == 0) || 
                 (playerChoice == 2 && computerChoice == 1))
        {
            resultText.text = "You win!";
            playerScore++;
        }
        else
        {
            resultText.text = "You lose!";
            computerScore++;
        }

        // Update the score text and check if the game has ended
        scoreText.text = "Player: " + playerScore + " | Computer: " + computerScore;
        if (playerScore>= 3 || computerScore >= 3)
    {
        EndGame();
    }
}

private void EndGame()
{
    // Disable the game buttons, display the final result, and enable the replay button
    rockButton.interactable = false;
    paperButton.interactable = false;
    scissorsButton.interactable = false;

    if (playerScore > computerScore)
    {
        resultText.text = "You win the game!";
    }
    else if (computerScore > playerScore)
    {
        resultText.text = "You lose the game!";
    }
    else
    {
        resultText.text = "The game is tied!";
    }

    replayButton.gameObject.SetActive(true);
}

public void OnReplayButtonClick()
{
    // Reset the game state and replay the countdown
    playerScore = 0;
    computerScore = 0;
    roundsPlayed = 0;
    resultText.text = "";
    scoreText.text = "Player: 0 | Computer: 0";
    replayButton.gameObject.SetActive(false);
    computerChoiceText.gameObject.SetActive(false);
    StartCoroutine(StartCountdown());
}


    public void gameToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
}