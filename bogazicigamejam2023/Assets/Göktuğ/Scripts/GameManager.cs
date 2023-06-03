using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    private int score;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = score + value;
            if (value >= 1)
            {
                UiController.instance.UpdateDistance(true);
            }
            else
            {
                UiController.instance.UpdateDistance(false);
            }
        }
    }

    [SerializeField] GameObject[] LandType;
    [SerializeField] GameObject[] Normal;
    [SerializeField] GameObject[] MiniGame;
    [SerializeField] GameObject[] EventArena;


    int BGindex = -1;
    int LandIndex = 0;
    int ChangeLandDistance;
    int NextLandChange;
    bool LandChanged = false;


    int BestScore;
    public bool GameRun = false;

    void Start()
    {
        ShowMenu();
    }
    public void ShowMenu()
    {
        UiController.instance.UpdateBestScore(PlayerPrefs.GetInt("BestScore", 0));
        CreateLevel();
        UiController.instance.ShowMenu();

    }
    public void ResetGame()
    {
        if (score > BestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
            UiController.instance.UpdateBestScore(PlayerPrefs.GetInt("BestScore", 0));
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void StartGame()
    {
        UiController.instance.ShowGameControls();
    }
    public void CreateLevel()
    {
        ChangeLandDistance = Random.Range(2, 5);
        for (int i = 0; i < 8; i++)
        {
            PoolManager.instance.Spawn("BGBlock", new Vector3(BGindex * 1024f, 0, 0), Quaternion.identity, true);
            BGindex++;
        }
    }
    public void UpdateBG()
    {
        PoolManager.instance.Spawn(LandType[LandIndex].name, new Vector3(0, 0, BGindex * 30), Quaternion.identity, true);
        BGindex++;

        if (!GameRun)
        {
            return;
        }

        if (!LandChanged)
        {
            LandIndex = Random.Range(0, LandType.Length);
            // Normal engeller (0)
            // MiniGame Engeli (1)
            // Event Alanı     (2)

            if (LandIndex == 0)
            {
                ChangeLandDistance = Random.Range(3, 7);
            }
            else if(LandIndex == 1)
            {
                ChangeLandDistance = 1;
            }
            else
            {
                ChangeLandDistance = Random.Range(3, 7);
            }
            NextLandChange = ChangeLandDistance + BGindex;
            
            LandChanged = true;
        }
        if (BGindex == NextLandChange)
        {
            LandChanged = false;
        }

        if (LandIndex == 0)
        {
            AddNormal();
        }
        if (LandIndex == 1)
        {
            AddMiniGame();
        }
        if (LandIndex == 2)
        {
            AddEventArena();
        }
    }
    public void AddNormal()
    {

    }

    public void AddMiniGame()
    {

    }

    public void AddEventArena()
    {

    }

    /*
    public void AddBuildings()
    {
        for (int i = -450; i < 450; i += 300)
        {
            if (Random.value > 0.5)
            {
                Vector3 pos = new Vector3(BGindex * 1024f + i + Random.Range(-20, 20), -273, 0);
                PoolManager.instance.Spawn(Buildings[Random.Range(0, Buildings.Length)].name, pos, Quaternion.identity, true);
            }
        }
    }*/

    public void CameraShake(float power)
    {
        CameraFollow2D.Shake(power);
    }
}
