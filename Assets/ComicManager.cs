using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ComicManager : MonoBehaviour
{

    public float doubleTapTime = 1f;
    private float elapsedTime;
    private int pressCount;
    public VideoPlayer vp;

    private void Update()
    {
        // count the number of times space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressCount++;
        }

        // if they pressed at least once
        if (pressCount > 0)
        {
            // count the time passed
            elapsedTime += Time.deltaTime;

            // if the time elapsed is greater than the time limit
            if (elapsedTime > doubleTapTime)
            {
                resetPressTimer();
            }
            else if (pressCount == 2) // otherwise if the press count is 2
            {
                SceneManager.LoadScene("Level 1");
                resetPressTimer();
            }
        }

        if (Input.GetKey(KeyCode.E))
        {
            vp.playbackSpeed = 0f;
        }
        else if (Input.GetKey(KeyCode.F))
        {
            vp.playbackSpeed = 2f;
        }
        else
        { 
            vp.playbackSpeed = 1f;
        }

    }

    //reset the press count & timer
    private void resetPressTimer()
    {
        pressCount = 0;
        elapsedTime = 0;
    }

}


