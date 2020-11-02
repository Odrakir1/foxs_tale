using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource[] gameAudios;

    public AudioSource backgroundMusic,finishedLevel;
    public static AudioController instance;

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

    public void PlaySoundEffect(int id){
        gameAudios[id].Stop();

        gameAudios[id].pitch = Random.Range(0.9f,1.1f);

        gameAudios[id].Play();

    }
}
