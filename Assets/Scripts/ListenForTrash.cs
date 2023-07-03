using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class ListenForTrash : MonoBehaviour
{

    public GameManager gameManager;
    public bool playerHasKey = false;
    public bool enoughTrash1 = false;
    public GameObject Trashometer;
    public int totalTrash = 0;
    public GameObject PlexLevel1;
   // public GameObject specificTrash;
    public AudioSource OST;
    public AudioClip OST2;
    public AudioClip OST3;
    public bool OST2DONE = false;
    public bool OST3DONE = false;

    // enable sprint after first trash ammount trashhold
    public bool canSprint = false;

    private void Update()
    {
        /*if ( enoughTrash1 && !specificTrash.activeSelf)
        {
            Destroy(PlexLevel1);
        }*/
    }

    private void OnEnable()
    {
        gameManager.gotKeyEvent.AddListener(PlayerGotTheKey);
        gameManager.TrashCollected.AddListener(Player15Trash);
    }

    private void OnDisable()
    {
        gameManager.gotKeyEvent.RemoveListener(PlayerGotTheKey);
        gameManager.TrashCollected.RemoveListener(Player15Trash);
    }

    private void PlayerGotTheKey()
    {
        playerHasKey = true;
    }

    private void Player15Trash(int trashAmount)
    {
        if (trashAmount >= 5)
        {
            enoughTrash1 = true;
            //gameManager.TrashCollected.RemoveListener(Player15Trash);
            canSprint = true;
            Trashometer.transform.GetChild(0).gameObject.SetActive(false);
            Trashometer.transform.GetChild(1).gameObject.SetActive(true);
            RenderSettings.fogDensity = 0.02f;
            if(!OST2DONE)
            {
                OST.clip = OST2;
                OST.Play();
                OST2DONE = true;
            }
            


        }
        if (trashAmount >= 20)
        {
            //enoughTrash = true;
            //gameManager.TrashCollected.RemoveListener(Player15Trash);
            Trashometer.transform.GetChild(1).gameObject.SetActive(false);
            Trashometer.transform.GetChild(2).gameObject.SetActive(true);
            RenderSettings.fogDensity = 0.01f;
            if (!OST3DONE)
            {
                OST.clip = OST3;
                OST.Play();
                OST3DONE = true;
            }

            
        }

    }

    /*private void OnCollisionEnter(Collision collision)
    {
       *if (collision.gameObject.tag == "Player" && playerHasKey == true)
        {
            Destroy(gameObject);
        } 

        if (collision.gameObject.tag == "Player" && enoughTrash == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collision.gameObject.tag == "Player" && playerHasKey == true)
        {
            Destroy(gameObject);
        }
    } */

}
