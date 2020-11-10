using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelSelectPlayer : MonoBehaviour
{

    public MapPoint currentPoint;
    public float moveSpeed = 10f;

    public bool isMoving;

    private bool levelLoading;

    public LevelSelectManager selectManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update(){

        transform.position = Vector3.MoveTowards(transform.position,currentPoint.transform.position,moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position,currentPoint.transform.position) < .1f && !levelLoading){
            
            if(Input.GetAxisRaw("Horizontal") > .5f){
                if(currentPoint.right != null){
                    setNextPoint(currentPoint.right);
                }
            }
            else if(Input.GetAxisRaw("Horizontal") < -.5f){
                if(currentPoint.left != null){
                    setNextPoint(currentPoint.left);
                }   
            }

            else if(Input.GetAxisRaw("Vertical") > .5f){
                if(currentPoint.up != null){
                    setNextPoint(currentPoint.up);
                }   
            }
            else if(Input.GetAxisRaw("Vertical") < -.5f){
                if(currentPoint.down != null){
                    setNextPoint(currentPoint.down);
                }   
            }

            if(currentPoint.isLevel)
            {
                if(Input.GetButtonDown("Jump"))
                {
                    levelLoading = true;
                    selectManager.LoadLevel();
                }  
            }

        }



    }


    public void setNextPoint(MapPoint nextPoint){
        currentPoint = nextPoint;
    }

}
