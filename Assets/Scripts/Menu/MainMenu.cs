using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void HandlePlayButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.PlayClick);
        MenuManager.GoToMenu(MenuName.GamePlay);
    }

    ///// <summary>
    ///// Handles the on click event from the high score button
    ///// </summary>
    //public void HandleHighScoreButtonOnClickEvent()
    //{
    //    AudioManager.Play(AudioClipName.MenuButtonClick);
    //    MenuManager.GoToMenu(MenuName.HighScore);
    //}

    /// <summary>
    /// Handles the on click event from the quit button
    /// </summary>
    public void HandleQuitButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ExitClick);
        Application.Quit();
    }
}
