using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    public static CheckpointController instance;
    private Checkpoint[] gameCheckPoints;

    public Vector3 currentSpawnPoint;

    // Start is called before the first frame update

    private void Awake() {
        instance = this;
        
    }

    void Start()
    {
        gameCheckPoints = FindObjectsOfType<Checkpoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOffCheckPoints(){

        for(int i = 0; i < gameCheckPoints.Length; i++){
            gameCheckPoints[i].ResetCheckPoint();
        }

    }

    public void SetNewSpawnPoint(Vector3 newSpawnPoint){
        currentSpawnPoint = newSpawnPoint;
    }

}
