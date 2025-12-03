using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LevelState : MonoBehaviour
{
    [SerializeField] private StoneSpawner spawner;
    [SerializeField] private Cart cart;
    [SerializeField] private GameObject loose;
    [SerializeField] private GameObject winFirstLevel;
    [SerializeField] private GameObject winSecondLevel;
    [SerializeField] private GameObject winThirdLevel;
  
    


    [Space(5)]
    public UnityEvent Passed;
    public UnityEvent Defeat;
   
    private float timer;
    private bool checkPassed;

    private void Awake()
    {
        loose.SetActive(false);
        spawner.Completed.AddListener(OnSpawnCompleted);
        cart.CollisionStone.AddListener(OnCartCollisionStone);
        
    }

    private void OnDestroy()
    {
        spawner.Completed.RemoveListener(OnSpawnCompleted);
        cart.CollisionStone.RemoveListener(OnCartCollisionStone);
    }

   

    private void OnCartCollisionStone()
    {
        Defeat.Invoke();
        Time.timeScale = 0;
        SceneHelper.theGameIsLost = true;
    }

    private void OnSpawnCompleted()
    {
        checkPassed = true;
        winFirstLevel.SetActive(false);
        winSecondLevel.SetActive(false);
        winThirdLevel.SetActive(false);
        loose.SetActive(false);
    }


    private void Update()
    {
        loose.SetActive(false);
        if (SceneHelper.theGameIsLost)
        {
            
            loose.SetActive(true);
            Debug.Log("Игра проиграна");
           
        }
        //if (SceneHelper.firstLevelIsWon)
        //{
        //    winFirstLevel.SetActive(true);
        //    Time.timeScale = 0;
        //    Debug.Log("Включился winFirstLevel");
        //}
        //else if (SceneHelper.secondLevelIsWon)
        //{
        //    winSecondLevel.SetActive(true);
        //    Time.timeScale = 0;
        //    Debug.Log("Включился winSecondLevel");
        //}
        //else if (SceneHelper.theGameIsWon)
        //{
        //    winThirdLevel.SetActive(true);
        //    Time.timeScale = 0;
        //    Debug.Log("Включился winThirdLevel");
        //}
        timer += Time.deltaTime;

        if(timer > 0.5f)
        {
            if(checkPassed == true)
            {
                if (FindObjectsOfType<Stone>().Length == 0 && SceneHelper.firstLevelIsWon == true || FindObjectsOfType<Stone>().Length == 0 && SceneHelper.secondLevelIsWon == true ||  FindObjectsOfType<Stone>().Length == 0 && SceneHelper.theGameIsWon == true)
                {
                    
                    if (SceneHelper.firstLevelIsWon)
                    {
                        winFirstLevel.SetActive(true);
                        Time.timeScale = 0;
                        Passed.Invoke();
                        SceneHelper.secondLevelIsWon = false;
                        SceneHelper.theGameIsWon = false;
                    }
                    if (SceneHelper.secondLevelIsWon)
                    {
                        winSecondLevel.SetActive(true);
                        Time.timeScale = 0;
                        SceneHelper.firstLevelIsWon = false;
                        SceneHelper.theGameIsWon = false;
                        Passed.Invoke();
                        
                    }
                    if (SceneHelper.theGameIsWon)
                    {
                        winThirdLevel.SetActive(true);
                        SceneHelper.theGameIsWon = true;
                        Time.timeScale = 0;
                        Passed.Invoke();
                        SceneHelper.firstLevelIsWon = false;
                        SceneHelper.secondLevelIsWon = false;
                    }

                }
            }
            timer = 0;
        }
    }
}
