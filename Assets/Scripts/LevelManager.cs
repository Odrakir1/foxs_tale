using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{   

    public static LevelManager instance;
    public int gemsCounter;

    public string levelToLoad;
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

        yield return new WaitForSeconds(1.5f - (1f / UIController.instance.fadeSpeed));
        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds(1f / UIController.instance.fadeSpeed + .2f);

        UIController.instance.FadeFromBlack();

        Vector3 respawnPoint = CheckpointController.instance.currentSpawnPoint;
        Player.instance.gameObject.SetActive(true);
        PlayerHealthController.instance.currentHP = 6;
        UIController.instance.UpdateHealthUI();
        Player.instance.transform.position = respawnPoint;
    }

    public void EndLevel(){
        StartCoroutine(EndLevelCo());
    }

    public IEnumerator EndLevelCo(){
        Player.instance.stopInput = true;
        CameraController.instance.stopFollow = true;

        UIController.instance.levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(1f);

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds(1f);

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlock",1);

        UIController.instance.FadeFromBlack();
        UIController.instance.levelCompleteText.SetActive(false);
        Player.instance.stopInput = false;
        CameraController.instance.stopFollow = false;

        SceneManager.LoadScene(levelToLoad);
    }

}
