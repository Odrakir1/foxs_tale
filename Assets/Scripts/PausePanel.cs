using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{

    public string entry_menu,level_select;
    private bool isPaused;
    public GameObject panel;

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
        }
        else{
            isPaused = true;
            panel.SetActive(true);
        }

    }

    public void LoadEntryMenu(){
        SceneManager.LoadScene(entry_menu);
    }

    public void GoToLevelSelect(){
        SceneManager.LoadScene(level_select);
    }
}
