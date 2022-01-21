using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum GameStates
    {
        Pending,
        Start,
        Win,
        Fail
    }

    [Space(15)]
    public int level;

    UIController UI;
    PlayerController Player;
    CameraController Camera;

    public GameStates gameState;

    //Singelton
    public static GameController instance;

    private void OnEnable()
    {
        EventManager.Start += GameStart;
        EventManager.Win += GameWin;
        EventManager.Fail += GameFail;
    }
    private void OnDisable()
    {
        EventManager.Start -= GameStart;
        EventManager.Win -= GameWin;
        EventManager.Fail -= GameFail;
    }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        GetLevel();
        CheckLevel();
    }

    void GetLevel()
    {
        if(PlayerPrefs.GetInt("Level") == 0)
        {
            level = 1;
            PlayerPrefs.SetInt("Level", 1);
        }
        else
        {
            level = PlayerPrefs.GetInt("Level");
        }
    }

    void CheckLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex != level - 1)
        {
            SceneManager.LoadScene(level - 1);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        StartMethods();
    }

    void StartMethods()
    {
        UI = UIController.instance;
        Player = PlayerController.instance;
        Camera = CameraController.instance;
    }

    public void TapToStartActions()
    {
        OnEnable();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    void GameStart()
    {
        gameState = GameStates.Start;
    }
    void GameFail()
    {
        gameState = GameStates.Fail;
    }
    void GameWin()
    {
        gameState = GameStates.Win;
    }

    public void EndGameButtonAction()
    {
        if(gameState == GameStates.Fail)
        {
            if (level ==SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                PlayerPrefs.SetInt("Level", level + 1);
                SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
            }
        }
        else if (gameState == GameStates.Win)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
