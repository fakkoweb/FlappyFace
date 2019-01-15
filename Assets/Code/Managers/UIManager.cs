using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject StartScreenObject;
    public GameObject GameScreenObject;
    public GameObject PauseScreenObject;
    public Text PauseScreenText;
    public Button ResumeButton;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGameCommand()
    {
        PauseScreenObject.SetActive(false);
        StartScreenObject.SetActive(false);
        SceneManager.LoadScene("Game");
        GameScreenObject.SetActive(true);
        GameManager.instance.StartGame();
    }

    public void PauseGameCommand()
    {
        GameScreenObject.SetActive(false);

        GameManager.instance.PauseGame();
        PauseScreenText.text = "Game Paused";
        ResumeButton.interactable = true;
        PauseScreenObject.SetActive(true);
    }

    public void ResumeGameCommand()
    {
        PauseScreenObject.SetActive(false);
        // TODO: give a timer before game actually starts
        GameScreenObject.SetActive(true);
        GameManager.instance.ResumeGame();
    }

    public void QuitGameCommand()
    {
        PauseScreenObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
        StartScreenObject.SetActive(true);
    }

    public void LoadGameOverMenu()
    {
        GameScreenObject.SetActive(false);

        GameManager.instance.PauseGame();
        PauseScreenText.text = "Game Over";
        ResumeButton.interactable = false;
        PauseScreenObject.SetActive(true);
    }
}
