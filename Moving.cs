using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{

    float cameraRunTime;

    public Text timer;
    public GameObject optionsMenu;



    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        cameraRunTime += Time.deltaTime;
       

        timer.text = cameraRunTime.ToString();

        if(cameraRunTime > 0 && cameraRunTime < 18)
        {
            transform.Translate(0f, 0f, 1f * Time.deltaTime);
        }
        else if (cameraRunTime > 18 && cameraRunTime < 20)
        {
            transform.Translate(0f, -3f * Time.deltaTime, 0f); //D
        }
        else if (cameraRunTime > 20 && cameraRunTime < 36)
        {
            transform.Translate(0f, 0f, -1f * Time.deltaTime);
        }
        else if (cameraRunTime > 36 && cameraRunTime < 39)
        {
            transform.Translate(3f * Time.deltaTime, -5f * Time.deltaTime, 0f);
        }
        else if (cameraRunTime > 36 && cameraRunTime < 44)
        {

        }
        else if (cameraRunTime > 44 && cameraRunTime < 62)
        {
            transform.Translate(0f, 0f, 1f * Time.deltaTime);
        }
        else if (cameraRunTime > 62 && cameraRunTime < 70)
        {

        }
        else if (cameraRunTime > 70 && cameraRunTime < 72)
        {
            transform.Translate(0f, -3f * Time.deltaTime, 0f);
        }
        else if (cameraRunTime > 72 && cameraRunTime < 81)
        {
            transform.Translate(0f, 0f, -1f * Time.deltaTime);
        }
        else if (cameraRunTime > 81 && cameraRunTime < 83)
        {
            transform.Rotate(3f * Time.deltaTime, 0f, 22.5f * Time.deltaTime);
        }
        else if  (cameraRunTime > 84)
        {
            optionsMenu.SetActive(true);
        }






    }
}
