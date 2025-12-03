using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pause : MonoBehaviour
{
    public UnityEvent onKeyPressed;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Клавиша R нажата!");
            onKeyPressed.Invoke();
            ResumeTheGameButton.shoot = false;
        }
    }
   
}
