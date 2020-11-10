using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Image heart1,heart2,heart3;

    public Sprite fullHeart,halfHeart,emptyHeart;

    public Text gemsText;

    public Image fadeScreen;

    public float fadeSpeed;
    private bool shouldFadeToBlack,shouldFadeFromBlack;

    public GameObject levelCompleteText;

    // Start is called before the first frame update
    void Start()
    {
        
        instance = this;

        FadeFromBlack();

    }

    // Update is called once per frame
    void Update()
    {
        if(shouldFadeToBlack){
            fadeScreen.color = new Color(fadeScreen.color.r,fadeScreen.color.g,fadeScreen.color.b,Mathf.MoveTowards(fadeScreen.color.a,1f,fadeSpeed * Time.deltaTime));

            if(fadeScreen.color.a == 1f){ 
                shouldFadeToBlack = false;
            }
        }

        if(shouldFadeFromBlack){

            fadeScreen.color = new Color(fadeScreen.color.r,fadeScreen.color.g,fadeScreen.color.b,Mathf.MoveTowards(fadeScreen.color.a,0f,fadeSpeed * Time.deltaTime));

            if(fadeScreen.color.a == 0f){ 
                shouldFadeFromBlack = false;
            }

        }
        
        
    }

    public void UpdateHealthUI(){

        switch(PlayerHealthController.instance.currentHP){

            case 6:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart;
                
                break;

            case 5:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = halfHeart;
                
                break;

            case 4:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = emptyHeart;
                
                break;

            case 3:
                heart1.sprite = fullHeart;
                heart2.sprite = halfHeart;
                heart3.sprite = emptyHeart;
                
                break;

            case 2:
                heart1.sprite = fullHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                
                break;    
            
            case 1:
                heart1.sprite = halfHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                
                break;
            
            case 0:
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                
                break;
            
            default:
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                
                break;

        }
    
    
    }


    public void UpdateGemsUI(){

        gemsText.text = LevelManager.instance.gemsCounter.ToString();
    }


    public void FadeToBlack(){
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack(){
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }

}
