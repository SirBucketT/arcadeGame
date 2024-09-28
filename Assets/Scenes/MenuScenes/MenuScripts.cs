using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{
    public string GameWorld;
    public string loadCredits;
    public string exitGame;

    
    //start game scene
    public void startGameButton()
    {
        SceneManager.LoadScene(GameWorld);
    }

    
    //Loading credits scene
    public void loadCreditsButton()
    {
        SceneManager.LoadScene(loadCredits);
    }

    
    
    //Close game button.
    public void exitGameButton()
    {
        Application.Quit();
    }
}
