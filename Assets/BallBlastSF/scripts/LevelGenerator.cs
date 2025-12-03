using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Button secondLevelButton;
    [SerializeField] private Button thirdLevelButton;
    [SerializeField] private Button StartAgainTheGameButton;
    [SerializeField] private int buildIndex;
    public static int currentLevel = 1;

    public void LoadSecondLevel()
    {
       
        SceneHelper.RestartLevel();
        SceneHelper.firstLevelIsWon = false;
        SceneHelper.secondLevelIsWon = true;
        StoneSpawner.amount = 2;
        currentLevel++;
    }
    public void LoadThirdLevel()
    {
       
        SceneHelper.RestartLevel();
        SceneHelper.secondLevelIsWon = false;
        SceneHelper.theGameIsWon = true;
        StoneSpawner.amount = 3;
        currentLevel++;
    }
    public void StartTheGameAgain()
    {
        SceneManager.LoadScene(buildIndex);
        SceneHelper.firstLevelIsWon = true;
        SceneHelper.theGameIsWon = false;
        StoneSpawner.amount = 1;
        currentLevel = 1;
    }
}
