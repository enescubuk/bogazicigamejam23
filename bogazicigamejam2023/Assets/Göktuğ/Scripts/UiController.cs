using UnityEngine;
using TMPro;
using DG.Tweening;
using Unity.VisualScripting;

public class UiController : Singleton<UiController>
{
    public GameObject UiContainer;
    bool startGame = false;

    [SerializeField] enum state { mainMenu, gameRun, gameOver }

    [SerializeField] state gameState;

    [Header("Panels")]
    [SerializeField] GameObject GameUI;
    [SerializeField] GameObject GameOver;

    [Space]
    [Header("Labels")]
    [SerializeField] TextMeshProUGUI DistanceText;
    [SerializeField] TextMeshProUGUI BestScoreText;

    void Update()
    {
        if (gameState == state.mainMenu && startGame && !GameManager.instance.GameRun)
        {
            startGame = false;
            gameState = state.gameRun;
            ShowGameControls();
        }
    }
    public void ShowMenu()
    {
        gameState = state.mainMenu;
        GameUI.SetActive(false);
        GameOver.SetActive(false);
    }
    public void ShowGameControls()
    {
        gameState = state.gameRun;
        GameUI.SetActive(true);
        GameOver.SetActive(false);
    }
    public void ShowGameOver()
    {
        gameState = state.gameOver;
        GameUI.SetActive(false);
        GameOver.SetActive(true);
    }
    public void UpdateDistance(bool _pulse)
    {
        if (DistanceText == null)
        {
            Debug.Log("DistanceText is Null");
            return;
        }
        DistanceText.text = GameManager.instance.Score.ToString();
    }
    public void UpdateBestScore(int _score)
    {
        if(BestScoreText == null)
        {
            Debug.Log("BestScoreText is Null");
            return;
        }
        BestScoreText.text = _score.ToString();
    }
    public void StartGame()
    {
        startGame = true;
    }
    public void GameOverButton()
    {
        gameState = state.mainMenu;
        GameManager.instance.ResetGame();
    }
}