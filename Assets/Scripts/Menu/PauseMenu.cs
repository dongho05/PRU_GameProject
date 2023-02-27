using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
  
    void Start()
    {
        // pause the game when added to the scene
        Time.timeScale = 0;
    }

    /// <summary>
    /// Handles the on click event from the Resume button
    /// </summary>
    public void HandleResumeButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClick);

        // unpause game and destroy menu
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    /// <summary>
    /// Handles the on click event from the Quit button
    /// </summary>
    public void HandleMainMenuButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ExitClick);

        // unpause game, destroy menu, and go to main menu
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }

    public void HandleReplayButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClick);

        // unpause game, destroy menu, and go to main menu
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.GamePlay);
    }

}
