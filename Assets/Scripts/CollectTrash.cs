using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTrash : MonoBehaviour
{

    public GameManager gameManager;

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Trash")
        {
            target.gameObject.SetActive(false);
            gameManager.addTrash();
            Debug.Log("Collected Trash");


        }
    }

}
