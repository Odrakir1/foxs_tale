using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesController : MonoBehaviour
{
    public bool isGem,isHealthPoint;
    private bool collected;
    public GameObject pickUpAnimation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.CompareTag("Player") && !collected && isGem){

            LevelManager.instance.gemsCounter++;
            collected = true;
            Destroy(gameObject);
            Instantiate(pickUpAnimation,transform.position,transform.rotation);
            AudioController.instance.PlaySoundEffect(6);
            UIController.instance.UpdateGemsUI();

        }

        if(other.CompareTag("Player") && isHealthPoint && !collected && PlayerHealthController.instance.currentHP < PlayerHealthController.instance.maxHealth){
            PlayerHealthController.instance.HealPlayer();
            collected = true;
            Destroy(gameObject);
            Instantiate(pickUpAnimation,transform.position,transform.rotation);
            AudioController.instance.PlaySoundEffect(7);
        }

    }

}
