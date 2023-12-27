using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject optionmenu;

    public void PlayGame()
    {
        SceneManager.LoadScene("Demo Scene");
    }

    public void GoToOption()
    {
        mainmenu.SetActive(false);
        optionmenu.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
