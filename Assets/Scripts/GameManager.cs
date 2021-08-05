using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
    enum States
    {
        Start,
        Play,
        Pause,
        GameOver
    };

    public static GameManager Instance { get; private set; }

    const string keyReset = "reset";

    States gameState;

    PanelManager panelMngr;
    // SocialManager socialMngr;

    void Awake()
    {
        // TODO: to remove the line
        // PlayerPrefs.DeleteAll();

        Application.targetFrameRate = 60;

        Instance = this;

        gameState = States.Start;

        panelMngr = GetComponent<PanelManager>();
        // socialMngr = GetComponent<SocialManager>();
    }

    void Start()
    {
        // socialMngr.AuthenticateGameServices();
        // if (PlayerPrefs.GetInt(keyReset) == 1)
        // {
        //     PlayerPrefs.SetInt(keyReset, 0);

        //     Play();
        // }
    }

    public bool IsStart()
    {
        return gameState == States.Start;
    }

    public bool IsPlay()
    {
        return gameState == States.Play; // If playing return true
    }

    public void Play()
    {
        gameState = States.Play;
        panelMngr.ShowHUDPanel();
        // PlayerPrefs.DeleteKey("GameScorePrefs");
    }

    public void Pause()
    {
        // if (IsPlay()) gameState = States.Pause;
        gameState = States.Pause;
    }

    public void Unpause()
    {
        // if (gameState == States.Pause) 
        gameState = States.Play;
    }

    // public void GameOver(int score)
    // {
    //     gameState = States.GameOver;
    //     panelMngr.ShowGameOverPanel();

    //     Analytics.CustomEvent("game_over", new Dictionary<string, object>
    //     {
    //         {"score", score}
    //     });
    // }
    public void GameOver()
    {
        gameState = States.GameOver;
        panelMngr.ShowGameOverPanel();
        // AdsManager.Instance.ShowInterstitialAdDelayed();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetTutorial()
    {
        // PlayerPrefs.SetInt(TipController.IsTip, 0);
        // Reset();
    }

    public void Reset()
    {
        // PlayerPrefs.SetInt(keyReset, 1);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // public SocialManager SocialMngr
    // {
        // get { return socialMngr; }
    // }

    public PanelManager PanelMngr
    {
        get { return panelMngr; }
    }
}
