 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;

public class GameManagerMainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("ComicIntroTest");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Support()
    {
        Application.OpenURL("https://www.worldcleanupday.nl/");
    }

}
