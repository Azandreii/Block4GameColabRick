using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerCreditRoll : MonoBehaviour
{
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
