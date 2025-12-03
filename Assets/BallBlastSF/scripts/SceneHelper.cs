
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using Unity.Mathematics;

public class SceneHelper : MonoBehaviour
{
    [SerializeField] public GameObject canvas;
    [SerializeField] public GameObject GUICanvas;
    [SerializeField] private Button startButton;
    [SerializeField] private GameObject restart;
    
 
    [SerializeField] private int buildIndex;

    public static bool wasCanvasHidden = false;
    public static bool firstLevelIsWon = false;
    public static bool secondLevelIsWon = false;
    public static bool theGameIsWon = false;
    public static bool theGameIsLost = false;

    private void Awake()
    {
        if (!wasCanvasHidden)
        {
            Time.timeScale = 0;
        }
    }

    public static void RestartLevel()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        theGameIsLost = false ;
    }
    public void LoadLevel()
    {
        canvas.SetActive(false);
        Cursor.visible = true;
        wasCanvasHidden = true;
        SceneManager.LoadScene(buildIndex);
        SceneHelper.firstLevelIsWon = true; 
    }

    private void Update()
    {
        
        if (wasCanvasHidden)
        {
            canvas.SetActive(false);
            Time.timeScale = 1;
            GUICanvas.SetActive(true);
        } 
    }



    public void Quit()
    {
        Application.Quit();
    }
}

