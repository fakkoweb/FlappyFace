using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool IsGameOver = true;
    public bool IsGamePaused = false;

    PlayerFlappyController player;
    ObstacleGenerator generator;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
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
        // When GameManager is loaded, we are in menu and game is not running
        //IsGameOver = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        // Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        // Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(IsGameOver==false)
        {
            GameObject generatorgo = GameObject.Find("ObstacleGenerator");
            if (generatorgo != null)
                generator = generatorgo.GetComponent<ObstacleGenerator>();
            GameObject playergo = GameObject.FindGameObjectWithTag("Player");
            if (playergo != null)
                player = playergo.GetComponent<PlayerFlappyController>();

            if (generator != null)
                generator.StartGenerator();
        }
    }

    public void StartGame()
    {
        IsGameOver = false;
        IsGamePaused = false;
    }

    public void PauseGame()
    {
        IsGamePaused = true;
        generator.StopGenerator();
    }

    public void ResumeGame()
    {
        IsGamePaused = false;
        generator.StartGenerator();
    }

    public void EndGame()
    {
        IsGameOver = true;
        generator.StopGenerator();
        UIManager.instance.LoadGameOverMenu();
    }
}
