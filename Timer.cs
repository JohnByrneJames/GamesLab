using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    float timeLeft;         
    public float countDownTime; //Available in inspector
    public Text timerText;      //Text assigned to label
    public Text timerTextSinceUse;                          //Text assigned to delay (removable)
    public Text buttonText;                                 //Text assigned to button 

    public Material GreenMat, RedMat, YellowMat, OffMat;    //add public Materials to inspectors view - links the vairables to materials in the scene

    public GameObject redLight;                             //add public GameObjects to the inspectors view (link a object to change colour)
    public GameObject yellowLight;
    public GameObject greenLight;

    private bool bGreen = true;                              //Green 
    private bool bYellow = false;                            //Yellow
    private bool bRed = false;                               //Red
    private bool bRedYellow = false;                         //RedYellow
    private bool bGreenWait = false;                         //Green State of waiting (essentially is the delay between uses.
   
    private float fSecondsSinceChange = 15.0f;               //Overall run time of the traffic light (includes delay)
    private bool bHasButtonBeenPressed = false;              //Boolean checking for if button has been pressed

    Renderer redRend;                                       //Creates the renderer variable
    Renderer yellowRend;                                    
    Renderer greenRend;

	// Use this for initialization
	void Start () {
        timerText.text = "0";                           //Sets value of variable to 0
        redRend = redLight.GetComponent<Renderer>();    //Add renderer in start you can use them over and over again gets mesh renderer
        redRend.material = OffMat;
        yellowRend = yellowLight.GetComponent<Renderer>();
        yellowRend.material = OffMat;
        greenRend = greenLight.GetComponent<Renderer>();
        greenRend.material = OffMat;
    }
	
	// Update is called once per frame
	void Update () {

 //       fSecondSinceLastUse = 10.0f;
 //       fSecondSinceLastUse -= Time.deltaTime;  //Seperate Variable tracking time since last button press

        timerText.text = timeLeft.ToString();   //assigns the value stored in timeLeft into timerText and converts it to a string
        buttonText.text = "WAIT"; buttonText.fontSize = 20; buttonText.fontStyle = FontStyle.Bold;

        if (timeLeft >= 0)                            // (2) - Keeps track of traffic light (ON / OFF) Statement
        {
            timeLeft -= Time.deltaTime;               // Counts down in delta time, times based on frames (Real time)            
        }
        else
        {
            redRend.material = OffMat;                // (Red Light) Off
            yellowRend.material = OffMat;             // (Yellow Light) Off
            greenRend.material = GreenMat;            // (Green Light) On
            bHasButtonBeenPressed = false;            // (Button pressed) False
            timerText.text = "0";                     // Sets a whole number "0" as the timers display
        }

        if (timeLeft <=13 && timeLeft >=11 && bYellow)   // (3) - Keeps track of the colours shown on the bulbs / Keep Yellow Light on for 1 Second
        {
            bRed = true;                               // Is Red light on? Yes [For Next if statement to work]
            bYellow = false;                           // Is Yellow light on? No
            yellowRend.material = YellowMat;           // (Yellow Light) On
            greenRend.material = OffMat;               // (Green Light) Off
        }
        else if (timeLeft <=11 && timeLeft >=7 && bRed) // Keep Red Light on for 4 Seconds      
        {
            bRed = false;                              // Is Red light on? No [For next if statement to work]
            bRedYellow = true;                         // Is Yellow light on? Yes 
            redRend.material = RedMat;                 // (Red Light) On
            yellowRend.material = OffMat;              // (Yellow Light) Off
        }
        else if (timeLeft <=7 && timeLeft >=5 && bRedYellow) // Keep Red and Yellow on for 1 Second
        {
            bRedYellow = false;                        // Is Yellow light on? No
            bGreenWait = true;                         // Is Green light on? Yes
            yellowRend.material = YellowMat;           // (Yellow Light) On
        }
        else if (timeLeft <= 5 && timeLeft >=1 && bGreenWait) // Keep Light Green for 4 seconds (illusion of a delay)
        {

            bGreenWait = false;                        // Is Green Light delay on? No
            bGreen = true;                             // Is Green Light on Yes
            greenRend.material = GreenMat;             // (Green Light) On
            yellowRend.material = OffMat;
            redRend.material = OffMat;
        }
        
    }

    public void startTimer()
    {

        if (!bHasButtonBeenPressed && bGreen)
        {
            bGreen = false;
            bYellow = true;
            greenRend.material = GreenMat;
            yellowRend.material = OffMat; 
            timeLeft = countDownTime;   //Assigns the value stored in countDownTime into timeLeft whenever this function is called
            fSecondsSinceChange = 15f;
            bHasButtonBeenPressed = true;
           
        }
    }
}
