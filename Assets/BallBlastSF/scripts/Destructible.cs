using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destructible : MonoBehaviour
{
    public int maxHitPoints;

     private int hitPoints;

    [HideInInspector] public UnityEvent Die;
    [HideInInspector] public UnityEvent ChangeHitPoints;
    private bool isDie = false;
    public static bool stoneWasShot = false;
    
    


    private void Start()
    {
       
        hitPoints = maxHitPoints;
       
        ChangeHitPoints.Invoke();
    }


    public void ChargeStrength(int curePower)
    {
        if(hitPoints < maxHitPoints)
        {
            hitPoints += curePower;
           
            ChangeHitPoints.Invoke();
        }
    }

    public void ApplyDamage(int damage)
    {
        hitPoints -= damage;
        Debug.Log("ÍÀÑ ÏÎÄÑÒÐÅËÈËÈ ÍÀ "+hitPoints);
        stoneWasShot = true;
        ChangeHitPoints.Invoke();
        if (hitPoints <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        if (isDie == true) return;
        hitPoints = 0;
        isDie = true;
        ChangeHitPoints.Invoke();
        Die.Invoke();
    }

    public int GetHitPoints()
    {
        return hitPoints;
    }

  
}
