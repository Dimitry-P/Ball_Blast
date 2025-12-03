using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class ResumeTheGameButton : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private Button resumeButton;
    public static bool shoot = true;

    public void ResumeTheGame()
    {
       
        canvas.SetActive(false);
        Time.timeScale = 1;
        shoot = true;
    }
   
}
