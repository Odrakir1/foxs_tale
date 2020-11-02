using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator enemyAnim;

    public SpriteRenderer theSR;

    public float minTimeToWalk,maxTimeToWalk;
    public float minTimeToStay,maxTimeToStay;

    private float timeToStayCounter,timeToWalkCounter;

    public Transform leftPoint,rightPoint;

    public float moveSpeed;
    private Rigidbody2D enemy;
    private bool mustGoToRight;
    // Start is called before the first frame update
    void Start()
    {
        leftPoint.parent = null;
        rightPoint.parent = null;
        enemy = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        
        
        
        timeToWalkCounter = Random.Range(minTimeToWalk,maxTimeToWalk);
        timeToStayCounter = 0;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timeToWalkCounter > 0){

            enemyAnim.SetBool("isMoving",true);

            timeToWalkCounter -= Time.deltaTime;

            if(timeToWalkCounter <=0){
                timeToStayCounter = Random.Range(minTimeToStay,maxTimeToStay);
            }

            if(mustGoToRight){
                theSR.flipX = true;
                enemy.velocity = new Vector2(moveSpeed,enemy.velocity.y);
                

                if(transform.position.x > rightPoint.position.x){

                    mustGoToRight = false;
                }
                

            }
            else{
                theSR.flipX = false;

                enemy.velocity = new Vector2(-moveSpeed,enemy.velocity.y);
                
                if(transform.position.x < leftPoint.position.x){
                    
                    mustGoToRight = true;
                }

            }
            
           

        }
        else{

            
            enemy.velocity = new Vector2(0f,enemy.velocity.y);

            timeToStayCounter -= Time.deltaTime;

            enemyAnim.SetBool("isMoving",false);
            
            if(timeToStayCounter <= 0)
            {
                
                timeToWalkCounter = Random.Range(minTimeToWalk,maxTimeToWalk);
            }

        }

        

    }
}
