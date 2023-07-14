using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject PauseMenu, GameUI;
    public Button pauseButton;
    [SerializeField]
    private Sprite pauseOn, pauseOff;
    public string[] newscene = { "Game", "Lobby" };
    public void returnToLobby()
    {
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }
    public void SwitchPause()
    {
        switch (Time.timeScale)
        {
            case 1:
                Time.timeScale = 0;
                pauseButton.GetComponent<Image>().sprite = pauseOn;
                GameUI.SetActive(false);
                PauseMenu.SetActive(true);
                break;
            case 0:
                Time.timeScale = 1;
                PauseMenu.SetActive(!PauseMenu.activeSelf);
                GameUI.SetActive(!GameUI.activeSelf);
                pauseButton.GetComponent<Image>().sprite = pauseOff;
                break;
        }
    }
}
