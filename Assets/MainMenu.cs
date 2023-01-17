using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject panel;

    public void PlayGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void SupportMenu() 
    {
        if (panel.activeSelf)
            panel.SetActive(false);
        else
            panel.SetActive(true);
    }

    public void OpenLink(string url) {
        Application.OpenURL(url);
        Debug.Log("Link open?");
    }
}
