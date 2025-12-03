using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using Color = UnityEngine.Color;

[RequireComponent(typeof(StoneMovement))]
public class Stone : Destructible
{
    public enum Size
    {
        Small,
        Normal,
        Big,
        Huge
    }

   

    [SerializeField] private Size size;
    [SerializeField] private float spawnUpForce;
    private StoneMovement movement;
    private Transform plusZ;
    public int dropTheCoin = 0;
    public static Vector3 coinTransform;
    public static bool canCreateACoin = false;
    


    private void Awake()
    {
        movement = GetComponent<StoneMovement>();
        plusZ = GetComponent<Transform>();
        Die.AddListener(OnStoneDestroyed);
        SetSize(size);
    }

    private void OnDestroy()
    {
        Die.RemoveListener(OnStoneDestroyed);
    }

    private void OnStoneDestroyed()
    {
        if(size != Size.Small)
        {
            SpawnStones();
        }
        Destroy(gameObject);
    }

    private void SpawnStones()
    {
        for (int i = 0; i < 2; i++)
        {
            Stone stone = Instantiate(this, transform.position, Quaternion.identity);
            stone.SetSize(size - 1);
            stone.transform.position += new Vector3(0, 0, StoneSpawner.zeroZero);
            StoneSpawner.zeroZero += 0.001f;

            stone.transform.GetChild(0).GetComponent<SpriteRenderer>().color = StoneSpawner.color1[Random.Range(0, StoneSpawner.color1.Length)];
            stone.maxHitPoints = Mathf.Clamp(maxHitPoints / 2, 1, maxHitPoints);
            
            stone.movement.AddVerticalVelocity(spawnUpForce);
            stone.movement.SetHorizontalDirection((i % 2 * 2) - 1);
            dropTheCoin++;
            coinTransform = transform.position;
            if (dropTheCoin == 2)
            {
                canCreateACoin = true;
                
            }
        }
    }

    public void SetSize(Size size)
    {
        if (size < 0) return;
        transform.localScale = GetVectorFromSize(size);
        this.size = size;
    }

   
       

    private Vector3 GetVectorFromSize(Size size)
    {
        if (size == Size.Huge) return new Vector3(1, 1, 1);
        if (size == Size.Big) return new Vector3(0.75f, 0.75f, 0.75f);
        if (size == Size.Normal) return new Vector3(0.6f, 0.6f, 0.6f);
        if (size == Size.Small) return new Vector3(0.4f, 0.4f, 0.4f);

        return Vector3.one;
    }
}
