using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject gameUI;
    
    public string loadCredits;
    public string MainMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
        gameUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
        Time.timeScale = pauseMenuUI.activeSelf ? 0 : 1;
        gameUI.SetActive(!pauseMenuUI.activeSelf);
    }
    
    //Loading credits scene
    public void loadCreditsButton()
    {
        SceneManager.LoadScene(loadCredits);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(MainMenu);
    }
    
    
    //Close game button.
    public void QuitGameButton()
    {
        Application.Quit();
        Debug.Log("Quit button pressed");
    }
}
