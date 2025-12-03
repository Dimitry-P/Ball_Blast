using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;


public class StoneSpawner : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate;

    [Header("Balance")]
    [SerializeField] private Turret turret;
    public static int amount = 1;
    private int stoneMaxHitpoints;
    private int stoneMinHitpoints;
    [SerializeField] [Range(0.0f, 1.0f)] private float minHitpointsPercentage;
    [SerializeField] private int maxHitpointsRate;
    public GameObject myPrefab;
    public static float zeroZero = 0.001f;
    


    [Space(10)] public UnityEvent Completed;
    

    private float timer;
    private float amountSpawned;

    private void Start()
    {
        int damagePerSecond = (int)((turret.Damage * turret.ProjectileAmount) * (1 / turret.FireRate));
        stoneMaxHitpoints = (int)(damagePerSecond * maxHitpointsRate);
        stoneMinHitpoints = (int)(stoneMaxHitpoints * minHitpointsPercentage);
        timer = spawnRate;
    }
    private void Update()
    {

       
        timer += Time.deltaTime;

        if(timer >= spawnRate)
        {
            Spawn();

            timer = 0;
        }
        if(amountSpawned == amount)
        {
            enabled = false;

            Completed.Invoke();
            
        }



    }


    Color color = Color.blue;
    public static Color[] color1 = new Color[9] { Color.black, Color.blue, Color.cyan, Color.gray, Color.green, Color.magenta, Color.red, Color.white, Color.yellow };




    private void Spawn()
    {
        Stone stone = Instantiate(stonePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        stone.SetSize((Stone.Size)Random.Range(1, 4));
        stone.transform.GetChild(0).GetComponent<SpriteRenderer>().color = color1[Random.Range(0, color1.Length)];
       
        stone.transform.position += new Vector3(0, 0, zeroZero);
        zeroZero += 0.001f;
        stone.maxHitPoints = Random.Range(stoneMinHitpoints, stoneMaxHitpoints + 1);
        
        amountSpawned++;
    }

}
