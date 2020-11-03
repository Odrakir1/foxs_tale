using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{

    public static PausePanel instance;
    public string entry_menu,level_select;
    public bool isPaused;
    public GameObject panel;

    
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
        if(Input.GetKeyDown(KeyCode.Escape)){
            PauseUnpause();
        }
    }

    public void PauseUnpause(){

        if(isPaused){
            isPaused = false;
            panel.SetActive(false);
            Time.timeScale = 1f;
        }
        else{
            isPaused = true;
            panel.SetActive(true);
            Time.timeScale = 0f;
        }

    }

    public void LoadEntryMenu(){
        SceneManager.LoadScene(entry_menu);
        Time.timeScale = 1f;
    }

    public void GoToLevelSelect(){
        SceneManager.LoadScene(level_select);
        Time.timeScale = 1f;
    }
}
