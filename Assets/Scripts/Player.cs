using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public float xVelocity;
    public Rigidbody2D playerRB;
    private float x,y;
    public float jumpForce;

    private bool isGrounded;
    private bool canDoubleJump;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    public Animator playerAnimator;

    public float bounceForce;

    private bool isLookingLeft;

    private Transform playerTransform;
    
    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    public bool stopInput;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {   

        if(PausePanel.instance.isPaused || stopInput) return;

        if(knockBackCounter<=0){
            
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");

            playerRB.velocity = new Vector2(x * xVelocity,playerRB.velocity.y);

            if((x<0 && !isLookingLeft) || (x > 0 && isLookingLeft)){

                turnBack();

            }

            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position,.2f,whatIsGround);
            

            if(isGrounded){
                canDoubleJump = true;
            }

            if(Input.GetButtonDown("Jump")){

                if(isGrounded){
                    AudioController.instance.PlaySoundEffect(10);
                    playerRB.velocity = new Vector2(playerRB.velocity.x,jumpForce);
                    

                }
                else if(canDoubleJump){
                    AudioController.instance.PlaySoundEffect(10);
                    playerRB.velocity = new Vector2(playerRB.velocity.x,jumpForce);
                    canDoubleJump = false;   
                }

                
            }

            

        }
        else{

            knockBackCounter -= Time.deltaTime;

            if(!isLookingLeft){
                playerRB.velocity = new Vector2(-knockBackForce,playerRB.velocity.y);
            }
            else{
                playerRB.velocity = new Vector2(knockBackForce,playerRB.velocity.y);
            }

        }
        
        playerAnimator.SetFloat("yValue",playerRB.velocity.y);
        playerAnimator.SetFloat("moveSpeed", Mathf.Abs(playerRB.velocity.x));    
        playerAnimator.SetBool("onTheGround",isGrounded);


    }

    void turnBack(){

        playerTransform.localScale = new Vector2(-playerTransform.localScale.x,1);
        isLookingLeft = !isLookingLeft;

    }

    public void KnockBack(){

        knockBackCounter = knockBackLength;
        playerRB.velocity = new Vector2(0f,knockBackForce);

    }


    public void Bounce(){

        playerRB.velocity = new Vector2(playerRB.velocity.x,bounceForce);

    }

}
