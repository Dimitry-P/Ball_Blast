using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using static UnityEngine.GraphicsBuffer;

public class UIGamePanel : MonoBehaviour
{
    [SerializeField] private Text currentLevelText;
    [SerializeField] private Text nextLevelText;
    [SerializeField] private Image progressBar;
    private float fillAmountStep1;
    private float fillAmountStep;
    [SerializeField] private Turret turret;
    public static int newPoints = 0;
    public static int internalPoints = 0;


    private void Start()
    {
        Debug.Log(StoneHitPointsText.numberOfPointsForExactStone);
        progressBar.fillAmount = 0;
        fillAmountStep1 = (StoneHitPointsText.numberOfPointsForExactStone) / turret.Damage;
        fillAmountStep = 1 / fillAmountStep1;

        Debug.Log(StoneSpawner.amount);
       
        Debug.Log(fillAmountStep1);
        Debug.Log(turret.Damage + " Дамаг");
        Debug.Log("ФилАМАУНТСТЕП " + fillAmountStep);
        currentLevelText.text = LevelGenerator.currentLevel.ToString();
        if(LevelGenerator.currentLevel == 3)
        {
            nextLevelText.text = LevelGenerator.currentLevel.ToString();
        }
        else
        {
            nextLevelText.text = (LevelGenerator.currentLevel + 1).ToString();
        }   
    }

    public static void SendAmountOfPointsOfAnotherStone(int additionalPointsForProgressBar)
    {
        
        int countOfCreatedStones = 0;
        internalPoints += additionalPointsForProgressBar;
        countOfCreatedStones++;
        if(countOfCreatedStones == 2)
        {
            newPoints = internalPoints;
            internalPoints = 0;
            countOfCreatedStones = 0;
        }
    }


    private void Update()
    {
        OnStoneCollisionByProjectile();
    }

    public void OnStoneCollisionByProjectile()
    {
        if (Destructible.stoneWasShot)
        {
            if(progressBar.fillAmount == 1) progressBar.fillAmount = 0;
            progressBar.fillAmount += fillAmountStep;
            Debug.Log("Строка прогресса увеличилась НА "+progressBar.fillAmount);
            Destructible.stoneWasShot = false;
        }
    }
}
