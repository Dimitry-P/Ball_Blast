using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Destructible))]
public class StoneHitPointsText : MonoBehaviour
{
    [SerializeField] private Text hitpointText;

    private Destructible destructible;
    public static int numberOfPointsForExactStone = 0;

    private void Awake()
    {
        destructible = GetComponent<Destructible>();

        destructible.ChangeHitPoints.AddListener(OnChangeHitPoint);
    }

    private void OnDestroy()
    {
        destructible.ChangeHitPoints.RemoveListener(OnChangeHitPoint);
    }
    private void OnChangeHitPoint()
    {
        int hitPoints = destructible.GetHitPoints();

        numberOfPointsForExactStone += hitPoints;

        Debug.Log("Кол-во очков у одного камня" + numberOfPointsForExactStone);

        if (hitPoints >= 1000)
        {
            hitpointText.text = hitPoints / 1000 + "K";
        }
        else
        {
            hitpointText.text = hitPoints.ToString();
        }
    }

}
