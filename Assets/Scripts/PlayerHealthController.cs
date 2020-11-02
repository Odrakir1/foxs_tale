using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int currentHP, maxHealth;
    public static PlayerHealthController instance;

    public float invencibilityTime,invencibilityCounter;

    private SpriteRenderer PlayerSR;
    public GameObject dyingAnim;

    private void Awake() {
        instance = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {   
        currentHP = maxHealth;
        PlayerSR = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(invencibilityCounter >0){
            invencibilityCounter -= Time.deltaTime;

            if(invencibilityCounter <=0){
                PlayerSR.color = new Color(PlayerSR.color.r,PlayerSR.color.g,PlayerSR.color.b,1f);
            }

        }
        
        
    }

    public void takeDamage(){

        if(invencibilityCounter <= 0){

            currentHP-=1;
            
            if(currentHP <= 0){
                currentHP = 0;
                //gameObject.SetActive(false);
                Instantiate(dyingAnim,transform.position,transform.rotation);
                AudioController.instance.PlaySoundEffect(8);
                LevelManager.instance.RespawnPlayer();
            }else{
                Player.instance.playerAnimator.SetTrigger("hurt");
                AudioController.instance.PlaySoundEffect(9);
                Player.instance.KnockBack();
                invencibilityCounter = invencibilityTime;
                PlayerSR.color = new Color(PlayerSR.color.r,PlayerSR.color.g,PlayerSR.color.b,.5f);
                
            }

            UIController.instance.UpdateHealthUI();

        }

    }


    public void HealPlayer(){

        currentHP++;

        if(currentHP > maxHealth){
            
            currentHP = maxHealth;
        }

        UIController.instance.UpdateHealthUI();

    }

}
