using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

[RequireComponent(typeof(Cart))] 
public class Cart : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float vehicleWidth;
    private Vector3 movementTarget;
    private  float deltaMovement;
    private float lastPositionX;
  
    [SerializeField] private UnityEngine.Transform[] wheels;
   
    [SerializeField] private float wheelRadius;

    [HideInInspector] public UnityEvent CollisionStone;
   

    public void Start()
    {
       
        
        movementTarget = transform.position;
    }
    private void Update()
    {
       
        
            Move();

            WheelRotate();
        
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Stone stone = collision.transform.root.GetComponent<Stone>();

        if(stone != null)
        {
            CollisionStone.Invoke();
        }
        Coin coin = collision.GetComponent<Coin>();
        if(coin != null)
        {
            ScoreManager.Instance.AddScore(1);
            Destroy(coin.gameObject);
        }
    }

    public void WheelRotate()
    {
        float a = (deltaMovement * 180) / (Mathf.PI * wheelRadius * 2);
        for(int i = 0; i < wheels.Length; i++)
        {
            wheels[i].Rotate(0, 0, -a);
        }
    }


    private void Move()
    {
        lastPositionX = transform.position.x;
        transform.position = Vector3.MoveTowards(transform.position, movementTarget, movementSpeed * Time.deltaTime);
        deltaMovement = transform.position.x - lastPositionX;
    }
    public void SetMovementTarget(Vector3 target)
    {
        movementTarget = ClampMovementTarget(target);
    }

    private Vector3 ClampMovementTarget(Vector3 target)
    {
        float leftBorder = LevelBoundary.Instance.LeftBorder + vehicleWidth * 0.5f;
        float rightBorder = LevelBoundary.Instance.RightBorder - vehicleWidth * 0.5f;
        Vector3 movTarget = target;
        movTarget.z = transform.position.z;
        movTarget.y = transform.position.y;

        if (movTarget.x < leftBorder) movTarget.x = leftBorder;
        if (movTarget.x > rightBorder) movTarget.x = rightBorder;

        return movTarget;
    }


#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position - new Vector3(vehicleWidth * 0.5f, 0.5f, 0), transform.position + new Vector3(vehicleWidth * 0.5f, -0.5f, 0));
    }
#endif
}
