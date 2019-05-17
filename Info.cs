using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       // So the Code knows what an Image is in UNITY | working with user interface elements

public class Info : MonoBehaviour {

    public int score = 0, lives = 3, bulletsLeft = 5; // Default amount of score / lives of player / bullets player has
    int winScore = 6000;                    // Amount of points needed to win

    Vector3 lastCheckPoint;                 // Players last checkpoint is recorded here

    public Image[] hearts;                  // Declares an array | Stores multiple images in the variable
    public GameObject gameOverPanel;        // Access to the game over Panel | Display the game over screen
    public GameObject victoryPanel;         // The player sees this when they win
    public GameObject notEnough;            // Player does not have enough score to go home
    public GameObject optionsMenu;            // Player does not have enough score to go home
    public GameObject player;

    public Text bulletsText, scoreText, message;     // Variable controlling text in bullet and score text fields | Message from character

    // Use this for initialization
    void Start () {
        lastCheckPoint = transform.position;// Checkpoint of player = the current position
        UpdateLives(0);                     // checks the players amount of lives at the start of the game
        UpdateBullets(0);                   // Updates the text show at the start of game (20 instead of 000, then 19 after 1 shot)
        UpdateScore(0);
    }

    public void DeathReset()                //Function called when the player is killed
    {
        transform.position = lastCheckPoint;
        UpdateLives(-1);                    // On death then send the -1 variable to the function that deals with lives - sending -1 will loop through the loop and take away a single life
    }

    public void UpdatecheckPoint()
    {
        lastCheckPoint = transform.position;
    }

    public void UpdateLives(int l) // The l allows you too add lives or minus lives / even add multiple lives ECT..
    {
        lives += l;                // Lives is += (accumulating) if lives is 3 for example, and l is -1 then the lives will become 2 | if we send through 1 then it will become 4
        if (lives > 5)
        {
            lives = 5;             // Stops the player getting more than 5 lives maximum
        }
        for (int i = 0; i < 5; i++)
        {
            if (i < lives)                   // if i is less than the number of lives player has then...
            {
                hearts[i].enabled = true;   // if i is less than number of lives then makes heart image invisible
            }
            else
            {
                hearts[i].enabled = false;  // if i is more than number of lives then the heart image remains visible
            }
        }

        if (lives == 0)     // If the lives is equal to 0 then the gameover script will be run to end the game
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);  // For User interface objects | When the object is hidden you can change it to visible by setting the activity to true
        GetComponent<Controller2D>().enabled = false;   // Turns of the script Controller2D so the player can no longer move.
        Enemy[] enemies = FindObjectsOfType<Enemy>();   // This will look through the scene and find all the objects with the type "Enemy" - To turn all enemies off
        
        foreach (Enemy e in enemies)     // For each iterates through a list (in this case an array) | Creates a temporary instance of an enemy and make that one of the list 
        {
            e.enabled = false;          // All the enemies are tagged with the temporary e instance so they will all become false enability (Stops them from moving)
        }

        MenuScreen();
    }

    public void Victory()
    {
        if (score >= winScore)
        {
            victoryPanel.SetActive(true);
           
            MenuScreen();
                        
        }
        else if (score >= 0 && score <= winScore - 1)
        {
            notEnough.SetActive(true);
            message.text = "The door seems to be locked.. \nYou currently have " + score + " Paw Points.\n" + (winScore - score) + " left to collect. \n*Gilbert isnt Strong enough yet*";
        }

    }

    public void UpdateScore(int s)          // Function called to alter score of player 
    {
        score += s;
        scoreText.text = score.ToString();

    }

    public void UpdateBullets (int b)       // Function called to alter bullets of player
    {
        bulletsLeft += b;
        bulletsText.text = bulletsLeft.ToString();
    }

    public void UpdateMessage ()
    {
        if (notEnough)
        {
            notEnough.SetActive(false);
        }
    }

    public void MenuScreen()
    {
        optionsMenu.SetActive(true);

        GetComponent<Controller2D>().enabled = false;

        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach (Enemy e in enemies)
        {
            e.enabled = false;
        }
        message.text = "Well done you finished with a score of " + score + ".";
    }

        // Update is called once per frame
        //void Update () {
        //	
        //}
    }
