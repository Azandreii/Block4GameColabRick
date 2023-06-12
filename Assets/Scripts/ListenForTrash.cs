using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListenForTrash : MonoBehaviour
{

    public GameManager gameManager;
    public bool playerHasKey = false;
    public bool enoughTrash = false;
    public GameObject Trashometer;
    public int totalTrash = 0;

    // enable sprint after first trash ammount trashhold
    public bool canSprint = false;

    private void Update()
    {
        
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
        if (trashAmount >= 3)
        {
            //enoughTrash = true;
            //gameManager.TrashCollected.RemoveListener(Player15Trash);
            canSprint = true;
            Trashometer.transform.GetChild(0).gameObject.SetActive(false);
            Trashometer.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (trashAmount >= 6)
        {
            //enoughTrash = true;
            //gameManager.TrashCollected.RemoveListener(Player15Trash);
            Trashometer.transform.GetChild(1).gameObject.SetActive(false);
            Trashometer.transform.GetChild(2).gameObject.SetActive(true);
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
