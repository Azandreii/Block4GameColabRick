using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextCurrentTotalTrash : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int scoreValue;
    public int refferenceValue;

    GameObject trashValueObj;
    GameManager trashValue;

    void Start()
    {
        trashValueObj = GameObject.Find("GameManager");
        trashValue = trashValueObj.GetComponent<GameManager>();

        scoreText = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        scoreValue = trashValue.collectedTrash;
        scoreText.text = "Trash \r\ncollected: " + scoreValue;
    }
}
