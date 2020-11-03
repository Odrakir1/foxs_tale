using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public static CameraController instance;
    public Transform playerPosition, farBackground, middleBackground;
    public float minHeight, maxHeight;
    private Vector2 startPos,amountToMove;

    public bool stopFollow;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        startPos = transform.position;
     
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopFollow){
            transform.position = new Vector3(playerPosition.position.x,playerPosition.position.y,-10f);
            transform.position = new Vector3(playerPosition.position.x, Mathf.Clamp(transform.position.y,minHeight,maxHeight),-10f);

            amountToMove = new Vector3(transform.position.x - startPos.x, transform.position.y - startPos.y, -10f);

            farBackground.position = farBackground.position + new Vector3(amountToMove.x,amountToMove.y, 0f);
            middleBackground.position += new Vector3(amountToMove.x,amountToMove.y,0f) * 0.5f;

            startPos = transform.position;
        }
    }
}
