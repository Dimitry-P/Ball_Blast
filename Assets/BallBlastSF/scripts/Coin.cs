using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float dropChance = 0.9f;
    [HideInInspector] public GameObject coin;

    private void Update()
    {
        createACoin();
    }



    public void createACoin()
    {
        if (Stone.canCreateACoin)
        {
            if (Random.value < dropChance)
            {
                coin = Instantiate(coinPrefab, Stone.coinTransform, Quaternion.identity);
                Debug.Log("Монета создана!"); // Отладка
                SpriteRenderer sr = coin.GetComponent<SpriteRenderer>();
                if (sr != null)
                {
                    sr.enabled = true;
                    Debug.Log("SpriteRenderer включён!");
                }
                else
                {
                    Debug.Log("ОШИБКА: У монеты нет SpriteRenderer!");
                }

                Rigidbody2D rb = coin.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    rb.gravityScale = 1; // Включаем падение
                    Debug.Log("Гравитация установлена в: " + rb.gravityScale);
                }
                Debug.Log($"Монета создана в позиции: {coin.transform.position}");
            }
        }
        Stone.canCreateACoin = false;
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {

        LevelEdge levelEdge = collision.GetComponent<LevelEdge>();

        if (levelEdge != null)
        {
            if (levelEdge.Type == EdgeType.Bottom)
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                if(rb != null){
                    rb.velocity = Vector2.zero;
                    rb.gravityScale = 0;
                }
            }
        }
        
    }

   
}
