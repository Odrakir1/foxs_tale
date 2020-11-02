using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{   

    public static LevelManager instance;
    public int gemsCounter;


    private void Awake() {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer(){
        
        StartCoroutine("Respawn");

    }


    IEnumerator Respawn(){
        Player.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(1.5f);
        Vector3 respawnPoint = CheckpointController.instance.currentSpawnPoint;
        Player.instance.gameObject.SetActive(true);
        PlayerHealthController.instance.currentHP = 6;
        UIController.instance.UpdateHealthUI();
        Player.instance.transform.position = respawnPoint;
    }

}
