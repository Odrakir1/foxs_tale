﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{

    public LevelSelectPlayer player;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(){
        StartCoroutine(LoadLevelCo());
    }

    public IEnumerator LoadLevelCo(){

        LSUIController.instance.FadeToBlack();
        
        yield return new WaitForSeconds(1f);
        
        SceneManager.LoadScene(player.currentPoint.levelToLoad);
    }
}
